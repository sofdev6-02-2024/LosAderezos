import Button from "../components/Button";
import Line from "../components/Line";
import { IoMdAdd } from "react-icons/io";

export default function NoCompanyPage() {
  return (
    <div className="w-full flex flex-col font-roboto justify-center items-center" style={{ height: "calc(100vh - 150px)" }}>
      <div className="flex flex-col justify-center items-center space-y-5 w-fit">
        <p className="text-[32px] font-bold">
          Aun no formas parte de una empresa?
        </p>
        <Button
          className={
            "bg-blue-800 font-roboto font-medium text-xl text-white rounded-xl px-6 py-2 flex items-center gap-2"
          }
        >
          Crear nueva empresa
          <IoMdAdd />
        </Button>
        <div className="flex items-center justify-center w-full gap-[9px]">
          <div className="flex-grow">
            <Line />
          </div>
          <p className="font-roboto font-normal text-xs">O</p>
          <div className="flex-grow">
            <Line />
          </div>
        </div>
        <p className="text-[32px] font-bold">
          Pide a alguien que te agregue a una
        </p>
      </div>
    </div>
  );
}
