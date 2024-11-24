import { useLayoutEffect, useCallback } from 'react';
import PropTypes from 'prop-types';
import Quagga from '@ericblade/quagga2';

function getMedian(arr) {
  arr.sort((a, b) => a - b);
  const half = Math.floor(arr.length / 2);
  return arr.length % 2 === 1 ? arr[half] : (arr[half - 1] + arr[half]) / 2;
}

function getMedianOfCodeErrors(decodedCodes) {
  const errors = decodedCodes.filter((x) => x.error !== undefined).map((x) => x.error);
  return getMedian(errors);
}

const defaultConstraints = {
  width: 1280,
  height: 720,
};

const defaultDecoders = ['code_128_reader', 'ean_reader', 'upc_reader'];

const Scanner = ({
  scannerRef,
  onDetected,
  onScannerReady,
  constraints = defaultConstraints,
  decoders = defaultDecoders,
  showVisualization = true,
}) => {
  const handleProcessed = useCallback(
    (result) => {
      if (!showVisualization) return;

      const drawingCtx = Quagga.canvas.ctx.overlay;
      const drawingCanvas = Quagga.canvas.dom.overlay;

      drawingCtx.clearRect(0, 0, drawingCanvas.width, drawingCanvas.height);

      if (result) {
        if (result.boxes) {
          result.boxes
            .filter((box) => box !== result.box)
            .forEach((box) => {
              Quagga.ImageDebug.drawPath(box, { x: 0, y: 1 }, drawingCtx, { color: 'purple', lineWidth: 2 });
            });
        }
        if (result.box) {
          Quagga.ImageDebug.drawPath(result.box, { x: 0, y: 1 }, drawingCtx, { color: 'red', lineWidth: 3 });
        }
        if (result.codeResult && result.codeResult.code) {
          drawingCtx.font = '24px Arial';
          drawingCtx.fillStyle = 'green';
          drawingCtx.fillText(result.codeResult.code, 10, 20);
        }
      }
    },
    [showVisualization]
  );

  const errorCheck = useCallback(
    (result) => {
      if (!onDetected) return;

      const error = getMedianOfCodeErrors(result.codeResult.decodedCodes);
      if (error < 0.35) {
        console.log('Código detectado con alta confianza:', result.codeResult.code);
        onDetected(result.codeResult.code);
      }
    },
    [onDetected]
  );

  useLayoutEffect(() => {
    console.log('Inicializando Quagga...');
    if (!scannerRef.current) {
      console.error('El scannerRef no está apuntando a un elemento válido.');
      return;
    }

    const timeout = setTimeout(() => {
      Quagga.init(
        {
          inputStream: {
            type: 'LiveStream',
            constraints: {
              ...constraints,
            },
            target: scannerRef.current,
          },
          decoder: { readers: decoders },
          locate: true,
          locator: {
            patchSize: 'large',
            halfSample: false,
          },
        },
        (err) => {
          if (err) {
            if (err.name === 'NotAllowedError') {
              console.error('Permiso de cámara denegado. Asegúrate de que el navegador tiene acceso.');
            } else {
              console.error('Error inicializando Quagga:', err);
            }
            return;
          }
          console.log('Quagga inicializado correctamente.');
          Quagga.start();
          if (onScannerReady) onScannerReady();
        }
      );

      if (showVisualization) Quagga.onProcessed(handleProcessed);
      Quagga.onDetected(errorCheck);
    }, 300);

    return () => {
      clearTimeout(timeout);
      console.log('Limpiando Quagga...');
      Quagga.offProcessed(handleProcessed);
      Quagga.offDetected(errorCheck);
      Quagga.stop();
    };
  }, [scannerRef, onDetected, constraints, decoders, showVisualization, handleProcessed, errorCheck, onScannerReady]);

  return null;
};

Scanner.propTypes = {
  scannerRef: PropTypes.object.isRequired,
  onDetected: PropTypes.func.isRequired,
  onScannerReady: PropTypes.func,
  constraints: PropTypes.object,
  decoders: PropTypes.array,
  showVisualization: PropTypes.bool,
};

export default Scanner;
