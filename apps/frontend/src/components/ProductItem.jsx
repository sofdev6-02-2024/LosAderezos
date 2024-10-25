import PropTypes from 'prop-types';
import { FaBarcode } from "react-icons/fa6";
import { FaRegTrashAlt } from "react-icons/fa";
import { AiOutlineEdit } from "react-icons/ai";
import Button from './Button';


export default function ProductItem({name, barcode, price, quantity, admin})
{
  return (
    <div className="bg-sky-100 w-full rounded-[20px] cursor-pointer border-blue-950 border-2 font-roboto">
      <div className='flex flex-row h-93 mx-[15px] md:mx-[40px] my-[20px] justify-between items-center'>
        <div className="w-[150px] md:w-full">
          <p className='font-bold md:text-[20px] text-[16px] text-start'>{name}</p>
          <div className='flex flex-row items-center space-x-2'>
            <FaBarcode className='text-[20px]'/>
            <p className="">{barcode}</p>
          </div>
        </div>
        <div className='flex flex-row items-center space-x-2 md:space-x-10'>
          {admin?
            <div className='flex flex-row space-x-2 md:space-x-10'>
              <Button>
                <FaRegTrashAlt className='text-[20px] md:text-[40px]'/>
              </Button>
              <Button>
                <AiOutlineEdit className='text-[20px] md:text-[40px]'/>
              </Button>
            </div>
            :
            <></>
          }
          <p className='font-bold md:text-[24px] text-[14px]'>{price}$</p>
          <p className='font-bold md:text-[24px] text-[14px]'>{quantity}</p>
        </div>
      </div>
    </div>
  )
}

ProductItem.propTypes = {
  name: PropTypes.string,
  barcode: PropTypes.number,
  price: PropTypes.number,
  quantity: PropTypes.number,
  admin: PropTypes.bool,
};