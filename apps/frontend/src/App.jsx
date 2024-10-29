import { Routes, Route } from 'react-router-dom';
import StoreMenu from "./pages/StoreMenu"
import NotFound from './pages/NotFound';
import ProductsPage from './pages/ProductsPage';
import SingleProductPage from './pages/SingleProductPage';

function App() {
  return (
    <div className="flex flex-col min-h-screen w-full">
      <Routes>
      <Route path='*' element={<NotFound />} />
        <Route path='/' element={<StoreMenu />} />
        <Route path='/products' element={<ProductsPage />} />
        <Route path='/product/:id' element={<SingleProductPage />} />
      </Routes>
    </div>
  )
}

export default App
