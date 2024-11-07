import axios from 'axios';

export const userAPI = axios.create({
  baseURL: 'http://localhost:3000/suapi',
});

export const getUserByGmail = async (gmail) => {
  try {
    const response = await userAPI.get(`/user/${gmail}`);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir el usuario');
  }
};
