// ในไฟล์ JavaScript ของคุณ
function resizeImage(imageUrl, targetWidth, targetHeight, callback) {
    fabric.Image.fromURL(imageUrl, function (img) {
        // รีไซส์รูปภาพ
        img.scaleToWidth(targetWidth);
        img.scaleToHeight(targetHeight);

        // สร้าง Canvas เพื่อเข้าถึงรูปภาพที่รีไซส์แล้ว
        var canvas = new fabric.Canvas('canvas');
        canvas.setDimensions({ width: targetWidth, height: targetHeight });
        canvas.add(img);

        // เรียกฟังก์ชัน callback พร้อมกับ URL ของรูปภาพที่รีไซส์แล้ว
        callback(canvas.toDataURL('image/jpeg'));
    });
}

// function formatNumber(e) {
//     // ดึงค่าที่ป้อนจาก input
//     var inputValue = e.target.value;

//     // ใช้ Intl.NumberFormat เพื่อทำการจัดรูปแบบตามที่ต้องการ
//     var formattedValue = new Intl.NumberFormat('en-US', {
//         style: 'decimal',
//         minimumFractionDigits: 2,
//         maximumFractionDigits: 2
//     }).format(inputValue);

//     // แสดงผลลัพธ์ใน console
//     console.log(formattedValue);
// }
// Jquery Dependency

// File: yourScript.js

// currencyFormatter.js




