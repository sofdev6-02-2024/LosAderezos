import PropTypes from "prop-types";
import { FaRegTrashAlt } from "react-icons/fa";
import { AiOutlineEdit } from "react-icons/ai";
import Button from "./Button";

export default function SubsidiaryItem({
  name,
  location,
  admin,
  onEdit,
  onDelete,
  type,
  onClick
}) {
  return (
    <div className="bg-sky-100 w-full rounded-[20px] border-blue-950 border-2 font-roboto">
      <div className="flex flex-row h-93 mx-[15px] md:mx-[40px] my-[20px] justify-between items-center">
        <div className="w-[150px] md:w-full">
          {admin ? (
            <Button onClick={onClick}>
              <p className="font-bold md:text-[20px] text-[16px] text-start">
                {name}
              </p>
            </Button>
          ) : (
            <p className="font-bold md:text-[20px] text-[16px] text-start">
              {name}
            </p>
          )}
          <div className="flex flex-row items-center space-x-2">
            <p className="">{type}</p>
            <p className="">-</p>
            <p className="">{location}</p>
          </div>
        </div>
        <div className="flex flex-row items-center space-x-2 md:space-x-10">
          {admin ? (
            <div className="flex flex-row space-x-2 md:space-x-10">
              <Button onClick={onEdit}>
                <AiOutlineEdit className="text-[20px] md:text-[40px]" />
              </Button>
              <Button onClick={onDelete}>
                <FaRegTrashAlt className="text-[20px] md:text-[40px]" />
              </Button>
            </div>
          ) : (
            <></>
          )}
        </div>
      </div>
    </div>
  );
}

SubsidiaryItem.propTypes = {
  name: PropTypes.string,
  location: PropTypes.string,
  type: PropTypes.string,
  price: PropTypes.number,
  quantity: PropTypes.number,
  admin: PropTypes.bool,
  onEdit: PropTypes.func,
  onDelete: PropTypes.func,
  onClick: PropTypes.func,
};
