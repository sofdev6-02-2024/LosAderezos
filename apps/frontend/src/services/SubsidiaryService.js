import axios from "axios";

export const subsidiaryAPI = axios.create({
  baseURL: "http://localhost:8000/products",
});

export async function createSubsidiary(subsidiaryData) {
  try {
    const response = await subsidiaryAPI.post("/Subsidiary", subsidiaryData);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al crear la sucursal"
    );
  }
}

export async function updateSubsidiary(subsidiaryData) {
  try {
    const response = await subsidiaryAPI.put(`/Subsidiary`, subsidiaryData);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al actualizar la sucursal"
    );
  }
}
