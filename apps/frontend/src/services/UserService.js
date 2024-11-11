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

export async function updateUser(user) {
  try {
    const response = await userAPI.put(`/user/`, user);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir el usuario');
  }
}

export async function getUsers()
{
  try {
    const response = await userAPI.get("/user");
    return response.data
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir usuarios');
  }
}
