// สร้าง PDF ด้วย iframe
window.createPdf = function (pdfData) {
  var iframe = document.createElement("iframe");
  // iframe.style.width = "3508px";
  // iframe.style.height = "2480px";
  iframe.style.width = "210mm";
  iframe.style.height = "297mm";
  iframe.style.display = "none";
  document.body.appendChild(iframe);

  var doc = iframe.contentWindow.document;
  doc.open();
  // doc.write(pdfData);
  doc.write(pdfData);
  doc.close();
console.log(doc);
  return iframe;
};

window.printPdf = function (pdfData) {
  var iframe = createPdf(pdfData);
  iframe.contentWindow.print();
};

// สร้าง PDF ด้วย iframe
window.createBookPdf = function (pdfData) {
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
    `<!DOCTYPE html>
		<html lang=""en"" dir=""ltr"">
		<head>
		<meta charset=""utf-8""/>
		${pdfData}</html>`
  );
  doc.close();
console.log(doc);
  return iframe;
};

window.printBook = function (pdfData) {
  var iframe = createBookPdf(pdfData);
  iframe.contentWindow.print();
};

// window.onload = function () {
//     // alert("Page loaded");
// };
