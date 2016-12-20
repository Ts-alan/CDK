'use strict';

cdkApp.service('mapResultService', [
'$rootScope',
'cdkDataService',
'mapService',
'$state',
'$timeout',
'$compile',
'$q',
function ($rootScope, cdkDataService, mapService, $state, $timeout, $compile, $q) {
    var self = this;

    self.scope = {
        $scope: null,
        mapObject: {
            map: null,
            mapMarkers: [],
            loaded: false
        },
        listObject: {
            loaded: false
        },
        galleryObject: {
            loaded: false
        },
        items: {
            total: 0,
            list: []
        },

        get map() {
            return this.mapObject.map;
        },

        set map(value) {
            this.mapObject.map = value;
        },

        get mapLoaded() {
            return this.mapObject.loaded;
        },

        set mapLoaded(value) {
            this.mapObject.loaded = value;
        },

        get listLoaded() {
            return this.listObject.loaded;
        },

        set listLoaded(value) {
            this.listObject.loaded = value;
        },

        get galleryLoaded() {
            return this.galleryObject.loaded;
        },

        set galleryLoaded(value) {
            this.galleryObject.loaded = value;
        },

        reset: function () {
            this.$scope = null;

            this.mapObject = {
                map: null,
                mapMarkers: [],
                loaded: false
            };
            this.listObject = {
                loaded: false
            };
            this.galleryObject = {
                loaded: false
            };

            this.items.total = 0;
            this.items.list.length = 0;
        }
    };

    self.init = function ($scope) {
        self.scope.$scope = $scope;
        _setBodyClass();

        var deferred = $q.defer();

        $timeout(function () {
            switch (_getType()) {
                case "map":
                    _initMap().then(function () {
                        deferred.resolve();
                    });
                    break;
                case "gallery":
                    _initGallery().then(function () {
                        deferred.resolve();
                    });
                    break;
                case "list":
                    _initMap().then(function () {
                        _initList().then(function () {
                            deferred.resolve();
                        });
                    });
                    break;
                default:
                    deferred.resolve();
                    break;
            }
        });

        return deferred.promise;
    };

    self.sync = function () {
        var deferred = $q.defer();

        $timeout(function () {
            switch (_getType()) {
                case "map":
                    _syncMap(self.scope.mapObject, $state).then(function () {
                        deferred.resolve();
                    });
                    break;
                case "gallery":
                    _syncGallery(self.scope, $state).then(function () {
                        deferred.resolve();
                    });
                    break;
                case "list":
                    _syncMap(self.scope.mapObject, $state).then(function () {
                        _syncList(self.scope, $state).then(function () {
                            deferred.resolve();
                        });
                    });
                    break;
                default:
                    deferred.resolve();
                    break;
            }
        });

        return deferred.promise;
    };

    self.destroy = function () {
        _setBodyClass();
        if (self.scope.mapObject.map) {
            google.maps.event.clearInstanceListeners(self.scope.mapObject.map);
            delete (self.scope.mapObject.map);
            angular.element("#map-result-controll").html("");
        }

        self.scope.reset();
    };

    self.setBodyClass = function () {
        _setBodyClass();
    };

    self.getMap = function () {
        if (!angular.element("#map-result-controll").length) {
            return null;
        }

        self.scope.map = self.scope.map || mapService.createMapObject("map-result-controll", mapService.mapOptions);

        return self.scope.map;
    };

    //#region Private
    var infowindow = new google.maps.InfoWindow({
        maxWidth: 300,
        content: "<div id='info-window-content'></div>"
    });

    google.maps.event.addListener(infowindow, 'domready', function () {
        var iwOuter = $('.gm-style-iw');
        var iwBackground = iwOuter.prev();

        iwBackground.children(':nth-child(2)').css({ 'display': 'none' });
        iwBackground.children(':nth-child(4)').css({ 'display': 'none' });

        iwOuter.closest('div').css({ width: '300px !important' });

        iwBackground.children(':nth-child(3)').find('div').children().css({ 'box-shadow': 'none', 'z-index': '1' });
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

        iwCloseBtn.mouseout(function () {
            $(this).css({ opacity: '1' });
        });

    });

    var _getType = function () {
        var mapType = $state.params.type;

        if ($state.current.name !== "map") {
            return null;
        }

        if (!(mapType === 'map' || mapType === 'gallery' || mapType === 'list')) {
            mapType = 'map';
        }

        return mapType;
    };

    var _setBodyClass = function () {
        switch (_getType()) {
            case "map":
                $rootScope.bodylayout = "switch-screen map-class-js footer-not-visible";
                break;
            case "gallery":
                $rootScope.bodylayout = "switch-screen gallery-class-js";
                break;
            case "list":
                $rootScope.bodylayout = "switch-screen list-class-js footer-not-visible";
                break;
            default:
                $rootScope.bodylayout = "";
                break;
        }
    };

    //#region Gallery
    var _syncGallery = function (scope) {
        var deferred = $q.defer();

        scope.items.list.length = 0;
        scope.items.total = 0;

        cdkDataService.getGalleryView(
        cdkDataService.buildSeachFilter($state))
        .then(function (result) {
            scope.items.list.push.apply(scope.items.list, result.data.Units);
            scope.items.total = result.data.TotalCount;
            deferred.resolve();
        }, function () {
        });

        return deferred.promise;
    };

    var _initGallery = function () {
        var deferred = $q.defer();

        _syncGallery(self.scope).then(function () {
            self.scope.galleryLoaded = true;
            deferred.resolve();
        });

        return deferred.promise;
    };

    //#endregion

    //#region Map

    var _syncMap = function (mapObject, $state, skipZoom, mergerMarkers) {
        var deferred = $q.defer();

        var mapMarkers = mapObject.mapMarkers;
        var map = mapObject.map;

        cdkDataService
        .getMarkersGeo(cdkDataService.buildSeachFilter($state, map.getBoundsAsPolygonCords(), !skipZoom ? map.getZoom() : null))
        .then(function (markers) {
            if (!mergerMarkers) {
                for (var i = 0; i < mapMarkers.length; i++) {
                    google.maps.event.clearInstanceListeners(mapMarkers[i]);
                    mapMarkers[i].setMap(null);
                }

                mapMarkers.length = 0;
            }

            $timeout(function () {
                markers.data
                .filter(function (item) {
                    return item.Count > 0;
                })
                .forEach(function (item) {
                    if (mergerMarkers) {
                        var alreadyAdded = mapMarkers.filter(function (element) {
                            return element.extMarkerData.id === item.Id && element.extMarkerData.type === item.Type;
                        });

                        if (alreadyAdded.length) {
                            return;
                        }
                    }

                    var marker = mapService.createMarkerFromObject(map, item);

                    var markerObj = marker;

                    google.maps.event.addListener(marker, 'click', function (e) {
                        if (item.Type === 2) {
                            markerObj.setMap(null);
                            map.setCenter(new google.maps.LatLng(item.NormalView));
                            if (map.getZoom() < 12) {
                                map.setZoom(13);
                            } else {
                                map.setZoom(map.getZoom() + 1);
                            }
                        }

                        if (item.Type === 0) {
                            cdkDataService.getInfoWindowData(cdkDataService.buildSeachFilter(
                            $state,
                            null,
                            null,
                            item.Id)).then(function (obj) {
                                var content = '<map-info-window></map-info-window>';
                                if (obj.data) {
                                    infowindow.open(map, markerObj);
                                    $compile(content)($rootScope, function (clonedElement, scope) {
                                        scope.dataModel = obj.data;
                                        $timeout(function () {
                                            angular.element("#info-window-content").html('');
                                            angular.element("#info-window-content").append(clonedElement);
                                        });
                                    });
                                }
                            });

                        }
                    });

                    mapMarkers.push(marker);
                });
                deferred.resolve();
            });
        });

        return deferred.promise;
    };

    var _initMap = function () {
        var deferred = $q.defer();

        var scope = self.scope.mapObject;
        scope.notTriggerZoom = false;
        scope.centerObj = {};
        var map = self.getMap();
        self.scope.mapLoaded = true;

        cdkDataService
        .getCenterData(cdkDataService.buildSeachFilter($state))
        .then(function (center) {
            scope.centerObj = center.data;
            map.data.setStyle(function (feature) {
                if (feature.getProperty("ntype") === scope.centerObj.Type
                && feature.getProperty("data-id") === scope.centerObj.Id) {
                    return {
                        strokeColor: "#000000",
                        strokeOpacity: 1,
                        strokeWeight: 3,
                        fillColor: '#A1A2A5',
                        fillOpacity: 0.35,
                        zIndex: 1000
                    };
                }

                return {
                    strokeColor: "#A1A2A5",
                    strokeOpacity: 1,
                    strokeWeight: 2,
                    fillColor: '#A1A2A5',
                    fillOpacity: 0
                };
            });

            if ($state.params.city && $state.params.state) {
                map.data.loadGeoJson(cdkDataService.getGeoJsonURL(cdkDataService.buildSeachFilter($state)));
            }

            var centerObj = scope.centerObj;

            var bounds = new google.maps.LatLngBounds();

            map.data.addListener('addfeature', function (e) {
                if (!centerObj.Id || !centerObj.Type) {
                    google.maps.helpers.processPoints(e.feature.getGeometry(), bounds.extend, bounds);
                    map.fitBounds(bounds);
                } else {
                    if (e.feature.getProperty("ntype") === centerObj.Type
                    && e.feature.getProperty("data-id") === centerObj.Id) {
                        google.maps.helpers.processPoints(e.feature.getGeometry(), bounds.extend, bounds);
                        map.fitBounds(bounds);
                        map.setCenter(bounds.getCenter());
                    }
                }
            });

            $timeout(function () {
                var idle = google.maps.event.addListener(map, 'idle', function () {
                    _syncMap(scope, $state).then(function () {
                        google.maps.event.addListener(map, 'zoom_changed', function () {
                            if (scope.notTriggerZoom) {
                                scope.notTriggerZoom = false;
                            } else {
                                for (var i = 0; i < scope.mapMarkers.length; i++) {
                                    scope.mapMarkers[i].setMap(null);
                                }

                                _syncMap(scope, $state).then(function () { });
                            }
                        });

                        google.maps.event.addListener(map, 'zoom_changed', function () {
                            var currentZoom = map.getZoom();
                            var centerObj = scope.centerObj;

                            map.data.forEach(function (feature) {
                                if (feature.getProperty("ntype") === centerObj.Type
                                && feature.getProperty("data-id") === centerObj.Id) {
                                    return;
                                }
                            });
                        });

                        google.maps.event.addListener(map, 'dragend', function () {
                            if (scope.notTriggerZoom) {
                                scope.notTriggerZoom = false;
                            } else {
                                _syncMap(scope, $state, false, true).then(function () { });
                            }
                        });

                        deferred.resolve();
                    });

                    google.maps.event.removeListener(idle);
                });
            }, 100);
        });

        return deferred.promise;
    };

    //#endregion 

    //#region List

    var _initList = function () {
        var deferred = $q.defer();

        self.scope.listLoaded = true;

        _syncList(self.scope).then(function () {
            deferred.resolve();
        })


        google.maps.event.addListener(self.scope.map, 'zoom_changed', function () {
            _syncList(self.scope).then(function () { });
        });

        google.maps.event.addListener(self.scope.map, 'dragend', function () {
            _syncList(self.scope).then(function () { });
        });


        return deferred.promise;
    };

    var _syncList = function (scope) {
        var deferred = $q.defer();

        scope.items.list.length = 0;
        scope.items.total = 0;
        $timeout(function () {
            cdkDataService.getListView(
            cdkDataService.buildSeachFilter($state, scope.map.getBoundsAsPolygonCords()))
            .then(function (result) {
                scope.items.list.push.apply(scope.items.list, result.data.Units);
                scope.items.total = result.data.TotalCount;
                deferred.resolve();
            }, function () {
                deferred.resolve();
            });
        }, 300);

        return deferred.promise;
    };

    //#endregion

    //#endregion 
}]);