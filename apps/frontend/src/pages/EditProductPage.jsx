import { useState, useEffect } from "react";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import InputField from "../components/InputField";
import Button from "../components/Button";
import GenericList from "../components/GenericList";
import { MdAdd, MdOutlineCancel, MdSave } from "react-icons/md";
import { FaMinus } from "react-icons/fa";
import { getProductById, updateProduct, updateProductCategories } from "../services/ProductService";
import { createCategory, getAllCategories } from "../services/CategoryService";
import { useNavigate, useParams } from "react-router-dom";
import { toast } from "sonner";
import { useUser } from "../hooks/UserUser";

const EditProductSchema = Yup.object().shape({
  name: Yup.string().required("El nombre del producto es obligatorio"),
  code: Yup.string().notRequired(),
  buyPrice: Yup.number()
    .required("El precio de compra es obligatorio")
    .min(1, "Debe ser mayor o igual a 1"),
  sellPrice: Yup.number()
    .required("El precio de venta es obligatorio")
    .min(1, "Debe ser mayor o igual a 1"),
  lowStock: Yup.number()
    .min(0, "Debe ser mayor o igual a 0")
    .notRequired(),
  lowStockEnabled: Yup.boolean(),
});

function EditProductPage() {
  const { id } = useParams();
  const { user } = useUser();
  const navigate = useNavigate();
  const [productData, setProductData] = useState(null);
  const [selectedCategories, setSelectedCategories] = useState([]);
  const [lowStockEnabled, setLowStockEnabled] = useState(false);
  const [availableCategories, setAvailableCategories] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [filteredCategories, setFilteredCategories] = useState([]);
  const [highlightedIndex, setHighlightedIndex] = useState(-1);

  useEffect(() => {
    async function fetchData() {
      try {
        const fetchedProduct = await getProductById(user.subsidiaryId, id);
        setProductData(fetchedProduct);
        setLowStockEnabled(!!fetchedProduct.lowExistence);

        const fetchedCategories = await getAllCategories();
        setAvailableCategories(fetchedCategories);

        setSelectedCategories(fetchedProduct.categories.map(cat => cat.name));
      } catch (error) {
        console.error('Error fetching product data', error);
      }
    }

    fetchData();
  }, [id, user.subsidiaryId]);

  useEffect(() => {
    const filtered = availableCategories.filter((category) =>
      category.name.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredCategories(filtered);
  }, [searchTerm, availableCategories]);

  const handleAddCategory = async (categoryName) => {
    if (categoryName.trim() !== "") {
      if (selectedCategories.some((cat) => cat.toLowerCase() === categoryName.toLowerCase())) {
        toast.warning("La categoría ya está seleccionada");
        return;
      }

      const existingCategory = availableCategories.find(
        (cat) => cat.name.toLowerCase() === categoryName.toLowerCase()
      );

      if (existingCategory) {
        setSelectedCategories([...selectedCategories, existingCategory.name]);
      } else {
        try {
          const newCategory = await createCategory({ name: categoryName });
          setAvailableCategories([...availableCategories, newCategory]);
          setSelectedCategories([...selectedCategories, newCategory.name]);
          toast.success("Nueva categoría creada y añadida");
        } catch (err) {
          console.error("Error al crear categoría:", err);
          toast.error("Hubo un error al crear la categoría. Por favor, inténtelo de nuevo.");
        }
      }
    }
  };

  const handleRemoveCategory = (index) => {
    const updatedCategories = selectedCategories.filter((_, i) => i !== index);
    setSelectedCategories(updatedCategories);
  };

  const handleSubmit = async (values) => {
    if (selectedCategories.length === 0) {
      toast.error("Debe seleccionar al menos una categoría antes de continuar");
      return;
    }

    try {
      const updatedProduct = {
        name: values.name,
        code: values.code,
        incomingPrice: values.buyPrice,
        sellPrice: values.sellPrice,
        companyId: user.companyId,
        lowExistence: lowStockEnabled ? values.lowStock : 0,
        notify: values.lowStockEnabled,
      };

      await updateProduct(id, updatedProduct);

      const selectedCategoryIds = availableCategories
        .filter((category) => selectedCategories.includes(category.name))
        .map((category) => category.categoryId);

      await updateProductCategories(selectedCategoryIds, id);

      toast.success("Producto actualizado correctamente");
      navigate("/products");
    } catch (error) {
      console.error("Error updating product:", error);
      toast.error("Hubo un error al actualizar el producto.");
    }
  };

  if (!productData) return <div>Cargando...</div>;

  return (
    <div className="p-14 max-w-screen-lg mx-auto space-y-16">
      <h2 className="text-xl font-roboto font-bold text-center mb-6">Editar Producto</h2>

      <Formik
        initialValues={{
          name: productData.name,
          code: productData.productCode || "",
          buyPrice: productData.incomingPrice,
          sellPrice: productData.sellPrice,
          lowStock: productData.lowExistence || 0,
          lowStockEnabled: productData.notify || false,
        }}
        validationSchema={EditProductSchema}
        onSubmit={handleSubmit}
      >
        {({ values, setFieldValue, errors, touched }) => (
          <Form className="grid grid-cols-1 gap-6 lg:grid-cols-2">
            <div className="flex flex-col gap-2">
              <InputField
                id="name"
                label="Nombre"
                name="name"
                placeholder="Ingrese el nombre aquí"
                type="text"
                isCorrect={!(errors.name && touched.name)}
                isRequired={true}
              />
              {touched.name && errors.name && (
                <div className="text-red-500 text-sm">{errors.name}</div>
              )}
              <InputField
                id="code"
                label="Código del producto"
                name="code"
                placeholder="Ingrese el código del producto aquí"
                type="text"
                isCorrect={!(errors.code && touched.code)}
                isRequired={false}
              />
              {touched.code && errors.code && (
                <div className="text-red-500 text-sm">{errors.code}</div>
              )}
              <InputField
                id="buyPrice"
                label="Costo de compra"
                name="buyPrice"
                placeholder="Ingrese costo de compra aquí"
                type="number"
                isCorrect={!(errors.buyPrice && touched.buyPrice)}
                isRequired={true}
              />
              {touched.buyPrice && errors.buyPrice && (
                <div className="text-red-500 text-sm">{errors.buyPrice}</div>
              )}
              <InputField
                id="sellPrice"
                label="Costo de venta"
                name="sellPrice"
                placeholder="Ingrese costo de venta aquí"
                type="number"
                isCorrect={!(errors.sellPrice && touched.sellPrice)}
                isRequired={true}
              />
              {touched.sellPrice && errors.sellPrice && (
                <div className="text-red-500 text-sm">{errors.sellPrice}</div>
              )}
            </div>

            <div className="flex flex-col gap-4">
              <div className="flex items-center gap-2">
                <label htmlFor="lowStockCheckbox" className='font-roboto font-normal text-sm'>
                  Notificar baja existencia
                </label>
                <input
                  id="lowStockCheckbox"
                  type="checkbox"
                  checked={values.lowStockEnabled}
                  onChange={() => setFieldValue('lowStockEnabled', !values.lowStockEnabled)}
                  className="w-5 h-5 border-2 border-neutral-200 rounded-md checked:bg-neutral-950 focus:outline-neutral-950"
                />
              </div>

              {values.lowStockEnabled && (
                <InputField
                  id="lowStock"
                  label="Notificar cuando el stock esté debajo de:"
                  name="lowStock"
                  placeholder="Ingrese la cantidad aquí"
                  type="number"
                  isCorrect={!(errors.lowStock && touched.lowStock)}
                />
              )}

              <div>
              <div className='flex flex-row items-center justify-between pb-2'>
                  <label className="block mb-2 font-roboto font-normal text-sm ">Categorías</label>
                  <Button
                    type="common"
                    className="bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2"
                    onClick={() => {
                      const input = document.querySelector("[placeholder='Ingrese una categoría']");
                      if (input.value.trim() !== "") {
                        handleAddCategory(input.value.trim());
                        input.value = "";
                      }
                    }}
                  >
                    Añadir
                    <MdAdd size={19} />
                  </Button>
                </div>
                <div className="relative">
                  <input
                    type="text"
                    placeholder="Ingrese una categoría"
                    className="bg-white w-full h-12 px-5 py-3 font-roboto rounded-[10px] border-2 border-neutral-200 focus:ring-blue-800 focus:border-blue-800"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    onKeyDown={(e) => {
                      if (e.key === "Enter" && searchTerm.trim() !== "") {
                        e.preventDefault();
                        handleAddCategory(searchTerm);
                        setSearchTerm("");
                      }
                    }}
                  />
                  {searchTerm.trim() && filteredCategories.length > 0 && (
                    <ul className="absolute top-full left-0 w-full bg-white border border-neutral-200 rounded-lg shadow-md max-h-40 overflow-y-auto z-10">
                      {filteredCategories.map((cat, index) => (
                        <li
                          key={cat.categoryId}
                          className={`px-4 py-2 cursor-pointer ${
                            highlightedIndex === index ? "bg-neutral-200" : "hover:bg-neutral-100"
                          }`}
                          onClick={() => {
                            handleAddCategory(cat.name);
                            setSearchTerm("");
                          }}
                          onMouseEnter={() => setHighlightedIndex(index)}
                        >
                          {cat.name}
                        </li>
                      ))}
                    </ul>
                  )}
                </div>
                <GenericList
                  items={selectedCategories}
                  renderItem={(category, index) => (
                    <div className="flex justify-between items-center bg-white w-full h-12 pl-5 py-3 border-2 border-neutral-200 rounded-[10px]">
                      <span>{category}</span>
                      <Button 
                        type="common"
                        className="text-neutral-950"
                        onClick={() => handleRemoveCategory(index)}
                      >
                        <FaMinus size={18} />
                      </Button>
                    </div>
                  )}
                />
              </div>
            </div>

            <div className="col-span-1 lg:col-span-2 flex justify-center gap-4 mt-4">
              <Button 
                isSubmit 
                type="common"
                className="bg-blue-800 font-roboto font-medium text-xl text-white rounded-xl px-6 py-2 flex items-center gap-2"
              >
                Guardar 
                <MdSave size={19} />
              </Button>
              <Button 
                type="common"
                className="bg-red-600 font-roboto font-medium text-xl text-white rounded-xl px-6 py-2 flex items-center gap-2" 
                onClick={() => navigate("/products")}>
                Cancelar 
                <MdOutlineCancel size={19} />
              </Button>
            </div>
          </Form>
        )}
      </Formik>
    </div>
  );
}

export default EditProductPage;
