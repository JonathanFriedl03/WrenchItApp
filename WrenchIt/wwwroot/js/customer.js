var dataTable;
$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {
    var table = $("#tblData").DataTable({
        "language": {
            "emptyTable": "No records found."
        }
    }
    );


}