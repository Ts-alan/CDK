$(document).ready(function() {
  var map, infobox;
  var markers = [];
  var markerClusterer = null;
  function initialize() {
       var Options = {
          center: new google.maps.LatLng(56, 37),
          zoom: 8
          // disableDefaultUI: false,
          // scrollwheel: true,
          // zoomControl: true,
          // zoomControlOptions: {
          // style: google.maps.ZoomControlStyle.LARGE,
          // position: google.maps.ControlPosition.TOP_LEFT
          // },
          // panControl: true,
          // mapTypeControl: true,
          // scaleControl: true,
          // streetViewControl: true,
          // overviewMapControl: true,
          // mapTypeId: google.maps.MapTypeId.ROADMAP
       };
       map = new google.maps.Map(document.getElementById("map_canvas"), Options);

       var image = new google.maps.MarkerImage('../Content/images/marker.png',
        new google.maps.Size(28, 38),
        new google.maps.Point(0,0),
        new google.maps.Point(14, 35)
       );

       var imageHover = new google.maps.MarkerImage('../Content/images/marker-hover.png',
        new google.maps.Size(28, 38),
        new google.maps.Point(0,0),
        new google.maps.Point(14, 35)
       );


       var marker = new google.maps.Marker({
         position: new google.maps.LatLng('56', '37'),
         title: 'Marker Title',
         icon: image
       });
       markers.push(marker);

       var marker = new google.maps.Marker({
         position: new google.maps.LatLng('56', '37.1'),
         title: 'Marker Title',
         icon: image
       });
       markers.push(marker);

       var clusterStyles = [
         {
           textColor: 'black',
           textSize: 14,
           url: '../Content/images/cluster-small.png',
           height: 40,
           width: 40
         },
        {
           textColor: 'black',
           textSize: 16,
           url: '../Content/images/cluster-medium.png',
           height: 50,
           width: 50
         },
        {
           textColor: 'black',
           textSize: 16,
           url: '../Content/images/cluster-large.png',
           height: 60,
           width: 60
         }
       ];


       markerClusterer = new MarkerClusterer(map, markers,
      {
        maxZoom: 13,
        gridSize: 50,
        styles: clusterStyles
      });

      var content = document.createElement('div');
      var mc = document.getElementById("iw-container").innerHTML;
      content.innerHTML = mc;
      content.setAttribute("id", "iw-container");

      var infowindow = new google.maps.InfoWindow({
       content: content,
       maxWidth: 300
      });


     google.maps.event.addListener(marker, 'click', function() {
         infowindow.open(map,marker);
     });

     google.maps.event.addListener(map, 'click', function() {
       infowindow.close();
     });

    	google.maps.event.addListener(marker, 'click', function() {
    	 infowindow.open(map, this);
    	});

      google.maps.event.addListener(marker, 'mouseover', function() {
          marker.setIcon(imageHover);
      });
      google.maps.event.addListener(marker, 'mouseout', function() {
          marker.setIcon(image);
      });

      google.maps.event.addListener(infowindow, 'domready', function() {

        // http://en.marnoto.com/2014/09/5-formas-de-personalizar-infowindow.html

        var iwOuter = $('.gm-style-iw');
        var iwBackground = iwOuter.prev();

        iwBackground.children(':nth-child(2)').css({'display' : 'none'});
        iwBackground.children(':nth-child(4)').css({'display' : 'none'});

        iwOuter.closest('div').css({width: '300px !important'});

        iwBackground.children(':nth-child(3)').find('div').children().css({'box-shadow': 'none', 'z-index' : '1'});
        var iwCloseBtn = iwOuter.next();

        iwCloseBtn.css({
          opacity: '1',
          right: '45px', top: '30px',
          width: 15,
          height: 15
        });

        iwCloseBtn.empty();
        var elemImg = document.createElement("img");
        elemImg.setAttribute("src", "../Content/images/close-icon-pink.png");
        iwCloseBtn.append(elemImg);

        iwCloseBtn.mouseout(function(){
          $(this).css({opacity: '1'});
        });

    });
  }
  google.maps.event.addDomListener(window, 'load', initialize);

});
