// window.uploadImage = function (inputId, avatarId, textAreaId) {
//     const input = document.getElementById(inputId);
//     const avatar = document.getElementById(avatarId);
//     const textArea = document.getElementById(textAreaId);

//     const convertBase64 = (file) => {
//         return new Promise((resolve, reject) => {
//             const fileReader = new FileReader();
//             fileReader.readAsDataURL(file);

//             fileReader.onload = () => {
//                 resolve(fileReader.result);
//             };

//             fileReader.onerror = (error) => {
//                 reject(error);
//             };
//         });
//     };

//     const uploadImage = async (event) => {
//         const file = event.target.files[0];
//         const base64 = await convertBase64(file);
//         avatar.src = base64;
//         textArea.innerText = base64;
//     };

//     input.addEventListener("change", (e) => {
//         uploadImage(e);
//     });
// };
window.uploadImage = function (inputId, avatarId, textAreaId) {
    const input = document.getElementById(inputId);
    const avatar = document.getElementById(avatarId);
    const textArea = document.getElementById(textAreaId);

    const convertBase64 = async (file) => {
        return new Promise((resolve, reject) => {
            const fileReader = new FileReader();
            fileReader.readAsDataURL(file);

            fileReader.onload = () => {
                resolve(fileReader.result);
            };

            fileReader.onerror = (error) => {
                reject(error);
            };
        });
    };

    const cropImage = (image, width, height) => {
        const canvas = document.createElement('canvas');
        canvas.width = width;
        canvas.height = height;
        const ctx = canvas.getContext('2d');
        ctx.drawImage(image, 0, 0, width, height);
        return canvas.toDataURL();
    };

    const uploadImage = async (event) => {
        const file = event.target.files[0];
        const base64 = await convertBase64(file);

        // Create an image element to manipulate the image
        const image = new Image();
        image.src = base64;

        image.onload = () => {
            // Crop the image to the desired width and height
            const croppedBase64 = cropImage(image, 250, 250);
            avatar.src = croppedBase64;
            textArea.innerText = croppedBase64;
        };
    };

    input.addEventListener('change', (e) => {
        uploadImage(e);
    });
};


