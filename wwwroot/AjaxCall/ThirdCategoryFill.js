function SubCategoryIdbyThirdCategoryId(SubCatId) {

    $.ajax({

        url: '/api/ThirdCategoryAPI/' + SubCatId,
        method: 'get',
        dataType: 'json',
        success: function (response) {

            $("#ThirdCategoryId").empty();
            var option = `<option>--Select ThirCategory--</option>`;
            $("#ThirdCategoryId").append(option);
            for (item of response) {

                var option = `<option value= '${item.value}'>${item.text}</option>`;
                $("#ThirdCategoryId").append(option);
            }
        },
        error: function (err) {

            console.log(err);
        }
    });
}