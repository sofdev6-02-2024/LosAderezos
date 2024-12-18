import axios from "axios";

export const productAPI = axios.create({
  baseURL: "http://localhost:8000/products",
});

export const getProducts = async (subsidiaryId) => {
  try {
    const response = await productAPI.get(`/Stock/subsidiary/${subsidiaryId}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir los productos de la sucursal"
    );
  }
};

export async function getProductById(subsidiaryId, productId) {
  try {
    const response = await productAPI.get(`/Stock/subsidiary/${subsidiaryId}/product/${productId}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al cargar los datos del producto"
    );
  }
}

export async function getCategoriesByProductId(productId) {
  try {
    const response = await productAPI.get(
      `/ProductCategories/product/${productId}`
    );
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al cargar los datos del producto"
    );
  }
}

export async function getProductBranches(companyId, productId) {
  try {
    const response = await productAPI.get(`/Stock/company/${companyId}/product/${productId}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message ||
        "Error al cargar las sucursales en las que hay existencias del producto"
    );
  }
}

export async function addUsersToSubsidiary(request) {
  try {
    const response = await productAPI.post("/create/list", request);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al añadir los usuarios"
    );
  }
}

export async function getSubsidiaryById(id) {
  try {
    const response = await productAPI.get(`/Subsidiary/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir subsidiaria"
    );
  }
}

export async function getSubsidiaries(id) {
  try {
    const response = await productAPI.get(`/Subsidiary/company/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir subsidiarias"
    );
  }
}

export async function deleteSubsidiary(id) {
  try {
    const response = await productAPI.delete(`/Subsidiary/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al eliminar subsidiaria"
    );
  }
}


export async function getCompanyById(id) {
  try {
    const response = await productAPI.get(`/Company/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir compañia"
    );
  }
}

export async function getProductByCode(code, subsidiaryId) {
  try {
    const response = await productAPI.get(`/Stock/subsidiary/${subsidiaryId}/product-code/${code}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir compañia"
    );
  }
}

export async function updateStocks(stocks) {
  try {
    const response = await productAPI.put(`/Stock/Update/List`, stocks);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir compañia"
    );
  }
}

export async function createProduct(productData) {
  try {
    const response = await productAPI.post("/Product", productData);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al crear el producto"
    );
  }
}

export async function assignCategoriesToProduct(categoryIds, productId) {
  try {
    const response = await productAPI.post("/ProductCategories/List", {categoryIds, productId});
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al asignar categorías al producto"
    );
  }
}

export async function updateProduct(productId, productData) {
  try {
    const response = await productAPI.put(`/Product/${productId}`, productData);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al actualizar el producto"
    );
  }
}

export async function updateProductCategories(categoryIds, productId) {
  try {
    const response = await productAPI.put("/ProductCategories", {categoryIds, productId});
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al actualizar categorías del producto"
    );
  }
}

export async function deleteProduct(productId) {
  try {
    const response = await productAPI.delete(`/Product/${productId}`);
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al eliminar el producto"
    );
  }
}

export async function removeUserFromSubsidiary(user) {
  try {
    const response = await productAPI.delete('/SubsidiaryUsers', {
      data: user
    });
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al eliminar el usuario"
    );
  }
}
