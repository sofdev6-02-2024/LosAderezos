import { useState } from "react";
import UserItem from "../components/UserItem";
import SearchBar from "../components/SearchBar";
import Button from "../components/Button";
import { IoMdAdd } from "react-icons/io";
import { MdOutlineCancel } from "react-icons/md";
import { useNavigate } from "react-router-dom";
import { getUserByGmail, updateUser } from "../services/UserService";
import { addUsersToSubsidiary } from "../services/ProductService";
import { useUser } from "../hooks/UserUser";

export default function AddUser() {
  const [users, setUsers] = useState([]);
  const navigate = useNavigate();
  const myUser = useUser()

  const handleAdd = async (input) => {
    if (input.trim()) {
      const user = await getUserByGmail(input);
      if (!user) return;
      setUsers([...users, user]);
    }
  };

  const handleDel = (index) => {
    const updatedUsers = users.filter((_, i) => i !== index);
    setUsers(updatedUsers);
  };

  const onChange = (index, option) => {
    const updatedUsers = users.map((user, i) =>
      i === index ? { ...user, rol: option } : user
    );
    setUsers(updatedUsers);
  };

  const addUsers = async () => {
    const UserIds = users.map((user) => user.userId);

    const request = {
      UserIds,
      SubsidiaryId: myUser.subsidiaryId,
    };

    try {
      await addUsersToSubsidiary(request);
    } catch (error) {
      throw new Error(
        error.response?.data?.message || "Error al añadir los usuarios"
      );
    }
  };

  const updateRoles = () => {
    try {
      users.forEach(async user => {
        await updateUser(user);
      });
    } catch (error) {
      throw new Error(
        error.response?.data?.message || "Error al añadir los usuarios"
      );
    }
  }

  const submit = async () => {
    for (var i = 0; i < users.length; i++) {
      if (users[i].rol === "default") {
        return;
      }
    }

    addUsers();
    updateRoles();
    navigate("/users")    
  };

  const data = ["Administrador de sucursal", "Operador"];

  return (
    <div className="flex flex-col items-center h-screen w-full space-y-10 py-10">
      <p className="font-roboto font-bold text-[24px]">Agregar Usuarios</p>
      <div className="w-4/5 md:w-1/2">
        <SearchBar onSearch={handleAdd} />
      </div>
      <div className="w-4/5 space-y-7 h-1/2 overflow-y-scroll">
        {users.map((user, index) => (
          <UserItem
            key={index}
            user={user.name}
            data={data}
            onDelete={() => handleDel(index)}
            onChange={(newRole) => onChange(index, newRole)}
            rolOption="Select"
            hasRol={false}
          />
        ))}
      </div>
      <div className=" w-4/5 md:w-1/3 flex flex-row justify-between">
        <Button
          onClick={submit}
          className={
            "bg-[#16A34A] w-2/5 py-2 items-start justify-center text-white font-medium text-[20px] rounded-[12px]"
          }
        >
          Aceptar
          <IoMdAdd />
        </Button>
        <Button
          className={
            "bg-red-600 w-2/5 py-2 items-start justify-center text-white font-medium text-[20px] rounded-[12px]"
          }
          onClick={() => {navigate('/users')}}
        >
          Cancelar
          <MdOutlineCancel />
        </Button>
      </div>
    </div>
  );
}
