function loadScript(src, callback) {
    var script = document.createElement("script");
    script.type = "text/javascript";
    if (callback) script.onload = callback;
    document.getElementsByTagName("head")[0].appendChild(script);
    script.src = src;
}

loadScript('https://maps.googleapis.com/maps/api/js?v=3&callback=initialize',
    function () {
        console.log('google-loader has been loaded, but not the maps-API ');
    });


function initialize() {

    var locations = [

        //['Yagur 16, Tel Aviv-Yafo', 31.96989270779013, 34.77276574513613, 2],
        //['Sheerit Yisra el St, Tel Aviv-Yafo ', 32.051947662729695, 34.76166756047575, 2],
        //['Olei Zion St, Tel Aviv-Yafo ', 32.053351260681985, 34.756746703918, 2]
    ];
    var adress, corx, cory;
    $.ajax({
        url: '/Locations/Locationsfromdb'
    }).done(function (data1) {
        $.each(data1, function (i, val) {
            $.each(val, function (key, value) {
                if (key.valueOf().match("adress_name")) {
                    adress = value.valueOf();
                }
                if (key.valueOf().match("cor_x")) {
                    corx = value.valueOf();

                }
                if (key.valueOf().match("cor_y")) {
                    cory = value.valueOf();

                }
            });
            locations.unshift({ adress, corx, cory });

        });
        var map = new google.maps.Map(document.getElementById('map'),
            {
                zoom: 13,
                scrollwheel: true,
                navigationControl: true,
                mapTypeControl: true,
                scaleControl: true,
                draggable: true,
                styles: [{
                    "stylers": [{
                        "hue": "#ff6501"
                    }, {
                        saturation: 20
                    }, {
                        gamma: 1
                    }]
                }],
                center: new google.maps.LatLng(locations[0].corx, locations[0].cory),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

        var infowindow = new google.maps.InfoWindow();

        var marker, i;

        for (i = 0; i < locations.length; i++) {

            marker = new google.maps.Marker({
                position: new google.maps.LatLng(locations[i].corx, locations[i].cory),
                map: map
                //icon: 'images/marker1.png'
            });


            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent(locations[i].adress);
                    infowindow.open(map, marker);

                }
            })(marker, i));
        }


    });

  
}

