import HeaderNoBussines from "./HeaderNoBussines";
import HeaderBussines from "./HeaderBussines";
import { getCompanyById, getSubsidiaryById } from "../services/ProductService";
import { useEffect, useState } from "react";
import { useUser } from "../hooks/UserUser";

export default function Header() {
  const { user } = useUser();
  const [subsidiary, setSubsidiary] = useState(null);
  const [company, setCompany] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (!user || !user.subsidiaryId || !user.companyId) {
      setLoading(false);
      return;
    }

    async function fetchData() {
      try {
        const [fetchedCompany, fetchedSubsidiary] = await Promise.all([
          getCompanyById(user.companyId),
          getSubsidiaryById(user.subsidiaryId),
        ]);

        setSubsidiary(fetchedSubsidiary.name);
        setCompany(fetchedCompany.name);
      } catch (error) {
        console.error("Error fetching data", error);
      } finally {
        setLoading(false);
      }
    }

    setLoading(true);
    fetchData();
  }, [user]);

  if (loading) {
    return (
      <div className="sticky top-0 bg-gray-100 p-4 text-center">
        Cargando encabezado...
      </div>
    );
  }

  return (
    <div className="sticky top-0 z-50">
      {subsidiary && company ? (
        <HeaderBussines branch={subsidiary} bussines={company} />
      ) : (
        <HeaderNoBussines />
      )}
    </div>
  );
}
