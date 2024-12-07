import { useLocation } from "react-router-dom";

function ReportPage() {
  const location = useLocation();
  const { startDate, endDate, type } = location.state || {};

  const renderIframes = () => {
    const baseURL = "http://localhost:8000/grafana/d-solo/ee60jn91cm7lsc/reports";
    const fromTimestamp = new Date(startDate).getTime();
    const toTimestamp = new Date(endDate).getTime();

    const iframeParams = `?orgId=1&from=${fromTimestamp}&to=${toTimestamp}&timezone=browser&var-startDate=${startDate}&var-endDate=${endDate}&__feature.dashboardSceneSolo`;

    switch (type) {
      case "Entradas":
        return (
          <>
            <iframe
              src={`${baseURL}${iframeParams}&panelId=1`}
              className="w-full h-[400px]"
            />
            <iframe
              src={`${baseURL}${iframeParams}&panelId=3`}
              className="w-full h-[400px]"
            />
          </>
        );
      case "Salidas":
        return (
          <>
            <iframe
              src={`${baseURL}${iframeParams}&panelId=2`}
              className="w-full h-[400px]"
            />
            <iframe
              src={`${baseURL}${iframeParams}&panelId=8`}
              className="w-full h-[400px]"
            />
          </>
        );
      case "Entradas/Salidas":
        return (
          <>
            <iframe
              src={`${baseURL}${iframeParams}&panelId=4`}
              className="w-full h-[400px]"
            />
            <iframe
              src={`${baseURL}${iframeParams}&panelId=5`}
              className="w-full h-[400px]"
            />
          </>
        );
      case "Ganancias/Perdidas":
        return (
          <>
            <iframe
              src={`${baseURL}${iframeParams}&panelId=6`}
              className="w-full h-[400px]"
            />
            <iframe
              src={`${baseURL}${iframeParams}&panelId=7`}
              className="w-full h-[400px]"
            />
          </>
        );
      default:
        return <p className="text-red-500">Tipo de reporte no válido</p>;
    }
  };

  return (
    <div className="flex flex-col space-y-5 py-10 w-full items-center font-roboto">
      <p className="font-roboto font-bold text-[24px]">Reporte</p>
      <div className="flex flex-col items-center justify-center w-full space-y-4">
        <div className="flex flex-col lg:flex-row items-center justify-between w-4/5 space-y-4 lg:space-x-4">
          {renderIframes()}
        </div>
      </div>
    </div>
  );
}

export default ReportPage;
