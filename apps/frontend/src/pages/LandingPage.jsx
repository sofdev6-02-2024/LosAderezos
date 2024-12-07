import { useUser } from "../hooks/UserUser";
import NoCompanyPage from "./NoCompanyPage";
import StoreMenu from "./StoreMenu";

export default function LandingPage() {
  const { user } = useUser();

  if (!user) {
    return <div>Loading...</div>;
  }

  return <div>{user.companyId === "" ? <NoCompanyPage /> : <StoreMenu />}</div>;
}
