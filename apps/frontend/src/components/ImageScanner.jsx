import { useCallback, useState } from 'react';
import PropTypes from 'prop-types';
import Quagga from '@ericblade/quagga2';

const ImageScanner = ({ onDetected, onError }) => {
  const [selectedImage, setSelectedImage] = useState(null);

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    if (file && file.type.startsWith('image/')) {
      setSelectedImage(URL.createObjectURL(file));
    } else {
      alert('Por favor selecciona un archivo de imagen válido (.jpeg, .png, etc.).');
    }
  };

  const handleScanImage = useCallback(() => {
    if (!selectedImage) {
      alert('Por favor selecciona una imagen para escanear.');
      return;
    }

    Quagga.decodeSingle(
      {
        src: selectedImage,
        numOfWorkers: 0,
        singleWorker: true, 
        inputStream: {
          size: 1000, 
        },
        decoder: {
          readers: ['code_128_reader'], 
        },
        locate: true, 
        locator: {
          patchSize: 'medium',
          halfSample: true, 
        },
      },
      (result) => {
        if (result && result.codeResult) {
          console.log('Código detectado:', result.codeResult.code);
          onDetected(result.codeResult.code);
        } else {
          console.error('No se pudo detectar un código en la imagen.');
          if (onError) onError('No se detectó ningún código en la imagen.');
        }
      }
    );
  }, [selectedImage, onDetected, onError]);

  return (
    <div className="flex flex-col items-center space-y-4">
      <h2 className="font-bold text-lg">Escanear código desde una imagen</h2>
      <input
        type="file"
        accept="image/jpeg, image/png"
        onChange={handleFileChange}
        className="border p-2"
      />
      {selectedImage && (
        <div className="preview">
          <p className="text-sm">Vista previa de la imagen seleccionada:</p>
          <img
            src={selectedImage}
            alt="Seleccionada"
            className="max-w-full h-auto border border-gray-300 p-2"
            style={{ maxHeight: '200px', objectFit: 'contain' }} 
          />
        </div>
      )}
      <button
        onClick={handleScanImage}
        className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
      >
        Escanear Imagen
      </button>
    </div>
  );
};

ImageScanner.propTypes = {
  onDetected: PropTypes.func.isRequired,
  onError: PropTypes.func,
};

export default ImageScanner;
