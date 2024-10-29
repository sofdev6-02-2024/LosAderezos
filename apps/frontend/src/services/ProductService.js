import axios from 'axios';

export const productAPI = axios.create({
  baseURL: 'https://c7a1c2df-ffdd-494f-8e38-1ad130bdb3ec.mock.pstmn.io/papi',
});

export const getProducts = async () => {
  try {
    const response = await productAPI.get('/Products');
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir los productos');
  }
};

export async function getProductById(id) {
  try {
    const response = await fetch(`/Products/${id}`);
    if (!response.ok) {
      throw new Error("Network response was not ok");
    }
    const product = await response.json();
    return product;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al cargar los datos del producto');
  }
}
