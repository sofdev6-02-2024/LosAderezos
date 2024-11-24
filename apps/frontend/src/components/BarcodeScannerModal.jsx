import { useState, useRef } from 'react';
import PropTypes from 'prop-types';
import Scanner from './Scanner';
import ImageScanner from './ImageScanner';
import Modal from './Modal';

function BarcodeScannerModal({ isVisible, onClose, onScan }) {
  const [scanning, setScanning] = useState(false);
  const [showImageScanner, setShowImageScanner] = useState(false);
  const scannerRef = useRef(null);

  const handleDetected = (barcode) => {
    onScan(barcode);
    setTimeout(() => {
      setScanning(false);
      setShowImageScanner(false);
      onClose();
    }, 500);
  };

  const handleScanToggle = () => {
    setScanning(!scanning);
    setShowImageScanner(false); // Asegurarse de que solo uno esté activo a la vez
  };

  const handleImageScannerToggle = () => {
    setShowImageScanner(!showImageScanner);
    setScanning(false); // Asegurarse de que solo uno esté activo a la vez
  };

  return (
    <Modal isVisible={isVisible} onClose={onClose} width="max-w-lg" height="h-auto">
      <div>
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-lg font-semibold">Escanear Código de Barras</h2>
        </div>

        <div
          ref={scannerRef}
          style={{
            position: 'relative',
            width: '100%',
            height: '300px',
            border: '2px solid #ccc',
            borderRadius: '8px',
            overflow: 'hidden',
            marginBottom: '1rem',
          }}
        >
          {scanning && (
            <Scanner
              scannerRef={scannerRef}
              onDetected={handleDetected}
              showVisualization={true}
            />
          )}
          {showImageScanner && <ImageScanner onDetected={handleDetected} />}
        </div>

        <div className="mt-4 flex justify-between">
          <button
            onClick={handleScanToggle}
            className={`${
              scanning ? 'bg-gray-500' : 'bg-red-600'
            } text-white px-4 py-2 rounded`}
          >
            {scanning ? 'Detener Escaneo' : 'Iniciar Escaneo'}
          </button>
          <button
            onClick={handleImageScannerToggle}
            className="bg-blue-600 text-white px-4 py-2 rounded"
          >
            {showImageScanner ? 'Cerrar Escáner de Imagen' : 'Adjuntar Imagen'}
          </button>
        </div>
      </div>
    </Modal>
  );
}

BarcodeScannerModal.propTypes = {
  isVisible: PropTypes.bool.isRequired,
  onClose: PropTypes.func.isRequired,
  onScan: PropTypes.func.isRequired,
};

export default BarcodeScannerModal;
