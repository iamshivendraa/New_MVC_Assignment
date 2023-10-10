
$("button").click(function () {
    var partialElement = $("#heading");
    partialElement.css({ "color": "blue", "font-size": "70px" });
});

$(document).ready(function () {
    $("#countForm").submit(function (event) {
        event.preventDefault();

        var rowCount = $("#rowCount").val();

        if (parseFloat(rowCount) === 0) {
            $("#error-message").text("Number can not be zero");
        }
        else if ($("#rowCount").val().trim ()==="") {
            $("#error-message").text("Number field can not be emplty");
        }
        else {
            $("error-message").text("");

            $("#countForm")[0].submit();
        }
    });
});

//function Validate() {
//    var isValid = true;
//    if ($("#rowCount").val().trim() === 0) {
//        alert("Please enter a valid number");
//    }
//    else {
//        $("#rowCount").css("border-color", "lightgrey");
//    }
//    return isValid;
//}

//$("rowCount").change(function () {
//    Validate();
//})


//$(document).ready(function () {
//    $("#countForm").submit(function(event){
//        event.PreventDefault;

//        var rowCount = $("#rowCount").val();

//        if(rowCount.trim).
//    });
//})