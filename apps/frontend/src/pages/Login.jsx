import Button from '../components/Button';
import LoginImage from '../assets/Login-image.png'
import Logo from '../assets/Logo.png';
import Google from "../assets/googleLogo.png"

function Login() {
  const handleGoogleLogin = () => {
    window.location.href = "http://localhost:8000/auth/google";
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
          <Button 
            type='common'
            className="rounded-xl w-full h-11 items-center justify-center space-x-2 bg-white hover:bg-neutral-200 shadow-lg"
            onClick={handleGoogleLogin}>
            <img src={Google} 
                alt="Google logo" 
                className="w-6 h-6" />
            <span className="font-roboto font-semibold ">Continuar con Google</span>
          </Button>
        </div>
      </div>
    </div>
  );
}

export default Login;
