import { Formik, Form } from "formik";
import * as Yup from "yup";
import InputField from "../components/InputField";
import Button from "../components/Button";
import { MdOutlineCancel, MdSave } from "react-icons/md";
import { useLocation, useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { useUser } from "../hooks/UserUser";
import { useEffect, useState } from "react";
import { getSubsidiaryById } from "../services/ProductService";
import { updateSubsidiary } from "../services/SubsidiaryService";

const EditSubsidiarySchema = Yup.object().shape({
  name: Yup.string().required("El nombre de la sucursal es obligatorio"),
  location: Yup.string().required("La dirección es obligatoria"),
  type: Yup.string(),
});

function EditSubsidiaryPage() {
  const { user } = useUser();
  const location = useLocation();
  const navigate = useNavigate();
  const { subsidiaryId } = location.state;
  const [subsidiaryData, setSubsidiaryData] = useState(null);

  useEffect(() => {
    async function fetchSubsidiary() {
      try {
        const fetchedSubsidiary = await getSubsidiaryById(subsidiaryId);
        setSubsidiaryData(fetchedSubsidiary);
      } catch (error) {
        console.error("Error al obtener los datos de la sucursal:", error);
        toast.error("Hubo un error al cargar los datos de la sucursal.");
      }
    }

    fetchSubsidiary();
  }, [subsidiaryId, user.companyId]);

  const handleSubmit = async (values) => {
    try {
      const updatedSubsidiary = {
        subsidiaryId: subsidiaryData.subsidiaryId,
        location: values.location,
        name: values.name,
        type: values.type || "",
        companyId: user.companyId,
      };
  
      await updateSubsidiary(updatedSubsidiary);
  
      toast.success("Sucursal actualizada correctamente");
      navigate("/branches");
    } catch (error) {
      console.error("Error al actualizar la sucursal:", error);
      toast.error("Hubo un error al actualizar la sucursal.");
    }
  };

  if (!subsidiaryData) return <div>Cargando...</div>;

  return (
    <div 
      className="flex flex-col items-center w-full p-14 space-y-16"
      style={{ height: "calc(100vh - 150px)" }}
    >
      <h2 className="text-2xl font-roboto font-bold text-center mb-6">Editar Sucursal</h2>
      <Formik
        initialValues={{
          name: subsidiaryData.name,
          location: subsidiaryData.location,
          type: subsidiaryData.type || "",
        }}
        validationSchema={EditSubsidiarySchema}
        onSubmit={handleSubmit}
      >
        {({ errors, touched }) => (
          <Form className="flex flex-col gap-2 w-full max-w-lg mx-auto p-6">
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
              id="location"
              label="Dirección"
              name="location"
              placeholder="Ingrese la direción aquí"
              type="text"
              isCorrect={!(errors.location && touched.location)}
              isRequired={true}
            />
            {touched.location && errors.location && (
              <div className="text-red-500 text-sm">{errors.location}</div>
            )}
            <InputField
              id="type"
              label="Tipo"
              name="type"
              placeholder="Ingrese el tipo aquí"
              type="text"
              isCorrect={!(errors.type && touched.type)}
              isRequired={false}
            />
            {touched.type && errors.type && (
              <div className="text-red-500 text-sm">{errors.type}</div>
            )}

            <div className="flex justify-center gap-4 mt-4">
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
                onClick={() => {
                  navigate("/branches");
                }}
              >
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

export default EditSubsidiaryPage;
