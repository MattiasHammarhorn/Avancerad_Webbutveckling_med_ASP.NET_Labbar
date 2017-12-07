function Clear() {
    $("#successMessage").text("");
    $("#errorMessage").text("");
}


$("#getSingleCustomer").click(function () {
    var idToSend = $("#idForAjax").val();

    $.ajax({
        url: 'api/ajax/GetCustomerWithAjax',
        method: 'GET',
        data: { id: idToSend }
    })
    .done(function (result) {
        console.log("Success!", result);
        Clear();
        $("#successMessage").text(result);
    })
    .fail(function (xhr, status, error) {
        console.log("Error!", xhr);
        Clear();
        $("#errorMessage").html(xhr.responseText);
    });
});

$("#getSingleCustomerBriefly").click(function () {
    var idToSendBrief = $("#idForAjaxBrief").val();
    var isChecked = $("#checkboxAjax").is(":checked") ? "true" : "false";

    $.ajax({
        url: 'api/ajax/GetCustomerBrieflyWithAjax',
        method: 'GET',
        data: { briefModeAjax: isChecked, id: idToSendBrief}
    })
        .done(function (result) {
            console.log("Success!", result);
            Clear();
            $("#successMessage").text(result);
        })
        .fail(function (xhr, status, error) {
            console.log("Error!", xhr);
            Clear();
            $("#errorMessage").html(xhr.responseText);
        });
});

$("#getAllCustomers").click(function () {
    $.ajax({
        url: 'api/ajax/GetAllCustomersWithAjax',
        method: 'GET'
    })
    .done(function (result) {
        console.log("Success!", result);
        Clear();
        $("#successMessage").text(result);
    })
    .fail(function (xhr, status, error) {
        console.log("Error!", xhr);
        Clear();
        $("#errorMessage").html(xhr.responseText);
    });
});