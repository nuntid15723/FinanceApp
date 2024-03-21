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
     `<!DOCTYPE html>
		<html lang=""en"" dir=""ltr"">
		<head>
		<meta charset=""utf-8""/>
		<style>
			.form-control {
				border: solid 1px #fff;
			}
			.form-label{
				font-weight: normal;
			}
			.form-select {

            font-size: 16px; /* ขนาดตัวอักษร */
            background-color: #fff;
        	}
			.row {
				--bs-gutter-x: 1.5rem; 
				--bs-gutter-y: 0;
				display: flex;
				flex-wrap: wrap;
				margin-top: calc(var(--bs-gutter-y)* -1);
				 /*margin-right: calc(var(--bs-gutter-x)* -0.5); 
				margin-left: calc(var(--bs-gutter-x)* -0.5); */
			}
			 @page {   /* size: landscape;*/
			    size: A4; 
				width: 297mm; 
				height: 210mm; 
				margin: 0;  }
		</style>
		${pdfData}</html>`
   );
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
		<style>
		
			@page {
				size: 21cm 29.7cm;
			}
		</style>
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
