import axios from 'axios';

export const productAPI = axios.create({
  baseURL: 'http://localhost:8000/products',
});

export async function getAllCategories() {
  try {
    const response = await productAPI.get('/Category');
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al cargar las categorias');
  }
}

export async function getCategoryById(categoryId) {
  try {
    const response = await productAPI.get(`/Category/${categoryId}`);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al cargar la categoria por id');
  }
}

export async function createCategory(category) {
  try {
    const response = await productAPI.post("/Category", category);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al crear categoria"
    );
  }
}
