import PropTypes from "prop-types";
import { FaPlus, FaMinus } from "react-icons/fa";
import Button from "./Button";

export default function QuantityInput({ value, setValue, maxValue }) {
  const onClickAdd = () => {
    if (!maxValue) setValue(value + 1);
    if (maxValue >= value + 1) setValue(value + 1);
  };

  const onClickMinus = () => {
    if (value > 0) setValue(value - 1);
  };

  const onChangeValue = (e) => {
    const val = parseInt(e.target.value);

    if (isNaN(val)) {
      return;
    }
    if (!maxValue) setValue(val);
    if (maxValue >= val) setValue(val);
  };

  return (
    <div className="flex items-center h-[40px] justify-between w-[120px] rounded-full border border-black p-2 bg-white">
      <Button onClick={onClickMinus}>
        <FaMinus className="text-gray-700 hover:text-gray-950" />
      </Button>
      <input
        type="text"
        value={value}
        onChange={(e) => {
          onChangeValue(e);
        }}
        className="text-center h-fit text-[14px] md:text-[16px] w-1/2 border-none outline-none bg-transparent text-gray-900 font-normal"
      />
      <Button onClick={onClickAdd}>
        <FaPlus className="text-gray-700 hover:text-gray-950" />
      </Button>
    </div>
  );
}

QuantityInput.propTypes = {
  value: PropTypes.number,
  setValue: PropTypes.func,
  maxValue: PropTypes.number,
};
