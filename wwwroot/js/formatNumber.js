// wwwroot/js/custom.js

window.blazorInterop = {
    formatNumberBlazor: function (inputValue) {
        console.log("5555");
        // Your JavaScript logic here
        let value = inputValue.replace(/[^0-9.]/g, '');
        let number = parseInt(value);
        if (!isNaN(number)) {
            let formattedValue = number.toLocaleString('th-TH');
            input.value = formattedValue;
        } else {
            input.value = '';
        }
    }
};

$(document).ready(function () {
    var previousData;
    $(".format-money").on('focus', function () {
        previousData = this.value;
    }).change(function () {
        var itemAmt = this.value;
        itemAmt = blazorInterop.formatNumberBlazor(itemAmt);
        this.value = itemAmt;
    });
});

function formatNumber(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
