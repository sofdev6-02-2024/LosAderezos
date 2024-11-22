import axios from "axios";

export const productAPI = axios.create({
  baseURL: "http://localhost:8000/products",
});

export const getProducts = async (subsidiaryId) => {
  try {
    const response = await productAPI.get(`/Stock/subsidiary/${subsidiaryId}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir los productos de la sucursal"
    );
  }
};

export async function getProductById(subsidiaryId, productId) {
  try {
    const response = await productAPI.get(`/Stock/subsidiary/${subsidiaryId}/product/${productId}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al cargar los datos del producto"
    );
  }
}

export async function getCategoriesByProductId(productId) {
  try {
    const response = await productAPI.get(
      `/ProductCategories/product/${productId}`
    );
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al cargar los datos del producto"
    );
  }
}

export async function getProductBranches(companyId, productId) {
  try {
    const response = await productAPI.get(`/Stock/company/${companyId}/product/${productId}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message ||
        "Error al cargar las sucursales en las que hay existencias del producto"
    );
  }
}

export async function addUsersToSubsidiary(request) {
  try {
    const response = await productAPI.post("/create/list", request);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al añadir los usuarios"
    );
  }
}

export async function getSubsidiaryById(id) {
  try {
    const response = await productAPI.get(`/Subsidiary/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir subsidiaria"
    );
  }
}

export async function getCompanyById(id) {
  try {
    const response = await productAPI.get(`/Company/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir compañia"
    );
  }
}

export async function getProductByCode(code, subsidiaryId) {
  try {
    const response = await productAPI.get(`/Stock/subsidiary/${subsidiaryId}/product-code/${code}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir compañia"
    );
  }
}

export async function updateStocks(stocks) {
  try {
    const response = await productAPI.put(`/Stock/Update/List`, stocks);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir compañia"
    );
  }
}
