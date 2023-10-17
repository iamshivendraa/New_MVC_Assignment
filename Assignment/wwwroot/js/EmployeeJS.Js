$(document).ready(function () {
    GetName();
});

function GetName() {
    $.ajax({
        url: 'Employee1/GetName',
        type: 'get',
        datatype: 'json',
        contentType: 'application/json;charset=utf-8',

        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                var object = '';
                object += '<tr>';
                object += '<td>' + 'Products not available' + '</td>';
                object += '</tr>';

                $('#tableBody').html(object);
            }

            else {
                var object = '';
                $.each(response, function (index, obj) {
                    object += '<tr>';
                    object += '<td>' + '<a href="#" onclick = "ModalDetails(' + obj.id + ')">'+obj.name+' </a>' +'</td>';
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

function ModalDetails(id) {
    $.ajax({
        url: '/Employee1/ModalDetails?id=' + id,
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
                $('#EmployeeModal').modal('show');
                $('#modalTitle').text("Employee Details");
                $('#Name').text("Name: " + response.name);
                $('#Age').text("Age: " + response.age);


                $('#CityId').text("City: " + getCityName(response.cityId));

            }
        },
        error: function () {
            alert('Unable to read the data.');
        }
    });

}

function getCityName(cityId) {
    switch (cityId) {
        case 1:
            return 'Noida';
        case 2:
            return 'Ghaziabad';
        case 3:
            return 'Meerut';
        case 4:
            return 'Agra';
        case 5:
            return 'Mathura';
        default:
            return 'Unknown'; // You can change this to an appropriate default value
    }
}