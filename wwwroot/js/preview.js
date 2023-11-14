// ใน wwwroot/scripts/custom.js (หรือสร้างไฟล์ JavaScript ใหม่)
function setImagePreview(imageId, imageUrl) {
    // console.log("555");
    var imageElement = document.getElementById(imageId);
    if (imageElement) {
        imageElement.src = imageUrl;
    }
}

// function setImagePreview(imageId, imageUrl) {
//     var imageElement = document.getElementById(imageId);
//     // console.log("555");

//     if (imageElement) {
//         var canvas = document.createElement('canvas');
//         var ctx = canvas.getContext('2d');
//         var newWidth = 100;
//         var newHeight = 100;

//         // ตั้งค่าขนาดของ Canvas
//         canvas.width = newWidth;
//         canvas.height = newHeight;

//         // สร้าง Image Object
//         var img = new Image();
//         img.src = imageUrl;

//         // รอให้รูปภาพโหลดเสร็จก่อนที่จะดำเนินการ
//         img.onload = function () {
//             // ทำการรีไซส์รูปภาพ
//             ctx.drawImage(img, 0, 0, newWidth, newHeight);

//             // ตั้งค่า source ของรูปภาพ
//             imageElement.src = canvas.toDataURL('image/png');
//         };
//     }
// }

