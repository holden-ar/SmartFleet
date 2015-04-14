var MapsGoogle = function () {

    var mapBasic = function () {
        new GMaps({
            div: '#gmap_basic',
            lat: -12.043333,
            lng: -77.028333
        });
    }

    var mapMarker = function () {
        var map = new GMaps({
            div: '#gmap_marker',
           lat: -51.38739,
                lng: -6.187181,
        });
        map.addMarker({
           lat: -51.38739,
                lng: -6.187181,
            title: 'Lima',
            details: {
                database_id: 42,
                author: 'HPNeo'
            },
            click: function (e) {
                if (console.log) console.log(e);
                alert('You clicked in this marker');
            }
        });
        map.addMarker({
            lat: -12.042,
            lng: -77.028333,
            title: 'Marker with InfoWindow',
            infoWindow: {
                content: '<span style="color:#000">HTML Content!</span>'
            }
        });
        map.setZoom(5);
    }

    var mapPolylines = function () {
        var map = new GMaps({
            div: '#gmap_polylines',
            lat: -34.5314912,
            lng: -58.7103637,
            click: function (e) {
                console.log(e);
            }
        });
/*
        path = [
            [-12.044012922866312, -77.02470665341184],
            [-12.05449279282314, -77.03024273281858],
            [-12.055122327623378, -77.03039293652341],
            [-12.075917129727586, -77.02764635449216],
            [-12.07635776902266, -77.02792530422971],
            [-12.076819390363665, -77.02893381481931],
            [-12.088527520066453, -77.0241058385925],
            [-12.090814532191756, -77.02271108990476]
        ];*/
		
		  path = [
            [-34.5314912,-58.7103637], //VTE LOPEZ
            [-34.588544,-58.4690061], //ESTOMBA
            [-34.6102754,-58.4289747], //YATAY
            [-34.622128,-58.3797133]  //SAN JUAN
        ];

        map.drawPolyline({
            path: path,
            strokeColor: '#131540',
            strokeOpacity: 0.6,
            strokeWeight: 6
        });
    }

    var mapGeolocation = function () {

        var map = new GMaps({
            div: '#gmap_geo',
            lat: -12.043333,
            lng: -77.028333
        });

        GMaps.geolocate({
            success: function (position) {
                map.setCenter(position.coords.latitude, position.coords.longitude);
            },
            error: function (error) {
                alert('Geolocation failed: ' + error.message);
            },
            not_supported: function () {
                alert("Your browser does not support geolocation");
            },
            always: function () {
                //alert("Geolocation Done!");
            }
        });
    }

    var mapGeocoding = function () {

        var map = new GMaps({
            div: '#gmap_geocoding',
            lat: -12.043333,
            lng: -77.028333
        });

        var handleAction = function () {
            var text = $.trim($('#gmap_geocoding_address').val());
            GMaps.geocode({
                address: text,
                callback: function (results, status) {
                    if (status == 'OK') {
                        var latlng = results[0].geometry.location;
                        map.setCenter(latlng.lat(), latlng.lng());
                        map.addMarker({
                            lat: latlng.lat(),
                            lng: latlng.lng()
                        });
                        Metronic.scrollTo($('#gmap_geocoding'));
                    }
                }
            });
        }

        $('#gmap_geocoding_btn').click(function (e) {
            e.preventDefault();
            handleAction();
        });

        $("#gmap_geocoding_address").keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == '13') {
                e.preventDefault();
                handleAction();
            }
        });

    }

    var mapPolygone = function () {
        var map = new GMaps({
            div: '#gmap_polygons',
            lat: -34.5314912,
            lng: -58.7103637
        });

        var path = [
            [-34.5314912,-58.7103637], //VTE LOPEZ
            [-34.588544,-58.4690061], //ESTOMBA
            [-34.6102754,-58.4289747], //YATAY
            [-34.622128,-58.3797133]  //SAN JUAN
        ];

        var polygon = map.drawPolygon({
            paths: path,
            strokeColor: '#FFCC00',
            strokeOpacity: 1,
            strokeWeight: 3,
            fillColor: '#FFCC00',
            fillOpacity: 0.6
        });
    }

    var mapRoutes = function () {

        var map = new GMaps({
            div: '#gmap_routes',
            lat: -12.043333,
            lng: -77.028333
        });
        $('#gmap_routes_start').click(function (e) {
            e.preventDefault();
            Metronic.scrollTo($(this), 400);
            map.travelRoute({
                origin: [-12.044012922866312, -77.02470665341184],
                destination: [-12.090814532191756, -77.02271108990476],
                travelMode: 'driving',
                step: function (e) {
                    $('#gmap_routes_instructions').append('<li>' + e.instructions + '</li>');
                    $('#gmap_routes_instructions li:eq(' + e.step_number + ')').delay(800 * e.step_number).fadeIn(500, function () {
                        map.setCenter(e.end_location.lat(), e.end_location.lng());
                        map.drawPolyline({
                            path: e.path,
                            strokeColor: '#131540',
                            strokeOpacity: 0.6,
                            strokeWeight: 6
                        });
                    });
                }
            });
        });
    }

    return {
        //main function to initiate map samples
        init: function () {
            //mapBasic();
            //mapMarker();
            //mapGeolocation();
            //mapGeocoding();
            //mapPolylines();
            //mapPolygone();
            //mapRoutes();
			
		//	var map = new GMaps(document.getElementById('#gmap_polylines'));
			
			  var map = new GMaps({
					div: '#gmap_polylines',
					lat: -34.5314912,
					lng: -58.7103637,
					click: function (e) {
						console.log(e);
					}
				});

			var points = [
			   new GLatLng(47.656, -122.360),
			   new GLatLng(47.656, -122.343),
			   new GLatLng(47.690, -122.310),
			   new GLatLng(47.690, -122.270)
			];

			var polyline = new GPolyline(points, '#f00', 6);

			map.setCenter(new GLatLng(47.676, -122.343), 12);
			map.addOverlay(polyline);
        }

    };

}();