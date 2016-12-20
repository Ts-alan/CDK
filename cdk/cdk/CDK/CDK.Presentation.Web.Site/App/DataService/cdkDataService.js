cdkApp.factory('cdkDataService', ['$http', 'ngAuthSettings',
function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var dataService = {};

    var getAreas = function (searchCreateria) {
        return $http({
            url: serviceBase + 'Search/Areas',
            method: "GET",
            params: { searchCreateria: searchCreateria }
        });
    };

    var getNeighborhoods = function (state, area, searchCreateria) {
        return $http({
            url: serviceBase + 'Search/Neighborhoods',
            method: "GET",
            params: { state: state, area: area, searchCreateria: searchCreateria }
        });
    };

    var getAreaByValue = function (value) {
        return $http({
            url: serviceBase + 'Search/AreaByValue',
            method: "GET",
            params: { value: value }
        });
    };

    var getNeighborhoodByValue = function (value) {
        return $http({
            url: serviceBase + 'Search/NeighborhoodByValue',
            method: "GET",
            params: { value: value }
        });
    };

    var getPopularAreas = function () {
        return $http.get(serviceBase + 'Search/PopularAreas');
    };

    var getBedsFilter = function () {
        return $http.get(serviceBase + 'Search/BedsFilter');
    };
    var getGetPrice = function () {
        return $http.get(serviceBase + 'Search/GetPrice');
    };


    var getStringForGallery = function (value,state,city) {
        
        return $http({
            url: serviceBase + 'Search/Map/GetStringForGallery?TransactionType=' + value + '&State=' + state + '&city=' + city,
            method: "GET"
        });
    };


    var getDetailsPopup = function (id, type) {

        return $http({
            url: serviceBase + 'Search/GetDetailsPopup?id=' + id + '&type=' + type,
            method: "GET"

        });
    };
    var getDetails = function (value) {

        return $http({
            url: serviceBase + 'Search/GetDetails?searchString=' + value,
            method: "GET"
        });
    };

    var getCenterPolygonGeo = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/Center?' + value,
            method: "GET"
        });
    };

    var getMarkersGeo = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/Markers?' + value,
            method: "GET"
        });
    };

    var getGeoJSON = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/Geojson?' + value,
            method: "GET"
        });
    };

    var getCenterData = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/CenterData?' + value,
            method: "GET"
        });
    };

    var getInfoWindowData = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/InfoWindowData?' + value,
            method: "GET"
        });
    };

    var getListView = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/ListView?' + value,
            method: "GET"
        });
    };

    var getGalleryView = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/GalleryView?' + value,
            method: "GET"
        });
    };

    var getGeoJsonURL = function (value) {
        return serviceBase + 'Search/Map/Geojson?' + value;
    };

    var buildSeachFilter = function ($state, coordinates, zoomLevel, objectId, page) {
        var filter = "";

        for (var key in $state.params) {
            var value = $state.params[key];
            if (value) {
                if (Object.prototype.toString.call(value) === '[object Array]') {
                    for (var i = 0; i < value.length; i++) {
                        filter += "&" + key + "=" + value[i];
                    }
                } else {
                    filter += "&" + key + "=" + value;
                }
            }
        }
        if (coordinates && coordinates.length) {
            for (var i = 0; i < coordinates.length; i++) {
                filter += "&coordinates=[" + coordinates[i][0] + "," + coordinates[i][1] + "]";
            }
        }

        if (zoomLevel) {
            filter += "&zoom=" + zoomLevel;
        }

        if(objectId){
            filter += '&objectId=' + objectId;
        }

        if(page){
            filter += '&page=' + page;
        }

        return filter;
    };

    var getPolygonsGeo = function (value) {
        return $http({
            url: serviceBase + 'Search/Map/Polygons?' + value,
            method: "GET"
        });
    };

    dataService.getAreas = getAreas;
    dataService.getPopularAreas = getPopularAreas;
    dataService.getBedsFilter = getBedsFilter;
    dataService.getAreaByValue = getAreaByValue;
    dataService.getNeighborhoods = getNeighborhoods;
    dataService.getNeighborhoodByValue = getNeighborhoodByValue;
    dataService.getGetPrice = getGetPrice;
    dataService.getDetails = getDetails;
    dataService.buildSeachFilter = buildSeachFilter;
    dataService.getPolygonsGeo = getPolygonsGeo;
    dataService.getCenterPolygonGeo = getCenterPolygonGeo;
    dataService.getMarkersGeo = getMarkersGeo;
    dataService.getGeoJSON = getGeoJSON;
    dataService.getGeoJsonURL = getGeoJsonURL;
    dataService.getCenterData = getCenterData;

    dataService.getDetailsPopup = getDetailsPopup;

    dataService.getInfoWindowData = getInfoWindowData;
    dataService.getListView = getListView;
    dataService.getGalleryView = getGalleryView;
    dataService.getStringForGallery = getStringForGallery;
    return dataService;
}]);