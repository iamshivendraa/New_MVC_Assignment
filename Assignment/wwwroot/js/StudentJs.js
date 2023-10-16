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
                    object += '<td> <a href="#" class="btn btn-primary btn-sm" onclick = "Edit(' + obj.id + ')">Edit</a> <a href="#" class="btn btn-danger btn-sm" onclick = "Delete(' + obj.id + ')">Delete</a></td>';
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

$("#btnAdd").click(function () {
    $("#studentModal").modal('show');
    $("#modalTitle").text("Add Student");
    ClearData();
    $('#Update').css('display', 'none');
    $('#Save').css('display', 'block');
})

function Validate() {
    var isValid = true;
    var name = $("#Name").val().trim();
    var Class = $("#Class").val().trim();
    var city = $("#City").val().trim();
    var marks = $("#Marks").val().trim();

    if (name === "") {
        $("#error-name").text("Name field can not be empty.");
        isValid = false;
    }
    else {
        $("#error-name").text("");
    }

    if (Class === "") {
        $("#error-class").text("Class field can not be empty.");
        isValid = false;
    }
    else if (parseInt(Class) < 1 || parseInt(Class) > 12) {
        $("#error-class").text("Class range should between 1-12");
        isValid = false;
    }
    else {
        $("#error-class").text("");
    }


    if (city ==="") {
        $("#error-city").text("City field can not be empty.");
        isValid = false;
    }
    else if (/^[YZyz].*/.test(city)) {
        $("#error-city").text("City name can not starts with Y and Z");
        isValid = false;
    }
    else {
        $("#error-city").text("");
    }

    if (marks === "") {
        $("#error-marks").text("Marks can not be null");
        isValid = false;
    }
    else if ( parseInt(marks) <= 0 || parseInt(marks) > 100) {
        $("#error-marks").text("Marks range should between 1-100");
        isValid = false;
    }
    else {
        $("#error-marks").text("");
    }
    return isValid;
}
$('#Name').keyup(function () {
    Validate();
});

$("#Class").keyup(function () {
    Validate();
});

$("#City").keyup(function () {
    Validate();
});

$("#Marks").keyup(function () {
    Validate();
});

function Insert() {
    var result = Validate();
    if (result == false) {
        return false;
    }

    var formData = new Object();
    formData.name = $("#Name").val();
    formData.class = $("#Class").val();
    formData.city = $("#City").val();
    formData.marks = $("#Marks").val();

    $.ajax({
        url: 'Student/Insert',
        type: 'post',
        data: formData,
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save the data');
            }
            else {
                HideModal();
                alert(response);
                location.reload();
                GetProducts();
                
            }
        },
        error: function (response) {
            alert('Unable to save the data.')
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
                $('#modalTitle').text("Update");
                $('#Save').css('display', 'none');
                $('#Update').css('display', 'block');
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
function ClearData() {
    $('#Name').val('');
    $('#Class').val('');
    $('#City').val('');
    $('#Marks').val('');
}



function Update() {
    var result = Validate();
    if (result == false) {
        return false;
    }

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
                alert(response);
                location.reload();
                GetProducts();
            }
        },
        error: function (response) {
            alert('Unable to save the data.');
        }
    });
}

function Delete(id) {
    if (confirm("Are you sure to delete this record?")) {
        $.ajax({
            url: '/Student/Delete?id=' + id,
            type: 'post',
            success: function (response) {
                if (response == null || response == undefined) {
                    alert('Unable to delete the data.')
                }
                else {
                    location.reload();
                    GetProducts();
                    alert(response);
                }
            },
            error: function () {
                alert('Unable to read the data.');
            }
        });

    }
}
