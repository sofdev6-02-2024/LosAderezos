import PropTypes from 'prop-types';
import jsPDF from 'jspdf';
import jsbarcode from 'jsbarcode';
import Button from './Button';
import Logo from '../assets/Logo.png';
import { AiOutlineDownload } from 'react-icons/ai';

function GeneratePDFButton({ products, className }) {
  const generatePDF = () => {
    const doc = new jsPDF();
    const marginX = 10;
    const marginY = 20;
    const columnWidth = 40; 
    const rowHeight = 10;

    doc.addImage(Logo, 'PNG', marginX, marginY - 10, 65, 30); // Tamaño de 150x150 px

    const tableColumn = ['Nombre Producto', 'Código', 'Precio', 'Cantidad'];
    const tableRows = [];

    products.forEach((product) => {
      const barcodeCanvas = document.createElement('canvas');
      jsbarcode(barcodeCanvas, product.productCode, {
        format: 'CODE128',
        width: 1,
        height: 30,
        displayValue: true,
      });

      const barcodeImage = barcodeCanvas.toDataURL('image/png');

      tableRows.push([
        product.name || 'Sin nombre',
        product.productCode || 'Sin código',
        `$${product.sellPrice || 0}`,
        product.quantity || 0,
        barcodeImage,
      ]);
    });

    let yPosition = marginY + 30;

    doc.setFontSize(12);  // Cambiar tamaño de fuente para los encabezados
    doc.setFont(undefined, 'bold');
    tableColumn.forEach((header, i) => {
      const xPosition = marginX + i * columnWidth;
      doc.text(header, xPosition + columnWidth / 2, yPosition, { align: 'center' });
    });

    yPosition += rowHeight + 5;

    doc.setFontSize(10);  // Cambiar tamaño de fuente para el contenido de las celdas
    doc.setFont(undefined, 'normal');
    tableRows.forEach((row) => {
      let maxHeight = 0;

      row.forEach((cell, i) => {
        const xPosition = marginX + i * columnWidth;
        const yRowPosition = yPosition + rowHeight / 2;

        if (i === row.length - 1) {
          const imgX = xPosition;
          const imgY = yPosition;
          doc.addImage(cell, 'PNG', imgX, imgY, 40, 10);
          maxHeight = Math.max(maxHeight, 10);
        } else {
          const textLines = doc.splitTextToSize(String(cell), columnWidth - 2);
          const cellHeight = textLines.length * 6;
          const textYPosition = yRowPosition + (rowHeight - cellHeight) / 2;
          doc.text(textLines, xPosition + columnWidth / 2, textYPosition, { align: 'center' });
          maxHeight = Math.max(maxHeight, cellHeight);
        }
      });

      yPosition += maxHeight + 5;
    });

    doc.save('Lista_productos.pdf');
  };

  return (
    <Button
      className={`bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2 ${className}`} 
      onClick={generatePDF}
      type="common"
    >
      PDF
      <AiOutlineDownload size={19} />
    </Button>
  );
}

GeneratePDFButton.propTypes = {
  products: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      productCode: PropTypes.string.isRequired,
      sellPrice: PropTypes.number.isRequired,
      quantity: PropTypes.number.isRequired,
    })
  ).isRequired,
  className: PropTypes.string,
};

export default GeneratePDFButton;
