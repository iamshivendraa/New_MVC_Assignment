$(document).ready(function () {
    GetStudents();
});

function GetStudents() {
    $.ajax({
        url: '/Student/GetStudents',
        type: 'get',
        datatype: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                var object = '';
                object += '<tr>';
                object += '<td colspan="5">' + 'Products not available' + '</td>';
                object += '</tr>';

                $('#tableBody').html(object);
            }
            else {
                var object = '';
                $.each(response, function (index, obj) {
                    object += '<tr>';
                    object += '<td>' + obj.name + '</td >';
                    object += '<td>' + obj.class + '</td >';
                    object += '<td>' + obj.city+ '</td >';
                    object += '<td>' + obj.marks+ '</td >';
                    object += '<td> <a href="#" class="btn btn-primary btn-sm" onclick = "Edit(' + obj.id + ')">Edit</a></td>';
                    object += '</tr>';

                });
                $('#tableBody').html(object);
            }
        },
        error: function () {
            alert('Unable to read the data');
        }
    });
}

function Edit(id) {
    $.ajax({
        url: '/Student/Edit?id=' + id,
        type: 'get',
        contentType: 'application/json;charset=utf-8',
        datatype: 'json',
        success: function (response) {
            if (response == null || response == undefined) {
                alert('Unable to read the data.')
            }
            else if (response.length == 0) {
                alert('Data not available with the id' + id);
            }
            else {
                $('#studentModal').modal('show');
                $('#Id').val(response.id);
                $('#Name').val(response.name);
                $('#Class').val(response.class);
                $('#City').val(response.city);
                $('#Marks').val(response.marks);

            }
        },
        error: function () {
            alert('Unable to read the data.');
        }
    });

}
function HideModal() {
    
    $('#studentModal').modal('hide');
}

function Update() {

    var formData = new Object();
    formData.id = $('#Id').val();
    formData.name = $('#Name').val();
    formData.class = $('#Class').val();
    formData.city = $('#City').val();
    formData.marks = $('#Marks').val();

    $.ajax({
        url: '/Student/Edit',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save the data');
            }
            else {
                HideModal();
                location.reload();
                GetProducts();
                alert(response);
            }
        },
        error: function (response) {
            alert('Unable to save the data.')
        }
    });
}

