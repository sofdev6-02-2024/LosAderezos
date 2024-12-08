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
          <div className="flex flex-col w-full space-y-3">
            <div className="flex flex-col w-full lg:flex-row space-x-0 space-y-3 lg:space-y-0 lg:space-x-3">
              <iframe
                src={`${baseURL}${iframeParams}&panelId=1`}
                className="w-full h-[400px]"
              />
              <iframe
                src={`${baseURL}${iframeParams}&panelId=3`}
                className="w-full h-[400px]"
              />
            </div>
            <iframe 
              src={`${baseURL}${iframeParams}&panelId=7`}
              className="w-full h-[400px]"
            />
          </div>
        );
      case "Salidas":
        return (
          <div className="flex flex-col w-full space-y-3">
            <div className="flex flex-col w-full lg:flex-row space-x-0 space-y-3 lg:space-y-0 lg:space-x-3">
              <iframe
                src={`${baseURL}${iframeParams}&panelId=2`}
                className="w-full h-[400px]"
              />
              <iframe
                src={`${baseURL}${iframeParams}&panelId=8`}
                className="w-full h-[400px]"
              />
            </div>
            <iframe 
              src={`${baseURL}${iframeParams}}&panelId=9`}
              className="w-full h-[400px]"
            />
          </div>
        );
      case "Entradas/Salidas":
        return (
          <div className="flex flex-col w-full lg:flex-row space-x-0 space-y-3 lg:space-y-0 lg:space-x-3">
            <iframe
              src={`${baseURL}${iframeParams}&panelId=4`}
              className="w-full h-[400px]"
            />
            <iframe
              src={`${baseURL}${iframeParams}&panelId=5`}
              className="w-full h-[400px]"
            />
          </div>
        );
      case "Ganancias/Perdidas":
        return (
          <div className="flex flex-col w-full space-y-3">
            <div className="flex flex-col w-full lg:flex-row space-x-0 space-y-3 lg:space-y-0 lg:space-x-3">
              <iframe
                src={`${baseURL}${iframeParams}&panelId=6`}
                className="w-full h-[400px]"
              />
              <iframe
                src={`${baseURL}${iframeParams}&panelId=12`}
                className="w-full h-[400px]"
              />
            </div>
            <div className="flex flex-col w-full lg:flex-row space-x-0 space-y-3 lg:space-y-0 lg:space-x-3">
              <iframe src={`${baseURL}${iframeParams}&panelId=10`}
                className="w-full h-[400px]"
              />
              <iframe src={`${baseURL}${iframeParams}&panelId=11`}
                className="w-full h-[400px]"
              />
            </div>
          </div>
        );
      default:
        return <p className="text-red-500">Tipo de reporte no válido</p>;
    }
  };

  return (
    <div className="flex flex-col space-y-5 py-10 w-full justify-center items-center font-roboto">
      <p className="font-roboto font-bold text-[24px]">Reporte</p>
      <div className="flex flex-col w-4/5 justify-center items-center">
        {renderIframes()}
      </div>
    </div>
  );
}

export default ReportPage;
