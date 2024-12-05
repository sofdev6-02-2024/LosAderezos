import { BrowserMultiFormatReader, NotFoundException } from '@zxing/library';

let codeReader;
let isCameraRunning = false;
let currentVideoElement = null;
let lastScanTime = 0;

export function startCameraAndScan(videoElement) {
    if (isCameraRunning) {
        console.warn('La cámara ya está en funcionamiento.');
        return;
    }

    currentVideoElement = videoElement;
    codeReader = new BrowserMultiFormatReader();
    isCameraRunning = true;

    codeReader.listVideoInputDevices()
        .then((videoInputDevices) => {
            if (videoInputDevices.length > 0) {
                const firstDeviceId = videoInputDevices[0].deviceId;

                if (currentVideoElement.srcObject) {
                    const stream = currentVideoElement.srcObject;
                    const tracks = stream.getTracks();
                    tracks.forEach(track => track.stop());
                    currentVideoElement.srcObject = null;
                }

                codeReader.decodeFromVideoDevice(firstDeviceId, videoElement, (result, err) => {
                    const currentTime = Date.now();
                    if (currentTime - lastScanTime < 1000) {
                        return;
                    }

                    lastScanTime = currentTime;

                    if (result) {
                        console.log('Código de barras encontrado:', result.text);
                        document.getElementById('result').textContent = `Resultado del Código de Barras: ${result.text}`;
                        stopCamera();
                    }
                    if (err) {
                        if (err instanceof NotFoundException) {
                            console.log("No se encontró ningún código de barras.");
                        } else {
                            console.error('Error de escaneo:', err);
                        }
                    }
                });
            } else {
                console.error('No se encontraron dispositivos de entrada de video');
                stopCamera();
            }
        })
        .catch((err) => {
            console.error('Error al listar dispositivos de video:', err);
            stopCamera();
        });
}

export function stopCamera() {
    if (!isCameraRunning) return;

    codeReader.reset();
    if (currentVideoElement && currentVideoElement.srcObject) {
        const stream = currentVideoElement.srcObject;
        const tracks = stream.getTracks();
        tracks.forEach(track => track.stop());
        currentVideoElement.srcObject = null;
    }
    isCameraRunning = false;
}

document.getElementById('scanButton').addEventListener('click', function() {
    const videoElement = document.getElementById('videoElement');
    startCameraAndScan(videoElement);
});