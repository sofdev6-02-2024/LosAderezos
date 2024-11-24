import { IoMdBarcode } from "react-icons/io";
import { FaPlus } from "react-icons/fa6";
import ProductItem from "../components/ProductItem";
import Button from "../components/Button";
import { useEffect, useState } from "react";
import { getProducts } from "../services/ProductService";
import SearchBar from "../components/SearchBar";
import { Link } from "react-router-dom";
import { useUser } from "../hooks/UserUser";
import { useNavigate } from "react-router-dom";
import BarcodeScannerModal from "../components/BarcodeScannerModal";

export default function ProductsPage()
{
  const user = useUser();
  const [products, setProducts] = useState([]);
  const [isScannerModalOpen, setIsScannerModalOpen] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchProducts() {
      try {
        const fetchedroducts = await getProducts(user.subsidiaryId);
        setProducts(fetchedroducts);
      } catch (error) {
        console.error('Error fetching products', error)
      }
    }

    fetchProducts();
  }, [user])

  function transformToGuid(code) {
    if (code.length !== 32) {
      console.warn("Código no tiene el tamaño esperado para un GUID:", code);
      return code; 
    }
  
    return `${code.slice(0, 8)}-${code.slice(8, 12)}-${code.slice(12, 16)}-${code.slice(16, 20)}-${code.slice(20)}`;
  }
  

  const handleScan = (scannedCode) => {
    console.log("Código escaneado:", scannedCode);
  
    const formattedCode = transformToGuid(scannedCode);
    console.log("Código formateado como GUID:", formattedCode);

    if (formattedCode) {
      navigate(`/products/${formattedCode}`);
    } else {
      alert("Producto no encontrado. URL llamada:", `/products/${formattedCode}`);
    }
  
    setIsScannerModalOpen(false); 
  };
  

  return(
    <div className="flex flex-col space-y-5 py-10 w-full items-center font-roboto">
      <p className="font-roboto font-bold text-[24px]">Productos</p>
      <div className="flex md:flex-row flex-col space-y-5 justify-between w-4/5">
        <div className="md:w-2/3">
          <SearchBar />
        </div>
        <div className="md:hidden flex flex-row justify-between w-full">
          <Button onClick={() => setIsScannerModalOpen(true)}>
              <IoMdBarcode size={40}/>
            </Button>
            <Button 
              text={'Añadir'} 
              className={'bg-[#E5E5E5] hover:bg-[#A3A3A3] w-[92px] h-[32px] text-[14px]'} 
              type={'common'}
              onClick={() => {
                navigate("/add-product");
              }}
            >
              <FaPlus />
          </Button>
        </div>
        <Button className={'hidden md:block'} onClick={() => setIsScannerModalOpen(true)}>
          <IoMdBarcode size={40}/>
        </Button>
        <div className="hidden md:block">
          <Button 
            text={'Añadir'} 
            className={'bg-[#E5E5E5] justify-center hover:bg-[#A3A3A3] w-[92px] h-[32px] text-[14px]'} 
            type={'common'}
            onClick={() => {
              navigate("/add-product");
            }}
          >
            <FaPlus />
          </Button>
        </div>
      </div>
      <div className="space-y-5 w-4/5">
        {products.map((item, index) => (
          <Link key={index} to={`/products/${item.productId}`}>
            <ProductItem
              key = {index} 
              name={item.name || 'Unkown product'} 
              barcode={item.productCode || 'Unkown code'} 
              price={item.sellPrice || 0}
              quantity={item.quantity || 0}
              admin
              />
          </Link>
        ))}
      </div>
      <BarcodeScannerModal
        isVisible={isScannerModalOpen}
        onClose={() => setIsScannerModalOpen(false)}
        onScan={handleScan}
      />
    </div>
  )
}
