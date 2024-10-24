import { FaBoxOpen } from "react-icons/fa";
import CardButton from "../components/CardButton";

function StoreMenu() {
  const handleButtonClick = (label) => {
    alert(`${label} clicked!`);
  };

  return (
    <div className="flex items-center justify-center min-h-screen w-full p-40">
      <div className="flex flex-col items-center justify-center w-full max-w-5xl space-y-8 sm:space-y-36">
        <div className="flex flex-col sm:flex-row justify-center space-x-0 sm:space-x-48 space-y-8 sm:space-y-0">
          <CardButton 
            icon={FaBoxOpen} 
            label="Productos" 
            onClick={() => handleButtonClick("Productos")}
          />
          <CardButton 
            icon={FaBoxOpen} 
            label="Reportes" 
            onClick={() => handleButtonClick("Reportes")}
          />
        </div>
        
        <div className="flex flex-col sm:flex-row justify-center space-x-0 sm:space-x-48 space-y-8 sm:space-y-0">
          <CardButton 
            icon={FaBoxOpen} 
            label="Nueva entrada" 
            onClick={() => handleButtonClick("Nueva entrada")}
          />
          <CardButton 
            icon={FaBoxOpen} 
            label="Nueva salida" 
            onClick={() => handleButtonClick("Nueva salida")}
          />
          <CardButton 
            icon={FaBoxOpen} 
            label="Usuarios" 
            onClick={() => handleButtonClick("Usuarios")}
          />
        </div>
      </div>
    </div>
  );
}

export default StoreMenu;
