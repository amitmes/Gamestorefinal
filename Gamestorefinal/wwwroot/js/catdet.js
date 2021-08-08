

$(function () {
    $('#gamesbycat').click(function (e) {
        e.preventDefault();
        var query = $('#gamesbycat').attr("name").valueOf();
        console.log(query);
        $.ajax({
            url: '/Games/Gametype',
            data: { 'query': query }
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