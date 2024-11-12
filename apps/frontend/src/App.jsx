import { Routes, Route } from "react-router-dom";
import StoreMenu from "./pages/StoreMenu";
import NotFound from "./pages/NotFound";
import ProductsPage from "./pages/ProductsPage";
import SingleProductPage from "./pages/SingleProductPage";
import AddUser from "./pages/AddUser";
import Login from './pages/Login';
import AppLayout from "./layouts/AppLayout";
import UserPage from "./pages/UserPage";

function App() {
  return (
    <Routes>
      <Route path="*" element={<NotFound />} />
      <Route path='/' element={<Login />} />
      <Route element={<AppLayout />}>
        <Route path="/store_menu" element={<StoreMenu />} />
        <Route path="/products" element={<ProductsPage />} />
        <Route path="/products/:id" element={<SingleProductPage />} />
        <Route path="/branches" element={<NotFound />} />
        <Route path="/notifications" element={<NotFound />} />
        <Route path="/addUsers" element={<AddUser />} />
        <Route path="/users" element={<UserPage />} />
      </Route>
    </Routes>
  );
}

export default App;
