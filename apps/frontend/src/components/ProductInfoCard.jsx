import ReactDOM from 'react-dom';
import { useState } from 'react';
import { Card } from 'flowbite-react';
import PropTypes from 'prop-types';
import { RiEditLine } from "react-icons/ri";
import { AiOutlineDownload } from "react-icons/ai";
import Button from './Button';
import Line from './Line';
import BarcodeModal from './BarcodeModal';

function ProductInfoCard ({ productData, productCategories, onOtherBranchesClick = () => {}, showButton = true }) {
  const [showBarcodeModal, setShowBarcodeModal] = useState(false);

  const openBarcodeModal = () => {
    setShowBarcodeModal(true); 
  };

  const closeBarcodeModal = () => {
    setShowBarcodeModal(false); 
  };

  return (
    <Card className="w-full max-w-sm h-fit lg:max-w-lg shadow-lg rounded-3xl border-neutral-950">
      <div className="flex items-center justify-between pb-1">
        <h5 className="text-xl font-roboto font-medium tracking-tight text-neutral-950 dark:text-white">
          {productData.name}
        </h5>
        <RiEditLine className="text-3xl lg:text-6xl text-neutral-950 cursor-pointer hover:text-blue-800" />
      </div>

      <Line />     

      <div className="flex items-center justify-between py-1">
        <div>
          <p className="text-neutral-950 text-base font-bold font-roboto">Código de barras</p>
          <p className="text-neutral-950 text-base font-roboto font-normal">{productData.productCode}</p>
        </div>
        <AiOutlineDownload 
          className="text-3xl lg:text-6xl mb-2 text-neutral-950 cursor-pointer hover:text-blue-800"
          onClick={openBarcodeModal} />
      </div>

      <Line />

      <div className="py-1">
        <h3 className="text-neutral-950 text-base font-roboto font-bold">Categorías</h3>
        <ul className="list-disc ml-6 font-roboto font-normal text-sm text-neutral-950">
          {productCategories.map((category, index) => (
            <li key={index}>{category.name}</li>
          ))}
        </ul>
      </div>

      <Line />

      <div className="py-1">
        <h3 className="text-neutral-950 text-base font-roboto font-bold">
          Notificar cuando el stock esté por debajo de...
        </h3>
        <p className="text-neutral-950 text-sm font-roboto font-normal">{productData.lowExistence}</p>
      </div>

      <Line />
      
      <div className="flex justify-between py-1">
        <div>
          <p className="text-neutral-950 text-base font-roboto font-bold">Precio de compra</p>
          <p className="text-neutral-950 text-sm font-roboto font-normal">{productData.incomingPrice}</p>
        </div>
        <div>
          <p className="text-neutral-950 text-base font-roboto font-bold">Precio de venta</p>
          <p className="text-neutral-950 text-sm font-roboto font-normal">{productData.sellPrice}</p>
        </div>
      </div>

      {showButton && (
        <div className='flex justify-end'>
          <Button 
            onClick={onOtherBranchesClick} 
            className="mt-4 bg-blue-800 text-white hover:bg-blue-950"
            type="common"
            text="Otras sucursales"
          />
        </div>
      )}

      {showBarcodeModal && ReactDOM.createPortal(
        <BarcodeModal
          productId={productData.productCode}
          productName={productData.name}
          showModal={showBarcodeModal}
          onClose={closeBarcodeModal}
        />,
        document.body 
      )}
    </Card>
  );
};

ProductInfoCard.propTypes = {
  productData: PropTypes.shape({
    name: PropTypes.string.isRequired,
    productCode: PropTypes.string.isRequired,
    lowExistence: PropTypes.number.isRequired,
    incomingPrice: PropTypes.number.isRequired,
    sellPrice: PropTypes.number.isRequired,
  }).isRequired,
  productCategories: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
    })
  ).isRequired,
  onOtherBranchesClick: PropTypes.func,
  showButton: PropTypes.bool,
};

export default ProductInfoCard;
