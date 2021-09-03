$(function () {
    $('#cartbutton').click(function (e) {
        e.preventDefault();
        var Item = $(this).attr("name").valueOf();
        
        $.ajax({
            url: '/Home/Cart',
            data: { 'email': email }
        }).done(function (data) {
            $('tbody').html('');
            var template = $('#orderedgames').html();
            $.each(data, function (i, val) {
                var temp = template;

                $.each(val, function (key, value) {
                    temp = temp.replaceAll('{' + key + '}', value);
                });
                $('tbody').append(temp);
            });
        });

    });
});