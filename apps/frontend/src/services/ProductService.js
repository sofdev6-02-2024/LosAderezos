import axios from 'axios';

export const reservationAPI = axios.create({
  baseURL: 'https://c7a1c2df-ffdd-494f-8e38-1ad130bdb3ec.mock.pstmn.io/papi',
});

export const getProducts = async () => {
  try {
    const response = await reservationAPI.get('/Products');
    return response.data;
  } catch (error) {
    throw new Error(error.response?.data?.message || 'Error al conseguir los productos');
  }
};
