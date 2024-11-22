import { FaBoxOpen } from "react-icons/fa";
import { CgLoadbarDoc } from "react-icons/cg";
import { FaPlus } from "react-icons/fa6";
import { FaMinus } from "react-icons/fa";
import { FaRegUser } from "react-icons/fa6";
import CardButton from "../components/CardButton";
import { useNavigate } from 'react-router-dom';

function StoreMenu() {
  const handleButtonClick = (label) => {
    alert(`${label} clicked!`);
  };

  const navigate = useNavigate();

  return (
    <div className="flex items-center justify-center min-h-screen w-full p-40">
      <div className="flex flex-col items-center justify-center w-full max-w-5xl space-y-8 sm:space-y-36">
        <div className="flex flex-col sm:flex-row justify-center space-x-0 sm:space-x-48 space-y-8 sm:space-y-0">
          <CardButton 
            icon={FaBoxOpen} 
            label="Productos" 
            onClick={() => navigate('/products')}
          />
          <CardButton 
            icon={CgLoadbarDoc} 
            label="Reportes" 
            onClick={() => handleButtonClick("Reportes")}
          />
        </div>
        
        <div className="flex flex-col sm:flex-row justify-center space-x-0 sm:space-x-48 space-y-8 sm:space-y-0">
          <CardButton 
            icon={FaPlus} 
            label="Nueva entrada" 
            onClick={() => navigate('/in-products')}
          />
          <CardButton 
            icon={FaMinus} 
            label="Nueva salida" 
            onClick={() => navigate('/out-products')}
          />
          <CardButton 
            icon={FaRegUser} 
            label="Usuarios" 
            onClick={() => navigate('/users')}
          />
        </div>
      </div>
    </div>
  );
}

export default StoreMenu;
