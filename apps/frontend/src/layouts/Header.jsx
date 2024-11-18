import { useUser } from "../services/UserContext";
import HeaderNoBussines from "./HeaderNoBussines";
import HeaderBussines from "./HeaderBussines";
import { getCompanyById, getSubsidiaryById } from "../services/ProductService";

export default function Header() {
  const user = useUser();

  const getSubsidiary = async() => {
    return await getSubsidiaryById(user.subsidiaryId[0]);
  }

  const getCompany = async() => {
    return await getCompanyById(user.companyId);
  }

  return (
    <div className="sticky top-0">
      {user.subsidiaryId ? <HeaderBussines branch={getSubsidiary} bussines={getCompany}/> : <HeaderNoBussines />}
    </div>
  );
}
