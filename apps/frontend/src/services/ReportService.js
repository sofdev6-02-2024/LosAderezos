import axios from "axios";

export const productAPI = axios.create({
  baseURL: "http://localhost:8000/reports",
});

export async function newIn(body) {
  try {
    const response = await productAPI.post("/input", body);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error en la entrada de productos"
    );
  }
}

export async function newOut(body) {
  try {
    const response = await productAPI.post("/output", body);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error en la salida de productos"
    );
  }
}
