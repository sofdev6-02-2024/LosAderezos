import PropTypes from 'prop-types';
import { FaEdit, FaDownload } from 'react-icons/fa';

const ProductInfoCard = ({ productData, onOtherBranchesClick }) => {
  return (
    <div className="bg-white shadow-lg p-6 rounded-lg max-w-lg mx-auto md:max-w-3xl">
      <div className="flex items-center justify-between border-b pb-4">
        <h2 className="text-xl font-semibold">{productData.name}</h2>
        <FaEdit className="text-gray-500 cursor-pointer hover:text-blue-500" />
      </div>

      <div className="flex items-center justify-between border-b py-4">
        <div>
          <p className="text-gray-600 text-sm">Código de barras</p>
          <p className="text-lg font-medium">{productData.barcode}</p>
        </div>
        <FaDownload className="text-gray-500 cursor-pointer hover:text-blue-500" />
      </div>

      <div className="border-b py-4">
        <h3 className="text-sm font-medium text-gray-600">Categorías</h3>
        <ul className="list-disc ml-6 text-sm text-gray-800">
          {productData.categories.map((category, index) => (
            <li key={index}>{category}</li>
          ))}
        </ul>
      </div>

      <div className="border-b py-4">
        <h3 className="text-sm font-medium text-gray-600">
          Notificar cuando el stock esté por debajo de...
        </h3>
        <p className="text-lg font-medium">{productData.lowStockNotification}</p>
      </div>

      <div className="flex justify-between py-4">
        <div>
          <p className="text-sm font-medium text-gray-600">Precio de compra</p>
          <p className="text-lg font-medium">{productData.purchasePrice}</p>
        </div>
        <div>
          <p className="text-sm font-medium text-gray-600">Precio de venta</p>
          <p className="text-lg font-medium">{productData.salePrice}</p>
        </div>
      </div>

      <div className="flex justify-end mt-4">
        <button
          className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition duration-300"
          onClick={onOtherBranchesClick}
        >
          Otras sucursales
        </button>
      </div>
    </div>
  );
};

ProductInfoCard.propTypes = {
  productData: PropTypes.shape({
    name: PropTypes.string.isRequired,
    barcode: PropTypes.string.isRequired,
    categories: PropTypes.arrayOf(PropTypes.string).isRequired,
    lowStockNotification: PropTypes.number.isRequired,
    purchasePrice: PropTypes.string.isRequired,
    salePrice: PropTypes.string.isRequired,
  }).isRequired,
  onOtherBranchesClick: PropTypes.func,
};

ProductInfoCard.defaultProps = {
  onOtherBranchesClick: () => {},
};

export default ProductInfoCard;
