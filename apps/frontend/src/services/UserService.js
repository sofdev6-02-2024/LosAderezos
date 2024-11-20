import axios from 'axios';

export const userAPI = axios.create({
  baseURL: 'http://localhost:8000/users',
});

export const getUserByGmail = async (gmail) => {
  try {
    const response = await userAPI.post(`/User/email`, {email: gmail});
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir el usuario');
  }
};

export async function updateUser(user) {
  try {
    const response = await userAPI.put(`/User`, user);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al actualizar el usuario');
  }
}

export async function getUserById(user) {
  try {
    const response = await userAPI.get(`/User/${user}`);
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir el usuario');
  }
}

export async function getUsersBySubsidiaryId(id)
{
  try {
    const response = await userAPI.get(`/User/subsidiary/${id}`);
    return response.data
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir usuarios');
  }
}
