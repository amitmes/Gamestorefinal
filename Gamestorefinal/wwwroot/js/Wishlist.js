$(function () {
    $('.cartdetails').click(function (e) {
        e.preventDefault();
        var email = $(this).attr("name").valueOf();
        console.log(email);
        $.ajax({
            url: '/Home/Cart',
            data: { 'email': email }
        }).done(function (data) {
            $('.firsttry').html('');
            var template = $('.cartbody').html();
            $.each(data, function (i, val) {
                var temp = template;
                $.each(val, function (key, value) {
                    console.log(key);
                    console.log(value);
                    if ((key.valueOf().match("name"))) {
                        console.log("here name");
                        temp = temp.replace('{' + key + '}', value);
                    }
                   
                        //temp = temp.replaceAll('{' + key + '}', value);
                        
                    
                });
                $('.firsttry').append(temp);
            });
        });

    });
});