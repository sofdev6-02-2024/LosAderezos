import { IoIosArrowDropleft } from "react-icons/io";
import { IoIosArrowDropdown } from "react-icons/io";
import { useState } from 'react';
import Button from "./Button";

export default function DropDown()
{
  const [isOpen, setIsOpen] = useState(false);
  const [selected, setSelected] = useState(false);
  const [text, setText] = useState("Select");

  const handleOptionClick = (option) => {
    setText(option);
    setSelected(true);
    setIsOpen(false);
  };

  return(
    <div className={`relative ${isOpen? 'rounded-t-[8px]': 'rounded-[8px]'} py-[10px] inline-block w-2/3 bg-white items-center`} >
      <span className="flex justify-between px-[10px]">
        <p className={`${selected? 'text-black': 'text-[#737373]'} font-medium text-[16ps] truncate `}>{text}</p>
        <Button onClick={() => {setIsOpen(!isOpen)}}>
          {isOpen? <IoIosArrowDropdown size={20} className="font-bold"/> : <IoIosArrowDropleft size={20} className="font-bold"/>}
        </Button>
      </span>
      
      {isOpen && (
        <div className="w-full bg-white absolute items-center px-[10px] shadow-lg rounded-b-[8px] pb-[10px]">
          <Button
          className={'hover:bg-sky-100 rounded-[4px] w-full px-[4px] text-left break-all'} 
          onClick={() => {handleOptionClick('Administrador de sucursal')}}
          >
            Administrador de sucursal
          </Button>
          <Button
          className={'hover:bg-sky-100 rounded-[4px] w-full px-[4px] text-left break-all'} 
          onClick={() => {handleOptionClick('Operador')}}
          >
            Operador
          </Button>
        </div>
      )}    
    </div>
  ) 
}