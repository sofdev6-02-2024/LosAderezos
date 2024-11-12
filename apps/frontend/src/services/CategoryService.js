import axios from 'axios';

export const productAPI = axios.create({
  baseURL: 'http://localhost:8080/products',
});

export async function getCategoryById(categoryId) {
  try {
    const response = await productAPI.get(`/Category/${categoryId}`);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al cargar la categoria por id');
  }
}
