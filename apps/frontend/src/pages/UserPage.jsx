import { useEffect, useState } from "react";
import Button from "../components/Button";
import SearchBar from "../components/SearchBar";
import UserItem from "../components/UserItem";
import { FaPlus } from "react-icons/fa6";
import { useNavigate } from "react-router-dom";
import { useUser } from "../hooks/UserUser";
import { getUsersBySubsidiaryId, updateUser } from "../services/UserService";

export default function UserPage() {
  const myUser = useUser();
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const data = ["Administrador de sucursal", "Operador"];
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchProducts() {
      try {
        const fetchedUsers = await getUsersBySubsidiaryId(myUser.subsidiaryId);

        setUsers(fetchedUsers);
      } catch (error) {
        console.error("Error fetching users:", error);
      } finally {
        setLoading(false);
      }
    }

    fetchProducts();
  }, [myUser.subsidiaryId]);

  const updateRol = async (newRole, index) => {
    const previousUsers = [...users];
    const updatedUsers = users.map((user, i) =>
      i === index ? { ...user, rol: newRole } : user
    );
    setUsers(updatedUsers);

    try {
      await updateUser(updatedUsers[index]);
    } catch (error) {
      console.error(error.response?.data?.message || "Error al actualizar rol");
      setUsers(previousUsers);
    }
  };

  if (loading) {
    return <p>Cargando usuarios...</p>;
  }

  return (
    <div
      className="flex flex-col space-y-5 py-10 w-full items-center font-roboto"
      style={{ height: "calc(100vh - 150px)" }}
    >
      <div className="flex w-4/5 flex-row justify-between md:justify-center items-center font-roboto">
        <p className="font-roboto font-bold text-[24px]">Usuarios</p>
        <Button
          onClick={() => {
            navigate("/addUsers");
          }}
          text={"Añadir"}
          className={
            "bg-[#E5E5E5] block md:hidden justify-center hover:bg-[#A3A3A3] w-[92px] h-[32px] text-[14px]"
          }
          type={"common"}
        >
          <FaPlus />
        </Button>
      </div>
      <div className="flex flex-row w-4/5 justify-between md:justify-center py-10 space-x-7 items-center font-roboto">
        <SearchBar />
        <Button
          onClick={() => {
            navigate("/addUsers");
          }}
          text={"Añadir"}
          className={
            "bg-[#E5E5E5] md:inline-flex hidden justify-center hover:bg-[#A3A3A3] w-[92px] h-[32px] text-[14px]"
          }
          type={"common"}
        >
          <FaPlus />
        </Button>{" "}
      </div>
      <div className="w-full flex-1 space-y-5 overflow-y-scroll flex flex-col items-center">
        {users.map((user, index) => (
          <div key={index} className="w-4/5">
            <UserItem
              className="w-4/5"
              user={user.name}
              hasRol
              rolOption={user.rol}
              onChange={(rol) => {
                updateRol(rol, index);
              }}
              data={data}
            />
          </div>
        ))}
      </div>
    </div>
  );
}
