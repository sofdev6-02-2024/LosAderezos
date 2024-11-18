import axios from 'axios';

export const loginAPI = axios.create({
  baseURL: 'http://localhost:5009/api',
});

export const login = async (loginData) => {
  try {
    const response = await loginAPI.post('/login', loginData);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al hacer el login');
  }
};
