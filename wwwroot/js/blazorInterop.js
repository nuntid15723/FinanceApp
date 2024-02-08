// wwwroot/js/blazorInterop.js

window.loadScript = function (path) {
    return new Promise((resolve, reject) => {
        const script = document.createElement('script');
        script.src = path;
        script.onload = resolve;
        script.onerror = reject;
        document.head.appendChild(script);
    });
};
