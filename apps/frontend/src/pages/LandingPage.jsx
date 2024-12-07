import { useUser } from "../hooks/UserUser";
import NoCompanyPage from "./NoCompanyPage";
import StoreMenu from "./StoreMenu";

export default function LandingPage() {
  const { user } = useUser();
  return <div>{user.companyID == "" ? <NoCompanyPage /> : <StoreMenu />}</div>;
}
