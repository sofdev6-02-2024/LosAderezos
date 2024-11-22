import { Outlet } from "react-router-dom";
import Header from "../layouts/Header";
import { Toaster } from "sonner";

function AppLayout() {
  return (
    <div className="flex flex-col min-h-screen w-full">
      <Toaster position="bottom-right" expand visibleToasts={3}
        richColors
        toastOptions={{
          success: {
            style: {
              padding: '8px 16px',
              fontWeight: 'bold',
            },
          },
        }}
      />
      <Header />
      <main className="flex-grow">
        <Outlet />
      </main>
    </div>
  );
}

export default AppLayout;
