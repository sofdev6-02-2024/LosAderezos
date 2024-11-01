import { FaRegUser } from "react-icons/fa6";


export default function HeaderNoBussines()
{

  return(
    <div className="h-[150px] w-full bg-blue-950 items-center ">
      <div className="grid grid-cols-3  w-full h-full items-center px-9">
      <div></div>
        <div className="flex flex-col justify-center w-full font-roboto space-y-3">
          <p className="text-[32px] text-white font-medium md:font-bold w-full text-center truncate">
            Easy Box
          </p>
        </div>
        <div className="flex flex-row w-full justify-end">
          <FaRegUser size={40} color="white" />
        </div>
      </div>
    </div>
  )
}