import { IoMdBarcode } from "react-icons/io";
import { MdAdd } from "react-icons/md";
import ProductItem from "../components/ProductItem";
import Button from "../components/Button";
import { useEffect, useState } from "react";
import { deleteProduct, getProducts } from "../services/ProductService";
import SearchBar from "../components/SearchBar";
import { useUser } from "../hooks/UserUser";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import Modal from "../components/Modal";
import GeneratePDFButton from '../components/GeneratePDFButton';

export default function ProductsPage() {
  const { user } = useUser();
  const [products, setProducts] = useState([]);
  const [productsSearchList, setProductsSearchList] = useState([]);
  const [filteredProducts, setFilteredProducts] = useState([]);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [productToDelete, setProductToDelete] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchProducts() {
      try {
        const fetchedProducts = await getProducts(user.subsidiaryId);
        const filteredList = fetchedProducts.map(
          (p) => `${p.name} - (${p.productCode})`
        );
        setProducts(fetchedProducts);
        setFilteredProducts(fetchedProducts);
        setProductsSearchList(filteredList);
      } catch (error) {
        console.error("Error fetching products", error);
      }
    }

    fetchProducts();
  }, [user]);

  const searchProduct = (text) => {
    if (text.trim()) {
      const lowerCaseText = text.toLowerCase();

      const filtered = products.filter(
        (p) =>
          p.name.toLowerCase().includes(lowerCaseText) ||
          p.productCode.toLowerCase().includes(lowerCaseText)
      );
      setFilteredProducts(filtered);
    } else {
      setFilteredProducts(products);
    }
  };

  const selectProductSearch = (text) => {
    if (text.trim()) {
      const lowerCaseText = text.toLowerCase();

      const filtered = products.filter(
        (p) =>
          lowerCaseText.includes(p.name.toLowerCase()) ||
          lowerCaseText.includes(p.productCode.toLowerCase())
      );
      setFilteredProducts(filtered);
    } else {
      setFilteredProducts(products);
    }
  };

  const handleEdit = (productId) => {
    navigate(`/edit-product/${productId}`);
  };

  const handleDeleteClick = (productId) => {
    setIsModalVisible(true);
    setProductToDelete(productId);
  };

  const handleConfirmDelete = async () => {
    try {
      await deleteProduct(productToDelete);
      const updatedProducts = products.filter(
        (product) => product.productId !== productToDelete
      );
      setProducts(updatedProducts);
      setFilteredProducts(updatedProducts);
      setProductsSearchList(
        updatedProducts.map((p) => `${p.name} - (${p.productCode})`)
      );
      setIsModalVisible(false);
      toast.success("Producto eliminado correctamente");
    } catch (error) {
      console.error("Error deleting product", error);
      toast.error("Hubo un error al eliminar el producto");
    }
  };

  return (
    <div
      className="flex flex-col space-y-5 py-10 w-full items-center font-roboto"
      style={{ height: "calc(100vh - 150px)" }}
    >
      <p className="font-roboto font-bold text-[24px]">Productos</p>
      <div className="flex md:flex-row flex-col space-y-5 justify-between w-4/5">
        <div className="md:w-2/3">
          <SearchBar
            items={productsSearchList}
            onSearch={searchProduct}
            onItemClicked={selectProductSearch}
          />
        </div>

        {/* Botones en vista móvil */}
        <div className="md:hidden flex flex-row justify-between space-x-4 w-full">
          <Button
            className="bg-neutral-200 justify-center hover:bg-neutral-300 rounded-xl items-center w-[92px] h-[32px]"
          >
            <IoMdBarcode size={20} />
          </Button>
          {user.UserRol === "Propietario" ? (
            <Button
              text={"Añadir"}
              className="bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2"
              type={"common"}
              onClick={() => {
                navigate("/add-product");
              }}
            >
              <MdAdd size={19} />
            </Button>
          ) : (
            <div className="w-0 bg-orange-400"></div>
          )}
          <GeneratePDFButton
            products={filteredProducts}
            className="bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2"
          />
        </div>

        <div className="md:flex hidden justify-end space-x-4">
          <Button
            className="bg-neutral-200 md:flex justify-center items-center hover:bg-neutral-300 rounded-xl w-[92px] h-[32px]"
          >
            <IoMdBarcode size={20} />
          </Button>
          {user.UserRol === "Propietario" && (
            <Button
              text={"Añadir"}
              className="bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2"
              type={"common"}
              onClick={() => {
                navigate("/add-product");
              }}
            >
              <MdAdd size={19} />
            </Button>
          )}
          <GeneratePDFButton
            products={filteredProducts}
            className="bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2"
          />
        </div>
      </div>
      <div className="flex flex-col space-y-5 overflow-y-scroll w-4/5">
        {filteredProducts.map((item, index) => (
          <ProductItem
            key={index}
            name={item.name || "Unknown product"}
            barcode={item.productCode || "Unknown code"}
            price={item.sellPrice || 0}
            quantity={item.quantity || 0}
            admin={user.UserRol === "Propietario"}
            onEdit={() => handleEdit(item.productId)}
            onDelete={() => handleDeleteClick(item.productId)}
            link={`/products/${item.productId}`}
          />
        ))}
      </div>
      <Modal
        isVisible={isModalVisible}
        onClose={() => setIsModalVisible(false)}
        width="max-w-sm"
        height="h-auto"
      >
        <div className="p-6">
          <p className="font-roboto font-medium text-lg">
            ¿Estás seguro de que quieres eliminar este producto?
          </p>
          <div className="flex justify-center mt-5">
            <Button
              type="common"
              className="bg-blue-800 text-white hover:bg-blue-950 px-4 py-2"
              onClick={handleConfirmDelete}
            >
              Confirmar
            </Button>
          </div>
        </div>
      </Modal>
    </div>
  );
}
