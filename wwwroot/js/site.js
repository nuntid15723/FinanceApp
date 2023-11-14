function makeChart(notificationData, smsData) {
    var ctx1 = document.getElementById('barChart').getContext('2d');
    var ctx2 = document.getElementById('barChart2').getContext('2d');
    var barChart1 = new Chart(ctx1, {
        type: 'bar',
        data: {
            labels: ['ม.ค.', 'มี.ค.', 'มิ.ย.', 'ก.ย.', 'ต.ค.', 'ธ.ค.'],
            datasets: [{
                label: 'จำนวนแจ้งเตือน',
                data: notificationData,
                backgroundColor: 'rgba(0, 123, 255, 0.5)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

    var barChart2 = new Chart(ctx2, {
        type: 'bar',
        data: {
            labels: ['ม.ค.', 'มี.ค.', 'มิ.ย.', 'ก.ย.', 'ต.ค.', 'ธ.ค.'],
            datasets: [{
                label: 'จำนวนข้อความ',
                data: smsData,
                backgroundColor: 'rgba(255, 0, 0, 0.5)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}
function makeChart1(resData) {
    // Parse the JSON response
    var data = JSON.parse(resData);

    // Get the 'SYSTEM_SEND_SMS_DATA' object
    var systemData = data.SYSTEM_SEND_SMS_DATA;

    // Get the months labels
    var monthsLabels = systemData.map(function (item) {
        var monthNum = parseInt(item.MONTH);
        var months = ['ม.ค.', 'ก.พ.', 'มี.ค.', 'เม.ย.', 'พ.ค.', 'มิ.ย.', 'ก.ค.', 'ส.ค.', 'ก.ย.', 'ต.ค.', 'พ.ย.', 'ธ.ค.'];
        return months[monthNum - 1]; // -1 because months array is 0-indexed
    });

    var ctx1 = document.getElementById('barChart').getContext('2d');

    var barChart1 = new Chart(ctx1, {
        type: 'bar',
        data: {
            labels: monthsLabels,
            datasets: [{
                label: 'จำนวนแจ้งเตือน',
                data: systemData.map(item => item.AMT),
                backgroundColor: 'rgba(0, 123, 255, 0.5)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

function makeChart2(resData) {
    // Parse the JSON response
    var data = JSON.parse(resData);

    // Get the 'SYSTEM_SEND_SMS_DATA' object
    var systemData = data.SYSTEM_SEND_SMS_DATA;

    // Get the months labels
    var monthsLabels = systemData.map(function (item) {
        var monthNum = parseInt(item.MONTH);
        var months = ['ม.ค.', 'ก.พ.', 'มี.ค.', 'เม.ย.', 'พ.ค.', 'มิ.ย.', 'ก.ค.', 'ส.ค.', 'ก.ย.', 'ต.ค.', 'พ.ย.', 'ธ.ค.'];
        return months[monthNum - 1]; // -1 because months array is 0-indexed
    });

    var ctx2 = document.getElementById('barChart2').getContext('2d');

    var barChart2 = new Chart(ctx2, {
        type: 'bar',
        data: {
            labels: monthsLabels,
            datasets: [{
                label: 'จำนวนข้อความ',
                data: systemData.map(item => item.AMT),
                backgroundColor: 'rgba(255, 0, 0, 0.5)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

window.downloadFile = function (data, filename) {
    var blob = new Blob(['\ufeff', data], { type: 'text/csv;charset=utf-16le;' });
    var link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = filename;
    link.style = "visibility:hidden";
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}


window.setFileInputAccept = (id, types) => {
    document.getElementById(id).querySelector('input').accept = types;
}


window.radzenResizable = {
    applyResizable: function (tableId) {
        let table = document.getElementById(tableId);
        let row = table.getElementsByTagName('tr')[0];
        let cols = row ? row.children : undefined;
        if (!cols) return;

        table.style.overflow = 'hidden';
        let tableHeight = table.offsetHeight;

        for (let i = 0; i < cols.length; i++) {
            let div = createDiv(tableHeight);
            cols[i].appendChild(div);
            cols[i].style.position = 'relative';
            makeResizableDiv(div);
        }
    }
};

function createDiv(height) {
    let div = document.createElement('div');
    div.style.top = 0;
    div.style.right = 0;
    div.style.width = '5px';
    div.style.position = 'absolute';
    div.style.cursor = 'col-resize';
    div.style.userSelect = 'none';
    div.style.height = `${height}px`;
    return div;
}

function makeResizableDiv(div) {
    let pageX, curCol, nxtCol, curColWidth, nxtColWidth;

    div.addEventListener('mousedown', function (e) {
        curCol = e.target.parentElement;
        nxtCol = curCol.nextElementSibling;
        pageX = e.pageX;

        let padding = paddingDiff(curCol);

        curColWidth = curCol.offsetWidth - padding;
        if (nxtCol)
            nxtColWidth = nxtCol.offsetWidth - padding;
    });

    div.addEventListener('mouseover', function (e) {
        e.target.style.borderRight = '2px solid #0000ff';
    });

    div.addEventListener('mouseout', function (e) {
        e.target.style.borderRight = '';
    });

    document.addEventListener('mousemove', function (e) {
        if (curCol) {
            let diffX = e.pageX - pageX;

            if (nxtCol)
                nxtCol.style.width = `${(nxtColWidth - (diffX))}px`;

            curCol.style.width = `${(curColWidth + diffX)}px`;
        }
    });

    document.addEventListener('mouseup', function () {
        curCol = undefined;
        nxtCol = undefined;
        pageX = undefined;
        nxtColWidth = undefined;
        curColWidth = undefined;
    });
}

function paddingDiff(col) {
    if (getStyleVal(col, 'box-sizing') === 'border-box') {
        return 0;
    }

    let padLeft = getStyleVal(col, 'padding-left');
    let padRight = getStyleVal(col, 'padding-right');
    return (parseInt(padLeft) + parseInt(padRight));

}

function getStyleVal(elm, css) {
    return (window.getComputedStyle(elm, null).getPropertyValue(css));
}





window.setupNavbar = function () {
    const showNavbar = (toggleId, navId, bodyId, headerId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId);

        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                nav.classList.toggle('show');
                toggle.classList.toggle('bx-x');
                bodypd.classList.toggle('body-pd');
                headerpd.classList.toggle('body-pd');
                if (toggle.classList.contains("bx-x")) {
                    toggle.classList.remove("fa-bars")
                    toggle.classList.add("fa-xmark")
                } else {
                    toggle.classList.remove("fa-xmark")
                    toggle.classList.add("fa-bars")
                }
            });
        }
    }

    showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header');

    const linkColor = document.querySelectorAll('.nav_link');

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'));
            this.classList.add('active');
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink));
}
// ใน JavaScript
window.getValue2 = function (element) {
    return element.dataset.value2;
};




