import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import ProductInfoCard from "../components/ProductInfoCard";
import { getProductById, getProductBranches } from "../services/ProductService";
import GenericList from "../components/GenericList";
import BranchItem from "../components/BranchItem";
import { useUser } from "../hooks/UserUser";

function SingleProductPage() {
  const { id } = useParams();
  const [productData, setProductData] = useState(null);
  const [branches, setBranches] = useState(null);
  const [branchesLoaded, setBranchesLoaded] = useState(false);
  const user = useUser();

  useEffect(() => {
    async function fetchProduct() {
      try {
        const product = await getProductById(user.subsidiaryId, id);
        setProductData(product);
      } catch (error) {
        console.error("Error fetching product data", error);
      }
    }

    fetchProduct();
  }, [user, id]);

  async function fetchProductBranches() {
    try {
      const branchesData = await getProductBranches(user.companyId, id);
      setBranches(branchesData);
      setBranchesLoaded(true);
    } catch (error) {
      console.error("Error fetching branches", error);
    }
  }

  if (!productData) {
    return <div className="flex justify-center items-center h-full text-2xl font-roboto font-bold">Loading...</div>;
  }

  return (
    <div className="flex flex-col lg:flex-row items-center justify-center lg:h-screen lg:py-0 px-6 pt-32 pb-10 space-y-4 lg:space-x-16">
      <ProductInfoCard
        productData={productData}
        productCategories={productData.categories}
        onOtherBranchesClick={fetchProductBranches}
        showButton={!branchesLoaded}
      />
      {branches && (
        <div className="w-full max-w-xl">
        {branches.length > 0 ? (
            <div className="lg:h-[650px] overflow-y-scroll">
              <GenericList
                items={branches}
                renderItem={(branch) => <BranchItem branch={branch} />}
              />
            </div>
          ) : (
            <p className="text-center text-neutral-700">No se encontró el producto en otras sucursales.</p>
          )}
      </div>
      )}
    </div>
  );
}

export default SingleProductPage;
