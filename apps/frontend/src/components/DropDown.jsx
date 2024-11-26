import PropTypes from "prop-types";
import { IoIosArrowDropleft } from "react-icons/io";
import { IoIosArrowDropdown } from "react-icons/io";
import { useState } from "react";
import Button from "./Button";

export default function DropDown({
  onChange,
  data,
  option,
  setOption,
  isSelected,
  canChange,
}) {
  const [isOpen, setIsOpen] = useState(false);
  const [selected, setSelected] = useState(isSelected);

  const handleOptionClick = (option) => {
    setOption(option);
    setSelected(true);
    setIsOpen(false);
    onChange(option);
  };

  return (
    <div
      className={`relative ${
        isOpen ? "rounded-t-[8px]" : "rounded-[8px]"
      } py-[10px] inline-block w-2/3 bg-white items-center`}
    >
      <span className="flex justify-between px-[10px]">
        <p
          className={`${
            selected || !canChange ? "text-black" : "text-[#737373]"
          } font-medium text-[16ps] truncate `}
        >
          {option}
        </p>
        {canChange ? (
          <Button
            onClick={() => {
              setIsOpen(!isOpen);
            }}
          >
            {isOpen ? (
              <IoIosArrowDropdown size={20} className="font-bold" />
            ) : (
              <IoIosArrowDropleft size={20} className="font-bold" />
            )}
          </Button>
        ) : (
          <></>
        )}
      </span>

      {isOpen && data && (
        <div className="w-full bg-white absolute items-center px-[10px] shadow-lg rounded-b-[8px] pb-[10px]">
          {data.map((option, index) => (
            <Button
              key={index}
              className={
                "hover:bg-sky-100 rounded-[4px] w-full px-[4px] text-left break-all"
              }
              onClick={() => {
                handleOptionClick(option);
              }}
            >
              {option}
            </Button>
          ))}
        </div>
      )}
    </div>
  );
}

DropDown.propTypes = {
  onChange: PropTypes.func,
  data: PropTypes.array,
  option: PropTypes.string,
  setOption: PropTypes.func,
  isSelected: PropTypes.bool,
  canChange: PropTypes.bool,
};
