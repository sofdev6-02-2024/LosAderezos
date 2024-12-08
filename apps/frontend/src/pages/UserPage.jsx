import { useEffect, useState } from "react";
import Button from "../components/Button";
import SearchBar from "../components/SearchBar";
import UserItem from "../components/UserItem";
import { FaPlus } from "react-icons/fa6";
import { useNavigate } from "react-router-dom";
import { useUser } from "../hooks/UserUser";
import Modal from "../components/Modal";
import { toast } from "sonner";
import {
  getUsersBySubsidiaryId,
  updateUserList,
} from "../services/UserService";
import { removeUserFromSubsidiary } from "../services/ProductService";

export default function UserPage() {
  const { user } = useUser();
  const [users, setUsers] = useState([]);
  const [filteredUsers, setFilteredUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [usersSeachrList, setUsersSeachrList] = useState([]);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [userToDelete, setUserToDelete] = useState(null);
  const data = ["Administrador de sucursal", "Operador"];
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchProducts() {
      try {
        const fetchedUsers = await getUsersBySubsidiaryId(user.subsidiaryId);
        const filteredList = fetchedUsers.map(
          (u) => `${u.name} - (${u.email})`
        );
        setUsers(fetchedUsers);
        setFilteredUsers(fetchedUsers);
        setUsersSeachrList(filteredList);
      } catch (error) {
        console.error("Error fetching users:", error);
      } finally {
        setLoading(false);
      }
    }

    fetchProducts();
  }, [user.subsidiaryId]);

  const updateRol = async (newRole, index) => {
    const previousUsers = [...users];
    const updatedUsers = users.map((u, i) =>
      i === index ? { ...u, rol: newRole } : u
    );
    setUsers(updatedUsers);

    try {
      await updateUserList([updatedUsers[index]]);
    } catch (error) {
      console.error(error.response?.data?.message || "Error al actualizar rol");
      setUsers(previousUsers);
    }
  };

  if (loading) {
    return <p>Cargando usuarios...</p>;
  }

  const searchUsers = (text) => {
    if (text.trim()) {
      const lowerCaseText = text.toLowerCase();

      const filtered = users.filter(
        (u) =>
          u.name.toLowerCase().includes(lowerCaseText) ||
          u.email.toLowerCase().includes(lowerCaseText)
      );
      setFilteredUsers(filtered);
    } else {
      setFilteredUsers(users);
    }
  };

  const selectUserSearch = (text) => {
    if (text.trim()) {
      const lowerCaseText = text.toLowerCase();

      const filtered = users.filter(
        (u) =>
          lowerCaseText.includes(u.name.toLowerCase()) ||
          lowerCaseText.includes(u.email.toLowerCase())
      );
      setFilteredUsers(filtered);
    } else {
      setFilteredUsers(users);
    }
  };

  const handleDeleteClick = (userId) => {
    setIsModalVisible(true);
    setUserToDelete(userId);
  };

  const handleConfirmDelete = async () => {
    const userToRemove = {
      userId: userToDelete,
      subsidiaryId: user.subsidiaryId,
    };
    try {
      await removeUserFromSubsidiary(userToRemove);
      const updatedUsers = users.filter((u) => u.userId !== userToDelete);
      setUsers(updatedUsers);
      setFilteredUsers(updatedUsers);
      const filteredList = updatedUsers.map((u) => `${u.name} - (${u.email})`);
      setUsersSeachrList(filteredList);
      setIsModalVisible(false);
      toast.success("Usuario removido correctamente");
    } catch (error) {
      console.error("Error removing user", error);
      toast.error("Hubo un error al remover el usuario");
    }
  };

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
            "bg-neutral-200 hover:bg-neutral-300 block md:hidden justify-center font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 items-center gap-2"
          }
          type={"common"}
        >
          <FaPlus />
        </Button>
      </div>
      <div className="flex flex-row w-4/5 justify-between py-2 space-x-4 items-center font-roboto">
        <div className="flex-1">
          <SearchBar
            items={usersSeachrList}
            onSearch={searchUsers}
            onItemClicked={selectUserSearch}
          />
        </div>
        <Button
          onClick={() => {
            navigate("/addUsers");
          }}
          text={"Añadir"}
          className={
            "bg-neutral-200 hover:bg-neutral-300 md:inline-flex hidden justify-center font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 items-center gap-2"
          }
          type={"common"}
        >
          <FaPlus />
        </Button>
      </div>
      <div className="w-full flex-1 space-y-5 overflow-y-scroll flex flex-col items-center">
        {filteredUsers.map((u, index) => (
          <div key={index} className="w-4/5">
            <UserItem
              className="w-4/5"
              user={u.name}
              hasRol
              rolOption={u.rol}
              onChange={(rol) => {
                updateRol(rol, index);
              }}
              canDelete={user.UserRol === "Propietario"}
              data={data}
              canChange={user.UserRol === "Propietario"}
              onDelete={() => handleDeleteClick(u.userId)}
            />
          </div>
        ))}
      </div>
      <Modal
        isVisible={isModalVisible}
        onClose={() => setIsModalVisible(false)}
        width="max-w-sm"
        height="h-auto"
      >
        <div className="p-6">
          <p className="font-roboto font-medium text-lg">
            ¿Estás seguro de que quieres eliminar este usuario?
          </p>
          <div className="flex justify-center mt-5">
            <Button
              type="common"
              className="bg-blue-800 text-white hover:bg-blue-950 px-4 py-2"
              onClick={handleConfirmDelete}
            >
              Confirmar
            </Button>
          </div>
        </div>
      </Modal>
    </div>
  );
}
