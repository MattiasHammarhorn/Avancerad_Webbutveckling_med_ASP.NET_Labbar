$(document).ready(function () {
    getAllUserEmails();
});

$("#seedBtn").click(function () {
    $.ajax({
        url: 'user/seedDatabase',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
            getAllUserEmails();
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#signInBtn").click(function () {
    var signInDropdownValue = $("#signInDropdown").val();

    $.ajax({
        url: 'user/login',
        method: 'GET',
        data: {
            email: signInDropdownValue
        }
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#getUsersWithClaimsBtn").click(function () {
    $.ajax({
        url: 'user/GetApplicationUsersWithClaims',
        method: 'GET'
    })
        .done(function (result) {
            console.log(result);
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

function getAllUserEmails() {
    $.ajax({
        url: 'user/GetApplicationUserEmails',
        method: 'GET'
    })
        .done(function (result) {
            console.log("Success!", result);
            buildUserEmailsList(result);
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
}

function buildUserEmailsList(result) {

    for (var i = 0; result.length > i; i++) {
        $("#signInDropdown").append("<option>" + result[i] + "</option>");
    }
}

$("#openNewsAccessBtn").click(function () {
    $.ajax({
        url: 'check/CanSeeOpenNews',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#hiddenNewsAccessBtn").click(function () {
    $.ajax({
        url: 'check/CanSeeHiddenNews',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#hiddenNewsAge20AccessBtn").click(function () {
    $.ajax({
        url: 'check/CanSeeHiddenNewsAndIsOver20YearsOld',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#publishAccessBtn").click(function () {
    $.ajax({
        url: 'check/CanPublishNews',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#publishEconomyAccessBtn").click(function () {
    $.ajax({
        url: 'check/CanPublishEconomyNews',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#publishSportsAccessBtn").click(function () {
    $.ajax({
        url: 'check/CanPublishSportsNews',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});

$("#publishCultureAccessBtn").click(function () {
    $.ajax({
        url: 'check/CanPublishCultureNews',
        method: 'GET'
    })
        .done(function () {
            console.log("Success!");
        })
        .fail(function (xhr, status, error) {
            console.log(xhr, status, error);
        });
});
