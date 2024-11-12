import axios from 'axios';

export const productAPI = axios.create({
  baseURL: 'http://localhost:8080/products',
});

export const getProducts = async () => {
  try {
    const response = await productAPI.get('/Product');
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir los productos');
  }
};

export async function getProductById(productId) {
  try {
    const response = await productAPI.get(`/Product/${productId}`);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al cargar los datos del producto');
  }
}

export async function getCategoriesByProductId(productId) {
  try {
    const response = await productAPI.get(`/ProductCategories/product/${productId}`);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al cargar los datos del producto');
  }
}

export async function getProductBranches(productId) {
  try {
    const response = await productAPI.get(`/Product/${productId}/branches`);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al cargar las sucursales en las que hay existencias del producto');
  }
}

export async function addUsersToSubsidiary(request) {
  try {
    const response = await productAPI.post("/create/list", request)
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al añadir los usuarios');
  }
}
