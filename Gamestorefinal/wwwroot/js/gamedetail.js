$(function () {
    $('button').click(function (e) {

        $('form').attr("style","display:none");

        $('.create-new-b').hide();
        e.preventDefault();
        var id = $(this).attr("name").valueOf();
        
        $.ajax({
            url: '/Games/Details',
            data: { 'id': id}
        }).done(function (data) {
            
            $('.hero-container').html('');
            var template = $('#detailsbody').html();
            $.each(data, function (i, val) {
                var temp = template;

                $.each(val, function (key, value) {
                    temp = temp.replaceAll('{' + key + '}', value);
                });
                $('.hero-container').append(temp);
            });
        });
       
    });
});

