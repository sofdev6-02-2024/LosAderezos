import axios from 'axios';

export const loginAPI = axios.create({
  baseURL: 'http://API/auth',
});

export async function handleGoogleLogin(loginData) {
  try {
    const response = await loginAPI.post('/google', loginData);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al realizar el login con google');
  }
}
