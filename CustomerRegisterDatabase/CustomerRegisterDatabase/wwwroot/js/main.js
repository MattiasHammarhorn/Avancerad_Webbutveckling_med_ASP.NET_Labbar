function createTableOfObjectAndPropertiesArrays(properties, result) {

    $("#customerListDiv").text("");
    var html = "<table><thead><tr>";

    $.each(properties, function (key, property) {
        html += '<td>' + property + '</td>'
    });

    html += '</tr>'+ '</thead>' + '<tbody>' + '<tr>';

    $.each(result, function (index, result) {
        html += '<td>' + result.id + '</td>';
        html += '<td>' + result.firstName + '</td>';
        html += '<td>' + result.lastName + '</td>';
        html += '<td>' + result.email + '</td>';
        html += '<td>' + result.genderTypeEnglish + '</td>';
        html += '<td>' + result.age + '</td>';
        html += '<td>' + '<button id="id_delete_for_' + result.id + '" class="delete_Button">Delete</button>' + '</td>';
        html += '<td>' + '<button id="id_edit_for_' + result.id + '" class="edit_Button">Edit</button>' + '</td>';
        html += '</tr>';
    });

    html += "</tbody>" + "</table>";

    $("#customerListDiv").append(html);
}


$("#addForm button").click(function () {

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

            alert('Success! Result = ${result}');

        })

        .fail(function (xhr, status, error) {

            alert('Fail!');
            console.log("Error", xhr, status, error);

        });
});

$("#editForm button").click(function () {
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

            alert('Success! Result = ${result}');
            console.log("Success!", result);
        })

        .fail(function (xhr, status, error) {
            console.log("Error", xhr, status, error);
            alert('Fail!');


        });
});

$("#listButton").click(function () {
    $.ajax({
        url: '/api/Customers',
        method: 'GET'

    })
        .done(function (result) {
            var properties = ["Id", "First Name", "Last Name", "Email", "Gender", "Age"];
            createTableOfObjectAndPropertiesArrays(properties, result);
            
        })

        .fail(function (xhr, status, error) {

            alert('Fail!');
            console.log("Error", xhr, status, error);

        });
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
        })

        .fail(function (xhr, status, error) {

            alert('Fail!');
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

        })

        .fail(function (xhr, status, error) {

            console.log("Error", xhr, status, error);
            alert('Fail!');

        });
});

