import { IoMdBarcode } from "react-icons/io";
import { MdAdd } from "react-icons/md";
import ProductItem from "../components/ProductItem";
import Button from "../components/Button";
import { useEffect, useState } from "react";
import { getProducts } from "../services/ProductService";
import SearchBar from "../components/SearchBar";
import { Link } from "react-router-dom";
import { useUser } from "../hooks/UserUser";
import { useNavigate } from "react-router-dom";

export default function ProductsPage()
{
  const user = useUser();
  const [products, setProducts] = useState([]);
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

  return(
    <div
      className="flex flex-col space-y-5 py-10 w-full items-center font-roboto"
      style={{ height: "calc(100vh - 150px)" }}
    >
      <p className="font-roboto font-bold text-[24px]">Productos</p>
      <div className="flex md:flex-row flex-col space-y-5 justify-between w-4/5">
        <div className="md:w-2/3">
          <SearchBar />
        </div>
        <div className="md:hidden flex flex-row justify-between w-full">
          <Button
            className={'bg-neutral-200 justify-center hover:bg-neutral-300 rounded-xl items-center w-[92px] h-[32px]'}
          >
            <IoMdBarcode size={20}/>
          </Button>
          <Button 
            text={'Añadir'} 
            className={'bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2'} 
            type={'common'}
            onClick={() => {
              navigate("/add-product");
            }}
          >
            <MdAdd size={19} />
          </Button>
        </div>
        <Button 
          className={
            'bg-neutral-200 md:flex hidden justify-center items-center hover:bg-neutral-300 rounded-xl w-[92px] h-[32px]'
          }
        >
          <IoMdBarcode size={20}/>
        </Button>
        <div className="hidden md:block">
          <Button 
            text={'Añadir'} 
            className={'bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2'} 
            type={'common'}
            onClick={() => {
              navigate("/add-product");
            }}
          >
            <MdAdd />
          </Button>
        </div>
      </div>
      <div className="flex flex-col space-y-5 overflow-y-scroll w-4/5">
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
    </div>
  )
}
