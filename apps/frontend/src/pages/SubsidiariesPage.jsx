import { MdAdd } from "react-icons/md";
import Button from "../components/Button";
import { useEffect, useState } from "react";
import { deleteSubsidiary, getSubsidiaries } from "../services/ProductService";
import SearchBar from "../components/SearchBar";
import { useUser } from "../hooks/UserUser";
import { toast } from "sonner";
import Modal from "../components/Modal";
import SubsidiaryItem from "../components/SubsidiaryItem";
import { useNavigate } from "react-router-dom";

export default function SubsidiariesPage() {
  const { user, editUser } = useUser();
  const [subsidiaries, setSubsidiaries] = useState([]);
  const [subsidiariesSearchList, setSubsidiariesSearchList] = useState([]);
  const [filteredSubsidiaries, setFilteredSubsidiaries] = useState([]);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [subsidiaryToDelete, setSubsidiaryToDelete] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchSubsidiaries() {
      try {
        const fetchedSubsidiaries = await getSubsidiaries(user.companyId);
        const filteredList = fetchedSubsidiaries.map(
          (s) => `${s.name} - ${s.location}`
        );
        setSubsidiaries(fetchedSubsidiaries);
        setFilteredSubsidiaries(fetchedSubsidiaries);
        setSubsidiariesSearchList(filteredList);
      } catch (error) {
        console.error("Error fetching subsidiaries", error);
        toast.error(
          "No se pudieron cargar las sucursales. Intente nuevamente más tarde."
        );
      }
    }

    if (user && user.companyId) {
      fetchSubsidiaries();
    }
  }, [user]);

  const searchSubsidiary = (text) => {
    if (text.trim()) {
      const lowerCaseText = text.toLowerCase();

      const filtered = subsidiaries.filter(
        (s) =>
          s.name.toLowerCase().includes(lowerCaseText) ||
          s.location.toLowerCase().includes(lowerCaseText)
      );
      setFilteredSubsidiaries(filtered);
    } else {
      setFilteredSubsidiaries(subsidiaries);
    }
  };

  const selectSubsidiarySearch = (text) => {
    if (text.trim()) {
      const lowerCaseText = text.toLowerCase();

      const filtered = subsidiaries.filter(
        (s) =>
          lowerCaseText.includes(s.name.toLowerCase()) ||
          lowerCaseText.includes(s.location.toLowerCase())
      );
      setFilteredSubsidiaries(filtered);
    } else {
      setFilteredSubsidiaries(subsidiaries);
    }
  };

  const handleDeleteClick = (subsidiaryId) => {
    setSubsidiaryToDelete(subsidiaryId);
    setIsModalVisible(true);
  };

  const handleConfirmDelete = async () => {
    try {
      await deleteSubsidiary(subsidiaryToDelete);
      const updatedSubsidiaries = subsidiaries.filter(
        (s) => s.subsidiaryId !== subsidiaryToDelete
      );
      setSubsidiaries(updatedSubsidiaries);
      setFilteredSubsidiaries(updatedSubsidiaries);
      setSubsidiariesSearchList(
        updatedSubsidiaries.map((s) => `${s.name} - ${s.location}`)
      );
      setIsModalVisible(false);
      toast.success("Sucursal eliminada correctamente");
    } catch (error) {
      console.error("Error deleting subsidiary", error);
      toast.error("Hubo un error al eliminar la sucursal");
    }
  };

  const setUserSubsidiary = async (subsidiaryId) => {
    await editUser({
      ...user,
      subsidiaryId: subsidiaryId,
    });
    
    navigate("/store-menu");
  };

  return (
    <div
      className="flex flex-col space-y-5 py-10 w-full items-center font-roboto"
      style={{ height: "calc(100vh - 150px)" }}
    >
      <p className="font-roboto font-bold text-[24px]">Sucursales</p>
      <div
        className={`flex md:flex-row flex-col space-y-5 justify-between w-4/5`}
      >
        <div className="md:w-2/3">
          <SearchBar
            items={subsidiariesSearchList}
            onSearch={searchSubsidiary}
            onItemClicked={selectSubsidiarySearch}
          />
        </div>
        <div className="md:hidden flex flex-row justify-between w-full">
          {user.UserRol === "Propietario" ? (
            <Button
              text={"Añadir"}
              className={`bg-neutral-200  ${
                user.UserRol === "Propietario" ? "" : "hidden"
              } hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2`}
              type={"common"}
            >
              <MdAdd size={19} />
            </Button>
          ) : (
            <div className="w-0 bg-orange-400"></div>
          )}
        </div>
        <div
          className={`hidden ${
            user.UserRol === "Propietario" ? "md:block" : ""
          }`}
        >
          {user.UserRol === "Propietario" ? (
            <Button
              text={"Añadir"}
              className={
                "bg-neutral-200 hover:bg-neutral-300 font-roboto font-bold text-sm text-neutral-950 rounded-xl pl-4 pr-4 py-2 flex items-center gap-2"
              }
              type={"common"}
            >
              <MdAdd size={19} />
            </Button>
          ) : (
            <div className="w-0 bg-orange-400"></div>
          )}
        </div>
      </div>
      <div className="flex flex-col space-y-5 overflow-y-scroll w-4/5">
        {filteredSubsidiaries.map((sub, index) => (
          <SubsidiaryItem
            key={index}
            name={sub.name || "Unknown subsidiary"}
            location={sub.location || "Unknown location"}
            admin={user.UserRol === "Propietario"}
            type={sub.type || "Unknown type"}
            onDelete={() => handleDeleteClick(sub.subsidiaryId)}
            onClick={() => setUserSubsidiary(sub.subsidiaryId)}
          />
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
            ¿Estás seguro de que quieres eliminar esta sucursal?
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
