import PropTypes from "prop-types";
import { FaRegTrashAlt } from "react-icons/fa";
import DropDown from "./DropDown";
import Button from "./Button";
import { useState } from "react";

export default function UserItem({ user, onDelete, onChange, data }) {
  const [option, setOption] = useState('Select')

  return (
    <div className="bg-sky-100 w-full rounded-[20px] border-blue-950 border-2 font-roboto">
      <div className="flex flex-row h-93 mx-[15px] md:mx-[40px] my-[20px] justify-between items-center">
        <p className="font-bold md:text-[20px] text-[16px] text-start truncate">
          {user}
        </p>
        <div className="flex flex-row justify-between w-1/2 md:w-1/3">
          <Button onClick={onDelete}>
            <FaRegTrashAlt size={40} />
          </Button>
          <DropDown
            onChange={onChange}
            data={data}
            option={option}
            setOption={setOption}
          />
        </div>
      </div>
    </div>
  );
}

UserItem.propTypes = {
  user: PropTypes.string,
  onDelete: PropTypes.func,
  onChange: PropTypes.func,
  data: PropTypes.array
};