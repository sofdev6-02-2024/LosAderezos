import { Routes, Route } from "react-router-dom";
import NotFound from "./pages/NotFound";
import ProductsPage from "./pages/ProductsPage";
import SingleProductPage from "./pages/SingleProductPage";
import AddUser from "./pages/AddUser";
import Login from './pages/Login';
import AppLayout from "./layouts/AppLayout";
import UserPage from "./pages/UserPage";
import InProductPage from "./pages/InProductsPage";
import OutProductPage from "./pages/OutProductPage";
import AddProductPage from "./pages/AddProductPage";
import EditProductPage from "./pages/EditProductPage";
import EditUserPage from "./pages/EditUserPage";
import SubsidiariesPage from "./pages/SubsidiariesPage";
import EditSubsidiaryPage from "./pages/EditSubsidiaryPage";
import AddSubsidiaryPage from "./pages/AddSubsidiaryPage";
import ReportPage from "./pages/ReportPage";
import NewReport from "./pages/NewReport";
import LandingPage from "./pages/LandingPage";

function App() {
  return (
    <Routes>
      <Route path="*" element={<NotFound />} />
      <Route path='/' element={<Login />} />
      <Route element={<AppLayout />}>
        <Route path="/store-menu" element={<LandingPage />} />
        <Route path="/products" element={<ProductsPage />} />
        <Route path="/products/:id" element={<SingleProductPage />} />
        <Route path="/add-product" element={<AddProductPage />} />
        <Route path="/edit-product/:id" element={<EditProductPage />} />
        <Route path="/branches" element={<SubsidiariesPage />} />
        <Route path="/add-branch" element={<AddSubsidiaryPage />} />
        <Route path="/edit-branch" element={<EditSubsidiaryPage />} />
        <Route path="/notifications" element={<NotFound />} />
        <Route path="/addUsers" element={<AddUser />} />
        <Route path="/users" element={<UserPage />} />
        <Route path="/in-products" element={<InProductPage />} />
        <Route path="/out-products" element={<OutProductPage />} />
        <Route path="/my-user" element={<EditUserPage />} />
        <Route path="/new-report" element={<NewReport />} />
        <Route path="/reports" element={<ReportPage />} />
      </Route>
    </Routes>
  );
}

export default App;
