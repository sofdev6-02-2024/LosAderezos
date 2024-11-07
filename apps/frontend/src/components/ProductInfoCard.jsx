import { Card } from 'flowbite-react';
import PropTypes from 'prop-types';
import { RiEditLine } from "react-icons/ri";
import { AiOutlineDownload } from "react-icons/ai";
import Button from './Button';
import Line from './Line';

function ProductInfoCard ({ productData, onOtherBranchesClick = () => {}, showButton = true }) {
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
          <p className="text-neutral-950 text-base font-roboto font-normal">{productData.code}</p>
        </div>
        <AiOutlineDownload className="text-3xl lg:text-6xl mb-2 text-neutral-950 cursor-pointer hover:text-blue-800" />
      </div>

      <Line />

      <div className="py-1">
        <h3 className="text-neutral-950 text-base font-roboto font-bold">Categorías</h3>
        <ul className="list-disc ml-6 font-roboto font-normal text-sm text-neutral-950">
          {productData.categories.map((category, index) => (
            <li key={index}>{category}</li>
          ))}
        </ul>
      </div>

      <Line />

      <div className="py-1">
        <h3 className="text-neutral-950 text-base font-roboto font-bold">
          Notificar cuando el stock esté por debajo de...
        </h3>
        <p className="text-neutral-950 text-sm font-roboto font-normal">{productData.lowStockNotification}</p>
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
    </Card>
  );
};

ProductInfoCard.propTypes = {
  productData: PropTypes.shape({
    name: PropTypes.string.isRequired,
    code: PropTypes.number.isRequired,
    categories: PropTypes.arrayOf(PropTypes.string).isRequired,
    lowStockNotification: PropTypes.number.isRequired,
    incomingPrice: PropTypes.number.isRequired,
    sellPrice: PropTypes.number.isRequired,
  }).isRequired,
  onOtherBranchesClick: PropTypes.func,
  showButton: PropTypes.bool,
};

export default ProductInfoCard;