import { IoMdArrowBack } from "react-icons/io";
import { CgBell } from "react-icons/cg";
import Button from "../components/Button";
import { useNavigate, useLocation } from 'react-router-dom';
import PropTypes from 'prop-types';

export default function HeaderBussines({bussines, branch})
{
  const navigate = useNavigate();
  const location = useLocation();

  return(
    <div className="grid grid-cols-3 bg-blue-950 h-[150px] w-full items-center ">
      <div className="w-full m-10">
        {location.pathname === '/store_menu' ? (
          <></>
        ) : (
          <Button 
          onClick={() => {
            navigate('/store_menu')
          }}>
            <IoMdArrowBack size={40} color="white"/>
          </Button>
        )}
      </div>
      <div className="flex flex-col justify-center w-full font-roboto space-y-3">
        <p className="text-[32px] text-white font-medium md:font-bold w-full text-center truncate">
          {bussines}
        </p>
        <Button className={'w-full bg-white justify-center py-[8px] text-[20px] font-bold rounded-[10px] truncate'}
        onClick={() => {
          navigate('/branches')
        }}
        >
          {branch}
        </Button>
      </div>
      <div className="flex flex-row w-full justify-end">
        <Button className={'m-10'}
        onClick={() => {
          navigate('/notifications')
        }}
        >
          <CgBell size={40} color="white" />
        </Button>
      </div>
    </div>
  )
}

HeaderBussines.propTypes = {
  bussines: PropTypes.string,
  branch: PropTypes.string,
}
