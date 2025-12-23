function FillStateByCountry(CouId) {


    $.ajax({

        url: '/api/StateAPI/' + CouId,
        method: 'get',
        dataType: 'json',
        success: function (response) {

            $("#StateId").empty();
            var option = `<option>--Select State--</option>`;
            $("#StateId").append(option);
            for (item of response) {

                var option = `<option vlaue='${item.value}'>${item.text}<option>`;
                $("#StateId").append(option);
            }
        },
        error: function (err) {

            console.log(err);
        },
    });
}