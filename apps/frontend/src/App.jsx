import { Routes, Route } from 'react-router-dom';
import StoreMenu from "./pages/StoreMenu"
import NotFound from './pages/NotFound';
import ProductsPage from './pages/ProductsPage';
import Header from './layouts/Header';

function App() {
  return (
    <div className="flex flex-col min-h-screen w-full">
      <Header />
      <Routes>
      <Route path='*' element={<NotFound />} />
        <Route path='/' element={<StoreMenu />} />
        <Route path='/products' element={<ProductsPage />} />
        <Route path='/branches' element={<NotFound />} />
        <Route path='/notifications' element={<NotFound />} />
      </Routes>
    </div>
  )
}

export default App
