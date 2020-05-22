var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/category/GetAll",
            "type": "Get",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            { "data": "displayOrder", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/category/UpdateInsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                <i class ='far fa-edit'></i> Edit </a>
                                &nbsp;
                                <a onclick=Delete("/category/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
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
            type: 'Delete',
            url: url,
            success: function (data) {
                if (data.success) {
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}