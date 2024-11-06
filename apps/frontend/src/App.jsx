import { Routes, Route } from 'react-router-dom';
import StoreMenu from "./pages/StoreMenu"
import NotFound from './pages/NotFound';
import ProductsPage from './pages/ProductsPage';
import SingleProductPage from './pages/SingleProductPage';
import Header from './layouts/Header';

function App() {
  return (
    <div className="flex flex-col min-h-screen w-full">
      <Header />
      <Routes>
      <Route path='*' element={<NotFound />} />
        <Route path='/' element={<StoreMenu />} />
        <Route path='/products' element={<ProductsPage />} />
        <Route path='/products/:id' element={<SingleProductPage />} />
        <Route path='/branches' element={<NotFound />} />
        <Route path='/notifications' element={<NotFound />} />
      </Routes>
    </div>
  )
}

export default App
