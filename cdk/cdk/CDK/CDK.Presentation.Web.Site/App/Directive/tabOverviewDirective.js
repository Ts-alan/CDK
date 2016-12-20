cdkApp.directive('tabOverview', [ 'mapService', function ( mapService) {
    return {
        restrict: 'E',
        scope: { data: "=data" },
        templateUrl: '/app/Directive/Partials/_tabOverview.html',
        controller:['$scope', 'mapService', function ($scope, mapService) {
          
            mapService.mapOptions.center = new google.maps.LatLng($scope.data.Latitude,$scope.data.Longitude);
            mapService.mapOptions.zoom = 16;
            mapService.mapOptions.draggable = false;
            mapService.mapOptions.scrollwheel = false;
            mapService.mapOptions.zoomControl=false,
            mapService.mapOptions.disableDoubleClickZoom = true;
            var map = mapService.createMapObject("tab-map", mapService.mapOptions);
            mapService.createClusterMarkerFromObject(map, $scope.data);
        
        }]
}
}]);