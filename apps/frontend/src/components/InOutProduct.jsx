import PropTypes from "prop-types";
import { FaBarcode } from "react-icons/fa6";
import { FaRegTrashAlt } from "react-icons/fa";
import Button from "./Button";
import QuantityInput from "./QuantityInput";

export default function InOutProduct({
  name,
  barcode,
  price,
  quantity,
  setQuantity,
  onDelete,
}) {
  return (
    <div className="bg-sky-100 w-full rounded-[20px] cursor-pointer border-blue-950 border-2 font-roboto">
      <div className="flex flex-row h-93 mx-[15px] md:mx-[40px] my-[20px] justify-between items-center">
        <div className="w-[150px] md:w-full">
          <p className="font-bold md:text-[20px] text-[16px] text-start">
            {name}
          </p>
          <div className="flex flex-row items-center space-x-2">
            <FaBarcode className="text-[20px]" />
            <p className="">{barcode}</p>
          </div>
        </div>
        <div className="flex flex-row items-center space-x-2 md:space-x-10">
          <div className="flex items-center flex-row space-x-2 md:space-x-10">
            <QuantityInput value={quantity} setValue={setQuantity} />
            <p className="font-bold md:text-[24px] text-[14px]">{price}$</p>
            <Button onClick={onDelete}>
              <FaRegTrashAlt className="text-[20px] md:text-[40px]" />
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}

InOutProduct.propTypes = {
  name: PropTypes.string,
  barcode: PropTypes.number,
  price: PropTypes.number,
  quantity: PropTypes.number,
  setQuantity: PropTypes.func,
  onDelete: PropTypes.func
};
