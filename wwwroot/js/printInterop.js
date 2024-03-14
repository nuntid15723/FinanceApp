// window.printPdf = function (pdfData) {
//   // สร้างหน้าใหม่เพื่อพิมพ์
//   var printWindow = window.open("", "_blank");
//   printWindow.document.open();
// //   กำหนดเนื้อหาเป็นไฟล์ PDF และพิมพ์
//   printWindow.document.write(encodeURI(pdfData));
//   printWindow.document.close();
//   // พิมพ์
//   printWindow.print();
// };
// window.printPdf = function (pdfData) {
//   // สร้างหน้าใหม่เพื่อพิมพ์
//   var printWindow = window.open("", "");
//   printWindow.document.open();
//   //   กำหนดเนื้อหาเป็นไฟล์ PDF และพิมพ์
//   printWindow.document.write(pdfData);
//   printWindow.document.close();
//   // พิมพ์
//   printWindow.print();
// };

// const { printJS } = require("./print.min");

// window.printPdf = function (pdfData) {
//   // สร้าง HTML element ชนิด iframe สำหรับการพิมพ์ PDF
//   var iframe = document.createElement("iframe");
//   iframe.style.width = "0";
//   iframe.style.height = "0";
//   document.body.appendChild(iframe);

//   // เซ็ตข้อมูล PDF ให้กับ iframe
//   var doc = iframe.contentWindow.document;
//   doc.open();
//   doc.write(pdfData);
//   doc.close();

//   // พิมพ์เอกสาร PDF
//   iframe.contentWindow.print();

//   // ลบ iframe เมื่อพิมพ์เสร็จสิ้น
//   iframe.parentNode.removeChild(iframe);
// //   window.printPdf(pdfData);
// };
////////////////////////////////////////////////////////////////
// window.printPdf = function (pdfData) {
//   // สร้าง HTML element ชนิด iframe สำหรับการพิมพ์ PDF
//   var iframe = document.createElement("iframe");
//   iframe.style.width = "0";
//   iframe.style.height = "0";
//   iframe.style.display = "none"; // ซ่อน iframe
//   document.body.appendChild(iframe);

//   // เซ็ตข้อมูล PDF ให้กับ iframe
//   var doc = iframe.contentWindow.document;
//   doc.open();
//   doc.write(pdfData);
//   doc.close();

//   // พิมพ์เอกสาร PDF โดยไม่มีการพรีวิว
//   iframe.contentWindow.print();
//   console.log(doc);

//   // ลบ iframe เมื่อพิมพ์เสร็จสิ้น
//   iframe.parentNode.removeChild(iframe);
// };
//////////////////////////////////////////////////////////////////////
// window.printPdf = function (pdfData) {
//   printJS({ printable: pdfData, type: "pdf", showModal: false });
//   console.log({ printable: pdfData, type: "pdf", showModal: false });
// };

// window.printPdf = function (pdfData) {
//   // สร้าง Blob จากข้อมูล PDF
//   var blob = base64ToBlob(pdfData, "application/pdf");

//   // สร้าง URL สำหรับ Blob
//   var blobUrl = URL.createObjectURL(blob);

//   // สร้างหน้าใหม่สำหรับการเปิด URL และทำการพิมพ์
//   var printWindow = window.open(blobUrl);

//   // รอให้หน้าใหม่เปิดและทำการพิมพ์เสร็จสิ้น จากนั้นลบ URL ออก
//   printWindow.onload = function () {
//     printWindow.print();
//     URL.revokeObjectURL(blobUrl);
//   };
// };

// ฟังก์ชันสำหรับแปลงข้อมูล Base64 เป็น Blob
function base64ToBlob(base64Data, contentType) {
  contentType = contentType || "";
  var sliceSize = 1024;
  var byteCharacters = atob(base64Data);
  var byteArrays = [];
  for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
    var slice = byteCharacters.slice(offset, offset + sliceSize);
    var byteNumbers = new Array(slice.length);
    for (var i = 0; i < slice.length; i++) {
      byteNumbers[i] = slice.charCodeAt(i);
    }
    var byteArray = new Uint8Array(byteNumbers);
    byteArrays.push(byteArray);
  }
  var blob = new Blob(byteArrays, { type: contentType });
  return blob;
}
///////////////////////////

// สร้าง PDF ด้วย iframe
window.createPdf = function (pdfData) {
  var iframe = document.createElement("iframe");
  // iframe.style.width = "3508px";
  // iframe.style.height = "2480px";
  iframe.style.width = "0";
  iframe.style.height = "0";
  iframe.style.display = "none";
  document.body.appendChild(iframe);

  var doc = iframe.contentWindow.document;
  doc.open();
  // doc.write(pdfData);
   doc.write(
     `<html><head><style>@page { size: landscape; }</style></head><body>${pdfData}</body></html>`
   );
  doc.close();
console.log(doc);
  return iframe;
};

window.printPdf = function (pdfData) {
  var iframe = createPdf(pdfData);
  iframe.contentWindow.print();
};

