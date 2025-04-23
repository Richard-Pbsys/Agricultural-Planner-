window.initializeDataTable = function (tableId, options) {
    var selector = '#' + tableId;
    if ($.fn.DataTable.isDataTable(selector)) {
        $(selector).DataTable().destroy();
    }
    $(selector).DataTable(options || {
        paging: true,
        searching: true,
        ordering: true,
        responsive: true,
        destroy: true
    });
};
