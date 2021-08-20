$(function () {
    $('img.mySlides').click(function (e) {
        e.preventDefault();
        var id = $(this).attr("id").valueOf();
        
        $.ajax({
            url: '/Games/Details',
            data: { 'id': id }
        }).done(function (data) {
            
            $('body').html('');
        //    var template = $('#detailsbody').html();
        //    $.each(data, function (i, val) {
        //        var temp = template;

        //        $.each(val, function (key, value) {
        //            temp = temp.replaceAll('{' + key + '}', value);
        //        });
        //        $('tbody').append(temp);
        //    });
        //});
       
    });
});

