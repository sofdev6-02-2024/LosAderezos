function startCamera() {
    const video = document.getElementById('videoElement');

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia({ video: true })
            .then(function (stream) {
                video.srcObject = stream;
                if (videoElement.paused) {
                    videoElement.play();
                }
            })
            .catch(function (err) {
                console.log("Error accessing camera: " + err.name + ": " + err.message);
            });
    } else {
        console.log("getUserMedia not supported on this browser.");
    }
}

window.onload = function() {
    startCamera();
}

document.getElementById('scanButton').addEventListener('click', function() {
    startCamera();
});
