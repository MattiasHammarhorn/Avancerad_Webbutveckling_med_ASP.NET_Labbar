function createTableOfObjectAndPropertiesArrays(properties, result) {

    $("#customerListDiv").text("");
    var html = '<table class="table"><thead><tr>';

    $.each(properties, function (key, property) {
        html += '<th scope="col">' + property + '</td>';
    });

    html += '</tr>'+ '</thead>' + '<tbody>' + '<tr>';

    $.each(result, function (index, result) {
        index++;
        html += '<th scope="row">' + index + '</th>';
        html += '<td>' + result.firstName + '</td>';
        html += '<td>' + result.lastName + '</td>';
        html += '<td>' + result.email + '</td>';
        html += '<td>' + result.genderTypeEnglish + '</td>';
        html += '<td>' + result.age + '</td>';
        html += '<td>' + result.formatCreationDate + '</td>';
        html += '<td>' + result.formatUpdateDate + '</td>';
        html += '<td>' + '<button id="id_delete_for_' + result.id + '" class="delete_Button">Delete</button>' + '</td>';
        html += '<td>' + '<button id="id_edit_for_' + result.id + '" class="edit_Button">Edit</button>' + '</td>';
        html += '</tr>';
    });

    html += "</tbody>" + "</table>";

    $("#customerListDiv").append(html);
}

function printSuccessMessage(result) {
    $("#successMessage").attr('class', 'alert alert-success').text(result).fadeOut(8000);
}

function printErrorMessage(error) {
    $("#errorMessage").attr('class', 'alert alert-danger').text(error).fadeOut(8000);
}

function resetEditForm() {
    $("#editForm input").val("");
}

function resetAddForm() {
    $("#addForm input").val("");
}

function hideEditForm() {
    $("#editForm").hide();
}

function showEditForm() {
    $("#editForm").show();
}

$("#addFormSend").click(function () {

    $.ajax({
        url: '/api/Customers',
        method: 'POST',
        data: {
            "FirstName": $("#addForm [name=FirstName]").val(),
            "LastName": $("#addForm [name=LastName]").val(),
            "Email": $("#addForm [name=Email]").val(),
            "GenderType": $("#addForm input[type='radio']:checked").val(),
            "Age": $("#addForm [name=Age]").val()
        }

    })
        .done(function (result) {

            console.log('Success! Result = ' + result);
            printSuccessMessage(result);
            $("#listCustomersButton").triggerHandler("click");
            resetAddForm();
        })

        .fail(function (xhr, status, error) {

            printErrorMessage(error);
            console.log("Error", xhr, status, error);

        });
});

$("#editFormSend").click(function () {

    $.ajax({
        url: '/api/Customers',
        method: 'PUT',
        data: {
            "FirstName": $("#editForm [name=FirstName]").val(),
            "LastName": $("#editForm [name=LastName]").val(),
            "Email": $("#editForm [name=Email]").val(),
            "GenderType": $("#editForm input[type='radio']:checked").val(),
            "Age": $("#editForm [name=Age]").val(),
            "Id": $("#editForm").attr('data-id')
        }
    })
        .done(function (result) {
            
            console.log('Success! Result = ' + result);
            printSuccessMessage(result);
            $("#cancelButton").triggerHandler("click");
            $("#listCustomersButton").triggerHandler("click");
        })

        .fail(function (xhr, status, error) {

            printErrorMessage(error);
            console.log("Error", xhr, status, error);
        });
});

$("#seedButton").click(function () {
    
    $.ajax({
        url: 'api/Customers/Seed',
        method: 'DELETE'
    })
        .done(function (result) {
            
            console.log('Success! Result = ' + result);
            console.log(result);
            printSuccessMessage(result);
            $("#listCustomersButton").triggerHandler("click");
        })

        .fail(function (xhr, status, error) {

            printErrorMessage(error);
            console.log("Error", xhr, status, error);
        });
});

$("#listCustomersButton").click(function () {

    $.ajax({
        url: '/api/Customers',
        method: 'GET'

    })
        .done(function (result) {
            var properties = ["#", "First Name", "Last Name", "Email", "Gender", "Age", "Created On", "Last Updated", "Delete", "Edit"];
            createTableOfObjectAndPropertiesArrays(properties, result);
            console.log("Success! Result = " + result);
        })

        .fail(function (xhr, status, error) {

            printErrorMessage(error);
            console.log("Error", xhr, status, error);

        });
});

$("#cancelButton").click(function () {

    resetEditForm();
    hideEditForm();
});

$(document).on("click", "button.delete_Button", function () {

    var idToSend = $(this).attr('id');
    var arrayToSplit = idToSend.split('_');

    $.ajax({
        url: '/api/Customers',
        method: 'DELETE',
        data: {
            id: arrayToSplit[3]
        }

    })
        .done(function (result) {

            console.log("Success!", result);
            printSuccessMessage(result);
            $("#listCustomersButton").trigger("click");
        })

        .fail(function (xhr, status, error) {

            printErrorMessage(error);
            console.log("Error", xhr, status, error);

        });
});

$(document).on("click", "button.edit_Button", function () {

    var idToSend = $(this).attr('id');
    var arrayToSplit = idToSend.split('_');

    $.ajax({
        url: '/api/Customers/' + arrayToSplit[3],
        method: 'GET',
        data: {
            id: arrayToSplit[3]
        }

    })
        .done(function (result) {

            console.log("Success!", result);

            $("#editForm input[name=FirstName]").val(result.firstName);
            $("#editForm input[name=LastName]").val(result.lastName);
            $("#editForm input[name=Email]").val(result.email);
            $("#editForm input[name=GenderType]").filter('[value="' + result.genderType + '"]').attr('checked', true);
            $("#editForm input[name=Age]").val(result.age);
            $("#editForm").attr('data-id', arrayToSplit[3]);
            showEditForm();
        })

        .fail(function (xhr, status, error) {

            printErrorMessage(error);
            console.log("Error", xhr, status, error);
        });
});

$(document).ready(function () {
    hideEditForm();
});
