function recppaytypeSelect(tofromaccSelect) {
    var recppaytypeSelect = document.getElementById('recppaytypeSelect');
    var tofromaccSelect = document.getElementById('tofromaccSelect');

    recppaytypeSelect.addEventListener('change', function () {
        // Update tofromaccSelect when recppaytypeSelect changes
        tofromaccSelect.value = recppaytypeSelect.value;

        // Get the selected option in recppaytypeSelect
        var selectedRecppaytypeOption = recppaytypeSelect.options[recppaytypeSelect.selectedIndex];

        // Get the cash_type value from the data attribute of the selected option
        var recppaytypeCashType = selectedRecppaytypeOption.dataset.cashType;

        // Set the cash_type value for tofromaccSelect
        var tofromaccOption = document.querySelector(`#tofromaccSelect option[data-cashType='${recppaytypeCashType}']`);
        if (tofromaccOption) {
            tofromaccSelect.value = tofromaccOption.value;
        }
    });
}
