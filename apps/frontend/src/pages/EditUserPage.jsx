import { useUser } from "../hooks/UserUser";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import InputField from "../components/InputField";
import { parsePhoneNumberFromString } from "libphonenumber-js";
import { MdAdd, MdOutlineCancel } from "react-icons/md";
import Button from "../components/Button";
import { updateUser } from "../services/UserService";

const validationSchema = Yup.object().shape({
  name: Yup.string().required("Este campo no puede estar vacío"),
  phoneNumber: Yup.string()
    .test(
      "isValidPhone",
      "Número de teléfono no válido, debe incluir el código de área",
      (value) => validatePhoneNumber(value)
    )
    .nullable(),
});

const validatePhoneNumber = (phone) => {
  if (typeof phone !== "string" || phone.trim() === "") {
    return false;
  }
  const phoneNumber = parsePhoneNumberFromString(phone);
  return phoneNumber ? phoneNumber.isValid() : false;
};

export default function EditUserPage() {
  const { user, editUser } = useUser();
  const [day, month, year] = user.UserBirthDate.split("-");
  const date = `${year}-${month}-${day}`;
  const initialValues = {
    name: user.UserName || "",
    phoneNumber: user.UserPhoneNumber || "",
    birthDate: date || "",
  };

  const submit = async (values, { resetForm }) => {
    try {
      await updateUser(user.userId, values);
      const [newDay, newMonth, newYear] = values.birthDate.split("-");
      const newDate = `${newYear}-${newMonth}-${newDay}`;

      editUser({
        ...user,
        UserName: values.name,
        UserPhoneNumber: values.phoneNumber,
        UserBirthDate: newDate,
      });
      resetForm({ values });
    } catch (error) {
      console.error("Error al acualizar datos de usuario", error);
    }
  };

  return (
    <div className="flex flex-col justify-center items-center font-roboto h-[calc(100vh-150px)] py-5">
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={submit}
      >
        {({ errors, touched, isSubmitting, resetForm }) => (
          <Form className="w-4/5 md:w-1/2 lg:w-1/3 space-y-10 justify-center items-center">
            <p className="font-bold text-2xl w-full text-center">
              {user.UserRol}
            </p>

            <div className="w-full flex flex-col items-start justify-start">
              <span className="text-sm text-neutral-950 font-bold">Email:</span>
              <p>{user.UserEmail}</p>
            </div>
            <InputField
              id="name"
              label="Nombre"
              name="name"
              placeholder="Nombre de usuario"
              type="text"
              isCorrect={!(errors.name && touched.name)}
            />
            {touched.name && errors.name && (
              <div className="text-red-500 text-sm">{errors.name}</div>
            )}

            <InputField
              id="phoneNumber"
              label="Número de celular"
              name="phoneNumber"
              placeholder="Ej. +521234567890"
              type="text"
              isCorrect={!(errors.phoneNumber && touched.phoneNumber)}
            />
            {touched.phoneNumber && errors.phoneNumber && (
              <div className="text-red-500 text-sm">{errors.phoneNumber}</div>
            )}

            <InputField
              id="birthDate"
              label="Fecha de nacimiento"
              name="birthDate"
              placeholder=""
              type="date"
              isCorrect={true}
            />

            {touched.birthDate || touched.name || touched.phoneNumber ? (
              <div className="flex flex-col md:flex-row justify-center gap-4 mt-4">
                <Button
                  type="common"
                  isSubmit
                  className="bg-green-600 font-roboto font-medium text-lg text-white rounded-xl px-6 py-2 flex items-center gap-2"
                  disabled={isSubmitting}
                >
                  Aceptar
                  <MdAdd size={19} />
                </Button>
                <Button
                  type="common"
                  className="bg-red-600 font-roboto font-medium text-lg text-white rounded-xl px-6 py-2 flex items-center gap-2"
                  onClick={() => {
                    resetForm({ values: initialValues });
                  }}
                >
                  Cancelar
                  <MdOutlineCancel size={19} />
                </Button>
              </div>
            ) : (
              <></>
            )}
          </Form>
        )}
      </Formik>
    </div>
  );
}
