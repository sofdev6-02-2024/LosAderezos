
export default function NotFound() {  
  return (
    <div className='flex items-center justify-center min-h-screen w-full p-4 lg:p-8'>
      <div className='flex flex-col items-center justify-center w-full max-w-4xl space-y-8 lg:space-y-20'>
        <div className='flex flex-col items-center justify-center gap-5 rounded-3xl bg-blue-950 p-10 lg:p-20 text-white shadow-xl'>
          <h1 className="text-6xl lg:text-8xl font-roboto font-bold">404</h1>
          <h2 className="text-2xl lg:text-4xl font-roboto font-semibold">Page not found</h2>
        </div>
      </div>
    </div>
  );
}
  