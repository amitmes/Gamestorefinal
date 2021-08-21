$(function () {
    $('a').click(function (e) {
        if ($(this).attr("class").valueOf().match("a1")) {
            $('.newlabel').hide();
            $('.car').hide();
        }
        
        e.preventDefault();
        var id = $(this).attr("name").valueOf();
        console.log(id);
        $.ajax({
            url: '/Games/Details',
            data: { 'id': id}
        }).done(function (data) {
            
            $('tbody').html('');
            var template = $('#detailsbody').html();
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

