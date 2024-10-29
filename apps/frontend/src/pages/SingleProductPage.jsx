import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import ProductInfoCard from "../components/ProductInfoCard";
import { getProductById } from "../services/ProductService";

function SingleProductPage() {
  const { id } = useParams();
  const [productData, setProductData] = useState(null);

  useEffect(() => {
    async function fetchProduct() {
      try {
        const product = await getProductById(id);
        setProductData(product);
      } catch (error) {
        console.error("Error fetching product data", error);
      }
    }

    fetchProduct();
  }, [id]);

  if (!productData) {
    return <div>Loading...</div>;
  }

  return (
    <div className="flex justify-center py-10">
      <ProductInfoCard
        productData={productData}
        onOtherBranchesClick={() => console.log("Otras sucursales clickeado")}
      />
    </div>
  );
}

export default SingleProductPage;
