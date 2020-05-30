var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/serviceType/GetAll",
            "type": "Get",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "rate", "width": "20%" },
            { "data": "description", "width": "20%" },
            { "data": "category", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/serviceType/Edit/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                <i class ='far fa-edit'></i> Edit </a>
                                &nbsp;
                                <a onclick=Delete("/serviceType/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                <i class ='far fa-trash-alt'></i> Delete </a>
                            </div>`;
                }, "width": "30%"
            }
        ],//display data when there is none
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    });
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