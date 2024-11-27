import Button from "../components/Button";
import { IoMdBarcode } from "react-icons/io";
import SearchBar from "../components/SearchBar";
import { useState, useEffect } from "react";
import InOutProduct from "../components/InOutProduct";
import { IoMdAdd } from "react-icons/io";
import { MdOutlineCancel } from "react-icons/md";
import { useNavigate } from "react-router-dom";
import { getProductByCode, getProducts, updateStocks } from "../services/ProductService";
import { useUser } from "../hooks/UserUser";

export default function InProductPage() {
  const [products, setProducts] = useState([]);
  const [total, setTotal] = useState(0);
  const [productsSearchList, setProductsSearchList] = useState([]);
  const navigate = useNavigate();
  const { user } = useUser();

  useEffect(() => {
    const totalAmount = products.reduce(
      (acc, p) => acc + p.inQuantity * p.incomingPrice,
      0
    );
    setTotal(totalAmount);
  }, [products]);

  useEffect(() => {
    async function fetchProducts() {
      try {
        const fetchedProducts = await getProducts(user.subsidiaryId);
        const formattedList = fetchedProducts.map(
          (p) => `${p.name} - (${p.productCode})`
        );
        setProductsSearchList(formattedList);
      } catch (error) {
        console.error("Error al obtener productos", error);
      }
    }
    fetchProducts();
  }, [user]);

  const onSearch = (code) => {
    const product = productsSearchList.find((item) =>
      item.includes(code)
    );

    if (product) {
      const productCode = product.match(/\(([^)]+)\)/)[1];
      addProductByCode(productCode);
    }
  };

  const addProductByCode = async (code) => {
    const existingProduct = products.find((p) => p.productCode === code);

    if (existingProduct) {
      const updatedProducts = products.map((p) => {
        return p.productCode === code
          ? {
              ...p,
              inQuantity: p.inQuantity + 1,
              quantity: p.quantity + 1,
            }
          : p;
      });
      setProducts(updatedProducts);
    } else {
      try {
        const newProduct = await getProductByCode(code, user.subsidiaryId);
        const productWithQuantity = {
          ...newProduct,
          inQuantity: 1,
          actualQuantity: newProduct.quantity,
          quantity: newProduct.quantity + 1,
        };
        setProducts([...products, productWithQuantity]);
      } catch (error) {
        console.error("No se pudo conseguir el producto", error);
      }
    }
  };

  const manageQuantity = (q, index) => {
    const updatedProducts = products.map((p, i) =>
      i === index ? { ...p, inQuantity: q, quantity: p.actualQuantity + q } : p
    );
    setProducts(updatedProducts);
  };

  const handleDel = (index) => {
    const updatedProducts = products.filter((_, i) => i !== index);
    setProducts(updatedProducts);
  };

  const submit = async () => {
    const stocks = products.map((p) => {
      return {
        stockId: p.stockId,
        code: p.code,
        quantity: p.quantity,
        productId: p.productId,
        subsidiaryId: p.subsidiaryId,
      };
    });
    try {
      await updateStocks(stocks);
    } catch (error) {
      console.error("Eror al intentar actualizar stock", error);
    }
    navigate("/store-menu");
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
            "bg-neutral-200 md:hidden justify-center hover:bg-neutral-300 w-[92px] h-[32px] text-[20px]"
          }
          type={"common"}
        >
          <IoMdBarcode />
        </Button>
      </div>
      <div className="flex flex-row w-4/5 justify-between md:justify-center py-10 space-x-7 items-center font-roboto">
        <SearchBar
          placeholder={"Buscar por codigo de barras..."}
          items={productsSearchList}
          onSearch={onSearch}
          onItemClicked={(item) => {
            const productCode = item.match(/\(([^)]+)\)/)[1];
            addProductByCode(productCode);
          }}
        />
        <Button
          className={
            "bg-neutral-200 md:inline-flex hidden justify-center hover:bg-neutral-300 w-[92px] h-[32px] text-[20px]"
          }
          type={"common"}
        >
          <IoMdBarcode />
        </Button>
      </div>
      <div className="w-full flex flex-col space-y-7 flex-1 overflow-y-scroll items-center">
        {products.map((p, index) => (
          <div key={index} className="w-4/5">
            <InOutProduct
              name={p.name}
              barcode={p.productCode}
              price={p.incomingPrice}
              quantity={p.inQuantity}
              setQuantity={(q) => {
                manageQuantity(q, index);
              }}
              onDelete={() => handleDel(index)}
              type="in"
            />
          </div>
        ))}
      </div>
      <div className=" w-4/5 md:w-1/3 flex flex-col items-center space-y-4">
        <p className="font-roboto text-2xl font-bold">
          Total: ${total.toFixed(2)}
        </p>
        <div className="flex flex-row justify-between py-4 w-full">
          <Button
            onClick={submit}
            className={
              "bg-[#16a34a] font-roboto font-medium text-xl text-white rounded-xl px-6 py-2 flex items-center gap-2"
            }
          >
            Aceptar
            <IoMdAdd />
          </Button>
          <Button
            className={
              "bg-red-600 font-roboto font-medium text-xl text-white rounded-xl px-6 py-2 flex items-center gap-2"
            }
            onClick={() => {
              navigate("/store-menu");
            }}
          >
            Cancelar
            <MdOutlineCancel />
          </Button>
        </div>
      </div>
    </div>
  );
}
