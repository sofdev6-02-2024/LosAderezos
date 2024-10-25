import { Routes, Route } from 'react-router-dom';
import StoreMenu from "./pages/StoreMenu"
import NotFound from './pages/NotFound';

function App() {
  return (
    <div className="flex flex-col min-h-screen w-full">
      <Routes>
      <Route path='*' element={<NotFound />} />
        <Route path='/' element={<StoreMenu />} />
      </Routes>
    </div>
  )
}

export default App
