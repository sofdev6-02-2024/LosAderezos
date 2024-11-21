import Button from "../components/Button";
import { IoMdBarcode } from "react-icons/io";
import SearchBar from "../components/SearchBar";
import { useState } from "react";
import InOutProduct from "../components/InOutProduct";
import { IoMdAdd } from "react-icons/io";
import { MdOutlineCancel } from "react-icons/md";
import { useNavigate } from "react-router-dom";

export default function InProductPage() {
  const [products, setProducts] = useState([]);
  const navigate = useNavigate();

  const onSearch = (text) => {
    if (!text) return;

    const code = parseInt(text)
    const existingProduct = products.find((p) => p.code === code);

    if (existingProduct) {
      const updatedProducts = products.map((p) =>
        p.code === code ? { ...p, quantity: p.quantity + 1 } : p
      );
      setProducts(updatedProducts);
    } else {
      const newProduct = {
        name: "New Product",
        code,
        sellPrice: 20,
        quantity: 1,
      };
      setProducts([...products, newProduct]);
    }
  };

  const manageQuantity = (quantity, index) => {
    const updatedProducts = products.map((p, i) =>
      i === index ? { ...p, quantity: quantity } : p
    );
    setProducts(updatedProducts);
  };

  const handleDel = (index) => {
    const updatedProducts = products.filter((_, i) => i !== index);
    setProducts(updatedProducts);
  };

  const submit = async () => {
    console.log(products)
    navigate("/store_menu");
  };

  return (
    <div
      className="flex flex-col space-y-5 py-10 w-full items-center font-roboto"
      style={{ height: "calc(100vh - 150px)" }}
    >
      <div className="flex w-4/5 flex-row justify-between md:justify-center items-center font-roboto">
        <p className="font-roboto font-bold text-[24px]">Nueva entrada</p>
        <Button
          className={
            "bg-[#E5E5E5] block md:hidden justify-center hover:bg-[#A3A3A3] w-[92px] h-[32px] text-[14px]"
          }
          type={"common"}
        >
          <IoMdBarcode />
        </Button>
      </div>
      <div className="flex flex-row w-4/5 justify-between md:justify-center py-10 space-x-7 items-center font-roboto">
        <SearchBar onSearch={onSearch} />
        <Button
          className={
            "bg-[#E5E5E5] md:inline-flex hidden justify-center hover:bg-[#A3A3A3] w-[92px] h-[32px] text-[14px]"
          }
          type={"common"}
        >
          <IoMdBarcode />
        </Button>
      </div>
      <div className="w-full flex flex-col space-y-7 flex-1 overflow-y-scroll items-center">
        {products.map((p, index) => (
          <div key={p.code} className="w-4/5">
            <InOutProduct
              name={p.name}
              barcode={p.code}
              price={p.sellPrice}
              quantity={p.quantity}
              setQuantity={(q) => {
                manageQuantity(q, index);
              }}
              onDelete={() => handleDel(index)}
            />
          </div>
        ))}
      </div>
      <div className=" w-4/5 md:w-1/3 flex flex-row justify-between py-4">
        <Button
          onClick={submit}
          className={
            "bg-[#16A34A] w-2/5 py-2 items-start justify-center text-white font-medium text-[20px] rounded-[12px]"
          }
        >
          Aceptar
          <IoMdAdd />
        </Button>
        <Button
          className={
            "bg-red-600 w-2/5 py-2 items-start justify-center text-white font-medium text-[20px] rounded-[12px]"
          }
          onClick={() => {
            navigate("/store_menu");
          }}
        >
          Cancelar
          <MdOutlineCancel />
        </Button>
      </div>
    </div>
  );
}
