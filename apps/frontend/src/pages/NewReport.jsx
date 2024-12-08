import { Formik, Form } from "formik";
import * as Yup from "yup";
import InputField from "../components/InputField";
import Button from "../components/Button";
import { MdAdd, MdOutlineCancel } from "react-icons/md";
import DropDown from "../components/DropDown";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";

const ReportSchema = Yup.object().shape({
  startDate: Yup.date().required("La fecha de inicio es obligatoria"),
  endDate: Yup.date().required("La fecha de finalización es obligatoria"),
  type: Yup.string().required("El tipo de reporte es obligatorio"),
});

function NewReport() {
  const navigate = useNavigate();

  const handleSubmit = (values) => {
    try {
      console.log("Datos del reporte:", values);
      toast.success("Reporte creado correctamente");
      navigate('/reports', {
        state: {
          startDate: values.startDate,
          endDate: values.endDate,
          type: values.type,
        }
      });
    } catch (error) {
      console.error("Error al crear el reporte:", error);
      toast.error("Hubo un error al procesar su solicitud. Por favor, inténtelo de nuevo.");
    }
  };

  return (
    <div className="flex flex-col items-center w-full p-14 space-y-16"
      style={{ height: "calc(100vh - 150px)" }}
    >
      <h2 className="text-2xl font-roboto font-bold text-center mb-6">Reportes</h2>
      <Formik
        initialValues={{
          startDate: "",
          endDate: "",
          type: "Tipo",
        }}
        validationSchema={ReportSchema}
        onSubmit={handleSubmit}
      >
        {({ errors, touched, setFieldValue, values }) => (
          <Form className="flex flex-col gap-4 w-full max-w-lg mx-auto p-6">
            <InputField
              id="startDate"
              label="Fecha de inicio"
              name="startDate"
              placeholder="Ingrese la fecha"
              type="date"
              isCorrect={!(errors.startDate && touched.startDate)}
              isRequired
            />
            {touched.startDate && errors.startDate && (
              <div className="text-red-500 text-sm">{errors.startDate}</div>
            )}

            <InputField
              id="endDate"
              label="Fecha de final"
              name="endDate"
              placeholder="Ingrese la fecha"
              type="date"
              isCorrect={!(errors.endDate && touched.endDate)}
              isRequired
            />
            {touched.endDate && errors.endDate && (
              <div className="text-red-500 text-sm">{errors.endDate}</div>
            )}

            <DropDown
              data={["Entradas", "Salidas", "Entradas/Salidas", "Ganancias/Perdidas"]}
              option={values.type}
              onChange={(option) => setFieldValue("type", option)}
              canChange
              setOption={(option) => setFieldValue("Tipo", option)}
              isSelected={values.type !== ""}
            />
            {touched.type && errors.type && (
              <div className="text-red-500 text-sm">{errors.type}</div>
            )}

            <div className="flex justify-center gap-4 mt-6">
              <Button
                isSubmit
                type="common"
                className="bg-[#16a34a] font-roboto font-medium text-xl text-white rounded-xl px-6 py-2 flex items-center gap-2"
              >
                Crear
                <MdAdd size={19} />
              </Button>
              <Button
                type="common"
                className="bg-red-600 font-roboto font-medium text-xl text-white rounded-xl px-6 py-2 flex items-center gap-2"
                onClick={() => {
                  navigate("/store-menu");
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

export default NewReport;
