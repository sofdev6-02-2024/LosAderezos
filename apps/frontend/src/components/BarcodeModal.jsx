import { useEffect, useRef } from 'react';
import jsbarcode from 'jsbarcode';
import { AiOutlineDownload } from 'react-icons/ai';
import PropTypes from 'prop-types';
import Modal from './Modal';
import Button from './Button';

function BarcodeModal({ productId, productName, showModal, onClose }) {
  const barcodeRef = useRef(null);

  useEffect(() => {
    if (showModal && barcodeRef.current) {
      if (!productId) {
        console.error('productId is missing or invalid');
      } else {
        jsbarcode(barcodeRef.current, productId, {
          format: 'CODE128',
          displayValue: true,
          width: 2,
          height: 100,
          margin: 10,
        });
      }
    }
  }, [productId, showModal]);

  const handleDownload = () => {
    const svgElement = barcodeRef.current;

    if (!svgElement) {
      console.error('SVG element not found');
      return;
    }

    const serializer = new XMLSerializer();
    const svgString = serializer.serializeToString(svgElement);
    const canvas = document.createElement('canvas');
    const context = canvas.getContext('2d');
    const img = new Image();
    const svgBlob = new Blob([svgString], { type: 'image/svg+xml;charset=utf-8' });
    const url = URL.createObjectURL(svgBlob);
    const formattedProductName = productName.replace(/\s+/g, '_');

    img.onload = () => {
      canvas.width = img.width;
      canvas.height = img.height;
      context.drawImage(img, 0, 0);
      const imageUrl = canvas.toDataURL('image/jpeg');
      const link = document.createElement('a');
      link.href = imageUrl;
      link.download = `${formattedProductName}.jpg`;
      link.click();
      URL.revokeObjectURL(url);
    };

    img.src = url;
  };

  return (
    <Modal isVisible={showModal} onClose={onClose} width="max-w-lg" height="h-[400px]">
      <div className="flex-1 flex flex-col justify-center items-center">
        <svg ref={barcodeRef} className="w-full h-auto max-h-[150px]"></svg>

        <div className="mt-4 flex justify-center">
          <Button
            onClick={handleDownload}
            className="bg-blue-800 text-white hover:bg-blue-950"
            type="common"
          >
            <AiOutlineDownload className="text-xl mr-2" />
            Descargar en JPEG
          </Button>
        </div>
      </div>
    </Modal>
  );
}

BarcodeModal.propTypes = {
  productId: PropTypes.string.isRequired,
  productName: PropTypes.string.isRequired,
  showModal: PropTypes.bool.isRequired,
  onClose: PropTypes.func.isRequired,
};

export default BarcodeModal;
