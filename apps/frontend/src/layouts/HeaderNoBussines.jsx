import { FaRegUser } from "react-icons/fa6";
import Button from "../components/Button";
import { useNavigate } from "react-router-dom";

export default function HeaderNoBussines() {
  const navigate = useNavigate();
  return (
    <div className="h-[150px] w-full bg-blue-950 items-center ">
      <div className="grid grid-cols-3  w-full h-full items-center px-9">
        <div></div>
        <div className="flex flex-col justify-center w-full font-roboto space-y-3">
          <p className="text-[32px] text-white font-medium md:font-bold w-full text-center truncate">
            Easy Box
          </p>
        </div>
        <div className="flex flex-row w-full justify-end">
          <Button
            className={"md: m-10"}
            onClick={() => {
              navigate("/my-user");
            }}
          >
            <FaRegUser className="size-[30px] md:size-[40px]" color="white" />
          </Button>{" "}
        </div>
      </div>
    </div>
  );
}
