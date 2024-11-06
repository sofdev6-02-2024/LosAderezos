import { Form as FormFormik, Formik } from 'formik';
import { useState } from "react";
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import Button from '../components/Button';
import InputField from '../components/InputField';
import { login } from '../services/LoginService';
import LoginImage from '../assets/Login-image.png'
import Logo from '../assets/Logo.png';
import { IoMdEyeOff } from "react-icons/io";
import { IoMdEye } from "react-icons/io";
import Line from '../components/Line';
import Google from "../assets/googleLogo.png"

function Login() {
  const [isPasswordVisible, setIsPasswordVisible] = useState(false);
  const [setFormStatus] = useState({ success: null, message: '' });
  const navigate = useNavigate();
  const [initialValues] = useState({
    email: '',
    password: '',
  });

  const validationSchema = Yup.object().shape({
    email: Yup.string().email('No es un email válido')
      .required('El email es obligatorio'),
    password: Yup.string()
      .required('El password es obligatorio')
  });

  const handleSubmit = async (values, { setSubmitting }) => {
    try {
      const validateResponse = await login({
        email: values.email,
        password: values.password,
      });    
      
      setFormStatus({ success: true, message: 'Inicio de sesión exitoso con éxito' });
      navigate('/', {
        state: {
          email: validateResponse.email,
          sessionId: values.sessionId
        },
      });
    } catch (error) {
      setFormStatus({ success: false, message: error.message });
    } finally {
      setSubmitting(false);
    }
  };

  const handleGoogleLogin = () => {
    window.location.href = "http://localhost:8000/auth/google";
  };

  const handleRegisterClick = () => {
    navigate('/register');
  };

  return (
    <div className="flex flex-row items-center justify-between h-screen w-full bg-neutral-200">
      <div className='flex w-full h-screen justify-center items-center'>
        <img src={LoginImage} alt="Inventory image" />
      </div>
      <div className='flex flex-col items-center justify-center h-screen w-[552px] lg:rounded-l-3xl p-12 bg-white'>
        <div className='w-[456px] space-y-4'>
          <img src={Logo} alt="Logo image" />
          <p className='font-roboto font-medium text-5xl text-center'> Inicio de Sesión </p>
          <Formik
              initialValues={initialValues}
              enableReinitialize={true}
              validationSchema={validationSchema}
              onSubmit={handleSubmit}
            >
              {({ errors, touched, isSubmitting }) => (
                <FormFormik className="flex flex-col gap-1">
                  <InputField
                    id="email"
                    name="email"
                    label="Email"
                    type="text"
                    placeholder="Ingrese su email"
                    withIcon={false}
                    isCorrect={!touched.email || !errors.email}
                  />
                  {touched.email && errors.email && (
                    <div className="text-red-500 text-sm">{errors.email}</div>
                  )}
                  <InputField
                    id="password"
                    name="password"
                    label="Contraseña"
                    type={isPasswordVisible ? 'text' : 'password'}
                    placeholder="Ingrese su contraseña"
                    icon={isPasswordVisible ? <IoMdEyeOff size={20} /> : <IoMdEye size={20} />}
                    iconPosition='right'
                    onIconClick={() => setIsPasswordVisible(!isPasswordVisible)}
                    isCorrect={!touched.password || !errors.password}
                  />
                  {touched.password && errors.password && (
                    <div className="text-red-500 text-sm">{errors.password}</div>
                  )}
                  <Button type="common" isSubmit className="rounded-xl w-full h-11 bg-blue-800 font-roboto justify-center text-white" disabled={isSubmitting}>
                    {isSubmitting ? 'Enviando...' : 'Iniciar Sesión'}
                  </Button>
                </FormFormik>
              )}
          </Formik>
          <div className="flex items-center justify-center gap-[9px]">
            <div className="flex-grow">
              <Line />
            </div>
            <p className="font-roboto font-normal text-xs">O</p>
            <div className="flex-grow">
              <Line />
            </div>
          </div>
          <Button 
            type='common'
            className="rounded-xl w-full h-11 items-center justify-center space-x-2 bg-white hover:bg-neutral-200 shadow-lg"
            onClick={handleGoogleLogin}>
            <img src={Google} 
                alt="Google logo" 
                className="w-6 h-6" />
            <span className="font-roboto font-semibold ">Continuar con Google</span>
          </Button>
          <div className="flex flex-col items-center justify-center gap-y-1">
            <p className="font-roboto font-normal text-sm text-neutral-500">Aun no tienes una cuenta?</p>
            <p className="font-roboto font-normal text-sm text-blue-500 cursor-pointer"
              onClick={handleRegisterClick}
            >
              Registrate aquí
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;
