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

