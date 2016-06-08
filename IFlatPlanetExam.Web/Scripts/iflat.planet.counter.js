function SubmiteClick() {
    $.ajax({
        url: '/IFlatPlanetExam/Insert',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

        },
        error: function () {

        }
    });
}

$(document).ready(function () {
    
    $('#submit').click(function () {
        SubmiteClick();
    });

});