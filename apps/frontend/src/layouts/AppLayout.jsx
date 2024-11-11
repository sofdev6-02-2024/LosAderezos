import { Outlet } from "react-router-dom";
import Header from "../layouts/Header";

function AppLayout() {
  return (
    <div className="flex flex-col min-h-screen w-full">
      <Header />
      <main className="flex-grow">
        <Outlet />
      </main>
    </div>
  );
}

export default AppLayout;
