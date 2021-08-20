$(function () {
    $('button').click(function (e) {

        $('form').attr("style","display:none");
        
        e.preventDefault();
        var id = $(this).attr("name").valueOf();
        
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

