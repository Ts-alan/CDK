'use strict';

cdkApp.service('mapService', [
'$rootScope',
'$q',
'cdkDataService',
'$state',
'$timeout',
function ($rootScope, $q, cdkDataService, $state, $timeout) {
    var self = this;

    self.mapOptions = {
        center: new google.maps.LatLng(49.2505, -123.1119),
        zoom: 12,
        zoomControlOptions: {
            style: google.maps.ZoomControlStyle.SMALL,
            position: google.maps.ControlPosition.BOTTOM_LEFT
        },
        mapTypeControl: false,
        streetViewControl: false,
        styles: [
        {
            "featureType": "administrative",
            "elementType": "labels.text.fill",
            "stylers": [{ "color": "#781611" }]
        },
        {
            "featureType": "landscape",
            "elementType": "all",
            "stylers": [{ "color": "#f2f2f2" }]
        },
        {
            "featureType": "landscape.man_made",
            "elementType": "geometry.fill",
            "stylers": [
            { "visibility": "on" },
            { "color": "#dfdfdf" }
            ]
        },
        {
            "featureType": "poi",
            "elementType": "all",
            "stylers": [{ "visibility": "off" }]
        },
        {
            "featureType": "road",
            "elementType": "all",
            "stylers": [
            { "saturation": -100 },
            { "lightness": 45 }
            ]
        },
        {
            "featureType": "road.highway",
            "elementType": "geometry.fill",
            "stylers": [
            { "gamma": "0.86" },
            { "visibility": "on" },
            { "color": "#e2b119" }
            ]
        },
        {
            "featureType": "transit",
            "elementType": "all",
            "stylers": [{ "visibility": "off" }]
        },
        {
            "featureType": "transit.station.rail",
            "elementType": "geometry.fill",
            "stylers": [
            { "visibility": "on" },
            { "hue": "#ff7100" }
            ]
        },
        {
            "featureType": "water",
            "elementType": "geometry",
            "stylers": [
            { "visibility": "on" },
            { "color": "#4980c1" }
            ]
        }
        ]
    };

    self.createMapObject = function (elementId, options) {
        return angular.element("#" + elementId).data("map") || new google.maps.Map(document.getElementById(elementId), options);
    };

    self.createMarkerFromObject = function (map, item) {
        return new google.maps.CustomMarkerLabel({
                        position: new google.maps.LatLng(item.NormalView),
                        map: map,
                        text: item.Count.toString(),
                        cssClass: item.Type === 2 ? "marker-claster" : "simple-marker",
                        animation: google.maps.Animation.DROP,
                        title: item.Type === 2 ? item.Title : null,
                        titleOnTop: item.Type === 2,
                        extMarkerData: { id: item.Id, type: item.Type },
                    });
    };

    self.createClusterMarkerFromObject = function (map, item) {
      
        return new google.maps.CustomMarkerLabel({
            position: new google.maps.LatLng(item.Latitude, item.Longitude),
                        map: map,
                        text: item.Type === "Unit" ? "1" : item.Units.length.toString(),
                        cssClass: "simple-marker",
                        animation: google.maps.Animation.DROP
                    });
    };

    $rootScope.$on("$stateChangeStart", function (event, toState, toParams, fromState, fromParams) {
    });
}]);