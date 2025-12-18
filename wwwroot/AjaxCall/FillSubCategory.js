function FillSubCategorybyCatgory(CatId) {
    debugger;
    $.ajax({
       
        url: '/api/SubCategoryAPI/' + CatId,
        method: 'get',
        dataType: 'json',
        success: function (response)
        {
            $("#SubCategoryId").empty();
            var option = `<option>--Select SubCategory</option>`;
            $("#SubCategoryId").append(option);
            for (item of response) {

                var option = `<option value='${item.value}'>${item.text}</option>`;
                $("#SubCategoryId").append(option);
            }
        },
        error: function (err) {

            console.log(err);
        }
    });
}