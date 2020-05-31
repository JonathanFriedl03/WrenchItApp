var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
   
        "language": {
            "emptyTable": "No records found."
       
        }
    }
    );

}

function Delete(url) {
    sweetAlert({
        title: "Are you sure you want to delete?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "red",
        closeONconfirm: true

    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
               if (data.success) {
                  toastr.success(data.message);
                  dataTable.ajax.reload();
                }
                else {
                      toastr.error(data.message);
                     }
                }
        });
    });
}