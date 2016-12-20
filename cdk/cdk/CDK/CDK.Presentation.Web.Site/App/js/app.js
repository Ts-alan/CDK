var cdkApp = angular.module('cdkApp', [
'ngRoute',
'ngResource',
'ui.bootstrap',
'LocalStorageModule',
'ui.router',
'angular-loading-bar',
'ui-notification',
'ngSanitize',
'ngAnimate',
'ui.select',
'angularjs-dropdown-multiselect',
'ngAside',
'slickCarousel',
'updateMeta',
'hm.readmore'
]);

var serviceBase = '/API/';
cdkApp.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'self'
});

cdkApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

cdkApp.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = false;
}]);

cdkApp.config(function (uiSelectConfig) {
    uiSelectConfig.theme = 'select2';
});

cdkApp.config(function (NotificationProvider) {
    NotificationProvider.setOptions({
        delay: 10000,
        startTop: 20,
        startRight: 10,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'center',
        positionY: 'top'
    });
});


cdkApp.run(['$rootScope', '$uibModalStack', 'authService', 'cdkDataService',
    function ($rootScope, $uibModalStack, authService, cdkDataService) {
        $rootScope.$on('$locationChangeStart', function ($event) {
            var openedModal = $uibModalStack.getTop();
            if (openedModal) {
                if (!!$event.preventDefault) {
                    $event.preventDefault();
                }
                if (!!$event.stopPropagation) {
                    $event.stopPropagation();
                }
                $uibModalStack.dismiss(openedModal.key);
            }
        });

        authService.fillAuthData();
    }]);



_.contains = _.includes;


function mapsCallback() {
    google.maps.helpers = {}

    google.maps.helpers.processPoints = function (geometry, callback, thisArg) {
        if (geometry instanceof google.maps.LatLng) {
            callback.call(thisArg, geometry);
        } else if (geometry instanceof google.maps.Data.Point) {
            callback.call(thisArg, geometry.get());
        } else {
            geometry.getArray().forEach(function (g) {
                google.maps.helpers.processPoints(g, callback, thisArg);
            });
        }
    };


    google.maps.Polygon.prototype.getBounds = function () {
        var bounds = new google.maps.LatLngBounds();
        var paths = this.getPaths();
        var path;
        for (var i = 0; i < paths.getLength() ; i++) {
            path = paths.getAt(i);
            for (var ii = 0; ii < path.getLength() ; ii++) {
                bounds.extend(path.getAt(ii));
            }
        }
        return bounds;
    };

    google.maps.Map.prototype.getBoundsRect = function () {
        var lat0 = this.getBounds().getNorthEast().lat();
        var lng0 = this.getBounds().getNorthEast().lng();
        var lat1 = this.getBounds().getSouthWest().lat();
        var lng1 = this.getBounds().getSouthWest().lng();

        return [[lat1, lng1], [lat1, lng0], [lat0, lng0], [lat0, lng1]];
    };

    google.maps.Map.prototype.getBoundsAsPolygonCords = function () {
        var lat0 = this.getBounds().getNorthEast().lat();
        var lng0 = this.getBounds().getNorthEast().lng();
        var lat1 = this.getBounds().getSouthWest().lat();
        var lng1 = this.getBounds().getSouthWest().lng();

        return [[lat1, lng1], [lat1, lng0], [lat0, lng0], [lat0, lng1], [lat1, lng1]];
    };

    google.maps.LatLngBounds.prototype.getBoundsZoomLevel = function (mapDim) {
        var WORLD_DIM = { height: 256, width: 256 };
        var ZOOM_MAX = 21;

        function latRad(lat) {
            var sin = Math.sin(lat * Math.PI / 180);
            var radX2 = Math.log((1 + sin) / (1 - sin)) / 2;
            return Math.max(Math.min(radX2, Math.PI), -Math.PI) / 2;
        }

        function zoom(mapPx, worldPx, fraction) {
            return Math.floor(Math.log(mapPx / worldPx / fraction) / Math.LN2);
        }

        var ne = this.getNorthEast();
        var sw = this.getSouthWest();

        var latFraction = (latRad(ne.lat()) - latRad(sw.lat())) / Math.PI;

        var lngDiff = ne.lng() - sw.lng();
        var lngFraction = ((lngDiff < 0) ? (lngDiff + 360) : lngDiff) / 360;

        var latZoom = zoom(mapDim.height, WORLD_DIM.height, latFraction);
        var lngZoom = zoom(mapDim.width, WORLD_DIM.width, lngFraction);

        return Math.min(latZoom, lngZoom, ZOOM_MAX);
    }

    google.maps.CustomMarkerLabel = function (opt_options) {
        // Initialization
        var self = this;
        self.setValues(opt_options);

        var marker = self._marker = document.createElement('div');

        marker.className = "custom-marker " + (opt_options.cssClass || "marker-claster");

        var div = self._container = document.createElement('div');

        var pin = document.createElement('div');

        pin.className = "pulse";

        div.appendChild(marker);
        div.appendChild(pin);
        div.style.cssText = 'position: absolute; display: none';
        
        if (self.get('titleOnTop')) {
            var topTitle = document.createElement('span');
            topTitle.className = "custom-marker-title " + (self.get('cssClass') || "marker-claster") + "-title";

            topTitle.innerHTML = self.get('title').toString();
            self._marker.appendChild(topTitle);
        } else {
            if (self.get('title')) {
                self._marker.title = self.get('title').toString();
            }
        }

        self._marker.innerHTML += "<span class='text-content'>" + self.get('text').toString() + "</span>";
    };
    google.maps.CustomMarkerLabel.prototype = new google.maps.OverlayView;

    // Implement onAdd
    google.maps.CustomMarkerLabel.prototype.onAdd = function () {
        var self = this;

        self.getPanes().overlayMouseTarget.appendChild(this._container);

        // Ensures the label is redrawn if the text or position is changed.
        self.listeners_ = [
        google.maps.event.addListener(self, 'position_changed', function () {
            self.draw();
        }),
        google.maps.event.addListener(self, 'text_changed', function () {
            self.draw();
        }),
        google.maps.event.addDomListener(self._marker, 'click', function (e) {
            google.maps.event.trigger(self, 'click', e);
        }),
        google.maps.event.addDomListener(self._marker, 'mouseover', function (e) {
            var title = this.getElementsByTagName("span")[0];
            if (title) {
                title.style.left = -(title.offsetWidth / 2 - this.offsetWidth / 2) + "px";
            }
        })];
    };

    // Implement onRemove
    google.maps.CustomMarkerLabel.prototype.onRemove = function () {

        this._container.parentNode.removeChild(this._container);
        //this.getPanes().overlayMouseTarget.removeChild(this._container)
        // Label is removed from the map, stop updating its position/text.
        for (var i = 0, I = this.listeners_.length; i < I; ++i) {
            google.maps.event.removeListener(this.listeners_[i]);
        }
    };

    // Implement draw
    google.maps.CustomMarkerLabel.prototype.draw = function () {
        var self = this;

        var projection = self.getProjection();
        var position = projection.fromLatLngToDivPixel(self.get('position'));

        var div = self._container;

        div.style.left = position.x + 'px';
        div.style.top = position.y + 'px';
        div.style.display = 'block';
    };
};




(function () {
    window.mobilecheck = function () {
        var check = false;
        (function (a) { if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4))) check = true })(navigator.userAgent || navigator.vendor || window.opera);
        return check;
    };

    window.mobileAndTabletcheck = function () {
        var check = false;
        (function (a) { if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino|android|ipad|playbook|silk/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4))) check = true })(navigator.userAgent || navigator.vendor || window.opera);
        return check;
    };

    if (!String.prototype.includes) {
        String.prototype.includes = function () {
            'use strict';
            return String.prototype.indexOf.apply(this, arguments) !== -1;
        };
    };
})();
cdkApp.config(['$routeProvider', '$locationProvider', '$stateProvider', function ($routeProvider, $locationProvider, $stateProvider) {

    $stateProvider
        .state('home', {
            url: "/?:status",
            params: {
                status: {
                    value: null,
                    squash: true
                }
            },
            views: {
                "body": {
                    templateUrl: "/app/View/home.html",
                    controller: "homeController"
                }
            }
        })
        .state('mapBase', {
            abstract: true,
            url: '/search/:state/:city',
            params: {
                city: {
                    value: null,
                    squash: false
                },
                state: {
                    value: null,
                    squash: false
                }
            },
            views: {
                "body": {
                    templateUrl: "/app/View/map.html"
                },
                "mapfilter": {
                    templateUrl: "/app/View/Partials/_mapFilter.html"
                }
            }
        })
        .state('map', {
            url: "/:nNeighborhood/:mNeighborhood/:sNeighborhood?:type&:minPrice&:maxPrice&:beds&:page&:sortBy&:transaction",
            params: {
                type: {
                    value: window.mobilecheck() ? "gallery" : "map",
                    squash: true
                },
                minPrice: {
                    value: "0",
                    squash: true
                },
                maxPrice: {
                    value: "Max",
                    squash: true
                },
                beds: {
                    array: true

                },
                transaction: {
                    value: "0",
                    squash: true
                },
                page: {
                    value: "1",
                    squash: true
                },
                sortBy: {
                    value: "0",
                    squash: true
                },
                nNeighborhood: {
                    value: null,
                    squash: true
                },
                mNeighborhood: {
                    value: null,
                    squash: true
                },
                sNeighborhood: {
                    value: null,
                    squash: true
                }
            },
            parent: "mapBase",
            views: {
            }
        })
        .state('reset', {
            url: "/reset?code={}",
            views: {
                "body": { templateUrl: "/app/View/reset.html" }
            }
        })
        .state('account', {
            url: "/account",
            views: {
                "secondnav": { templateUrl: "/app/View/Account/Partials/subnav.html" },
                "body": { templateUrl: "/app/View/Account/index.html" }
            },
            abstract: true
        })
        .state('account.edit', {
            url: "",
            views: {
                "subbody": { templateUrl: "/app/View/Account/edit.html" }
            }
        })
 
        .state("path", {
            url: "/{path:.*}",

            views: {
                "secondnav": { templateUrl: "/App/View/Partials/_partDetails.html", controller: 'detailsController' },
                "body": {
                    controller: 'detailsController',
                    templateUrl: "/app/View/details.html"
                }
            }

        });


    $stateProvider.state("otherwise", {
        url: "/404",
        views: {
            "body": { templateUrl: "/app/View/Partials/404.html" }
        }
    });


    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $locationProvider.hashPrefix('!');
}]);

'use strict';
cdkApp.controller('accountController', ['$scope', '$location', '$document', 'ngAuthSettings', '$state', 'userService', 'validationErrorsParser',
function ($scope, $location, $document, ngAuthSettings, $state, userService, validationErrorsParser) {
    var controller = this;

    $scope.user = {};

    $scope.userMessage = '';
    $scope.passwordMessage = '';

    userService.getUserData().then(function (d) {
        $scope.user = d.data;

    }, function () {
        //$location.path('/');
    });

    $scope.passwordModel = {
        oldPassword: "",
        newPassword: "",
        confirmPassword: ""
    };

    $scope.updateUser = function () {
        userService.updateUser($scope.user).then(function (response) {
            $state.go($state.current, {}, { reload: true });
        },
        function (err) {
            $scope.userError = err.data;
            $scope.userError.Messages = validationErrorsParser.parseError(err);
        });
    };

    $scope.updatePassword = function () {
        userService.updatePassword($scope.passwordModel).then(function (response) {
            $state.go($state.current, {}, { reload: true });
        },
        function (err) {
            $scope.error = err.data || {};
            $scope.error.Messages = validationErrorsParser.parseError(err);
        });
    };

    $scope.passwordChangeShow = false;
}]).factory('userService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var fac = {};
    fac.getUserData = function () {
        return $http.get(serviceBase + 'Account/UserInfo');
    };

    fac.updatePassword = function (passwordModel) {
        return $http.post(serviceBase + 'Account/ChangePassword', passwordModel);
    };

    fac.updateUser = function (userModel) {
        return $http.post(serviceBase + 'Account/UpdateUser', userModel);
    };

    return fac;
}]);
'use strict';
cdkApp.controller('detailsController', ["$scope", 'detailsService', '$stateParams', "$state",
function ($scope, detailsService, $stateParams, $state) {
    
    $scope.images = [];
    $scope.numberLoaded = false;
    $scope.snipper = true;
    detailsService.getdata($stateParams.path).then(function (d) {
       if (d != null) {
            $scope.data = d;
           
            if (d.Type === "Unit") {
                $scope.images = d.Photo;
                $scope.kindview = false;
            } else if (d.Type == "Building") {
                $scope.images = d.Photo;
                $scope.kindview = true;
            }
        } else {

            $state.go("otherwise");
        }
        $scope.snipper = false;
        $scope.numberLoaded = true;
    });
}]);
'use strict';
cdkApp.controller('detailsPopupController', ["$scope", "$uibModalInstance",
function ($scope, $uibModalInstance) {
     $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
     };
    
  
  
}]);
'use strict';
cdkApp.controller('homeController',["$scope","$document","$state","Notification", function ($scope, $document, $state, Notification) {
    var controller = this;

    if ($state.params.status === "Success") {
        Notification.success("You confirmed email successfully. Now you can login.");
    }

    $scope.$parent.index.openSelectCityModal();
}]);
'use strict';
cdkApp.controller('indexController', ['$scope', '$location', 'authService', '$uibModal', '$document', 'ngAuthSettings', 'validationErrorsParser', "$aside",
function ($scope, $location, authService, $uibModal, $document, ngAuthSettings, validationErrorsParser, $aside) {
    var controller = this;

    controller.logOut = function () {
        authService.logOut();
        $location.path('/');
    }

    controller.authentication = authService.authentication;


    controller.openSelectCityModal = function () {
        var modalInstance = $uibModal.open({
            templateUrl: "/app/View/Partials/_selectCityDialog.html",
            controller:["$scope", "$uibModalInstance", "cdkDataService", "$state", function ($scope, $uibModalInstance, cdkDataService, $state) {
                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                    angular.element("a:last").focus();
                   
                };

                $scope.onSelectCallback = function () {
                    $scope.cancel();

                };

                $scope.selectArea = function ($item) {
                    $scope.cancel();
                    var url = $item.Value.split('/');
                    $state.transitionTo('map', {
                        state: url[0],
                        city: url[1],
                        type: window.mobilecheck() ? 'gallery' : 'map',
                        beds: null,
                        minPrice: 0,
                        maxPrice: "Max",
                        transaction: 0,
                        page: 1,
                        nNeighborhood: null,
                        mNeighborhood: null,
                        sNeighborhood: null
                    }, {
                        location: "replace",
                        inherit: true,
                        notify: true
                    });
                };

                $scope.popularAreas = [];

                cdkDataService.getPopularAreas().then(function (d) {
                    $scope.popularAreas = d.data;
                }, function () {
                    $scope.popularAreas = [];
                });

                $scope.isMobule = window.mobilecheck;
            }],
            resolve: {
                $location: $location,
                $uibModal: $uibModal,
                $document: $document
            },
            appendTo: $document.find('div#dialog-block').eq(0)
        });

        modalInstance.result.then(function () {
            // Redirect to the logged-in area of your site
        }, function () {
            // optional function. Do something if the user cancels.
        });
    };

    controller.openLoginModal = function () {
        var modalInstance = $uibModal.open({
            templateUrl: "/app/View/Partials/_loginDialog.html",
            controller: 'loginController',
            resolve: {
                $location: $location,
                authService: authService,
                ngAuthSettings: ngAuthSettings,
                $uibModal: $uibModal,
                $document: $document,
                validationErrorsParser: validationErrorsParser
            },
            appendTo: $document.find('div#dialog-block').eq(0)
        });

        modalInstance.result.then(function () {
            // Redirect to the logged-in area of your site
        }, function () {
            // optional function. Do something if the user cancels.
        });
    };

    $scope.menuClass = function (page) {
        var current = $location.path().substring(1);
        return page === current ? "active" : "";
    };

    $scope.openAside = function () {
        $aside.open({
            templateUrl: '/app/View/Partials/_mobileMenu.html',
            placement: 'right',
            size: 'lg',
            scope: $scope,
            controller: ["$uibModalInstance",function ($uibModalInstance) {
                $scope.openSelectCityModal = function () {
                    $uibModalInstance.dismiss('cancel');
                    controller.openSelectCityModal();
                };

                $scope.cancel = function (e) {

                    $uibModalInstance.dismiss();
                    e.stopPropagation();
                };

                $scope.openLoginModal = function () {
                    $uibModalInstance.dismiss('cancel');
                    controller.openLoginModal();
                };

                $scope.logOut = function () {
                    $uibModalInstance.dismiss('cancel');
                    controller.logOut();
                };
            }]
        });
    }
}]);
cdkApp.controller('loginController',['$scope', '$uibModalInstance','$location', 'authService', 'ngAuthSettings', '$uibModal', '$document', 'validationErrorsParser', 'Notification',
function ($scope, $uibModalInstance, $location, authService, ngAuthSettings, $uibModal, $document, validationErrorsParser, Notification) {
    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };
   
    $scope.registration = {
        userName: "",
        password: "",
        confirmPassword: "",
        IsAgree:"false",
        agree: false
    };

    $scope.PasswordForgot = {
        Email: ''
    };

    $scope.loginError = null;

    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {
            $location.path('/refresh');
        },
        function (err) {
            $scope.loginError = validationErrorsParser.parseError(err)
        });
    };

    $scope.forgot = function () {
        authService.forgot($scope.PasswordForgot).then(function (response) {
            Notification.success("Please check your email for reset link.");
            $scope.cancel();
        },
        function (err) {
            $scope.error = validationErrorsParser.parseError(err);
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.forgotPasswordModal = function () {
        $uibModalInstance.dismiss('cancel');

        var modalInstance = $uibModal.open({
            templateUrl: "/app/View/Partials/_forgotPasswordDialog.html",
            controller: 'loginController',
            resolve: {
                $location: $location,
                authService: authService,
                ngAuthSettings: ngAuthSettings,
                validationErrorsParser: validationErrorsParser
            },
            appendTo: $document.find('div#dialog-block').eq(0)
        });
    };


    $scope.signUp = function () {
      
        authService.saveRegistration($scope.registration).then(function (response) {
            $uibModalInstance.dismiss('cancel');
            Notification.success("User has been registered successfully. Please check your email for conformation.");
        },
        function (err) {
            $scope.error = validationErrorsParser.parseError(err);
        });
    };
    $scope.goLogin = function () {
        angular.element("li a[href='#login']").tab('show');
        return false; 
    }
}]);
'use strict';
cdkApp.controller('resetPasswordController',[ "$scope", "resetService", "$stateParams", "validationErrorsParser","Notification", "$location",
function ($scope, resetService, $stateParams, validationErrorsParser, Notification, $location) {
    $scope.resetModel = {
        code: $stateParams.code,
        email: "",
        rassword: "",
        confirmPassword: ""
    };

    $scope.error = null;

    $scope.resetPassword = function () {
        resetService.resetPassword($scope.resetModel).then(function (response) {
            $scope.error = null;
            Notification.success("Now You can Try Sign In with new password.");
            $location.search('');
            $location.path('/');
        },
        function (err) {
            $scope.error = err.data || {};
            $scope.error.Messages = validationErrorsParser.parseError(err);
        });
    };
}]).factory('resetService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var fac = {};

    fac.resetPassword = function (resetModel) {
        return $http.post(serviceBase + 'Account/ResetPassword', resetModel);
    };

    return fac;
}]);
'use strict';
cdkApp.factory('accountService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};
       
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            var authService = $injector.get('authService');
            var authData = localStorageService.get('authorizationData');

            if (authData) {
                if (authData.useRefreshTokens) {
                    $location.path('/refresh');
                    return $q.reject(rejection);
                }
            }
            authService.logOut();
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);
'use strict';
cdkApp.factory('authInterceptorService', ['$q', '$injector','$location', 'localStorageService', function ($q, $injector,$location, localStorageService) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {
        config.headers = config.headers || {};
       
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            var authService = $injector.get('authService');
            var authData = localStorageService.get('authorizationData');

            if (authData) {
                if (authData.useRefreshTokens) {
                    $location.path('/refresh');
                    return $q.reject(rejection);
                }
            }
            authService.logOut();
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);
'use strict';
cdkApp.factory('authService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        useRefreshTokens: false
    };

    var _externalAuthData = {
        provider: "",
        userName: "",
        externalAccessToken: ""
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'account/register', registration).then(function (response) {
            return response;
        });

    };

    var _loginData = {};

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        if (loginData.useRefreshTokens) {
            data = data + "&client_id=" + ngAuthSettings.clientId;
        }

        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            if (loginData.useRefreshTokens) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
            }
            else {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
            }
            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;
            _authentication.useRefreshTokens = loginData.useRefreshTokens;

            _loginData = loginData;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };


    var _forgot = function (data) {
        return $http.post(serviceBase + 'Account/ForgotPassword', data);
    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.useRefreshTokens = false;

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
            _authentication.useRefreshTokens = authData.useRefreshTokens;
        }

    };

    var _refreshToken = function () {
        var deferred = $q.defer();

        var authData = localStorageService.get('authorizationData');

        if (authData) {

            if (authData.useRefreshTokens) {

                var data = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + ngAuthSettings.clientId;

                localStorageService.remove('authorizationData');

                $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                    localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: response.refresh_token, useRefreshTokens: true });

                    deferred.resolve(response);

                }).error(function (err, status) {
                    _logOut();
                    deferred.reject(err);
                });
            }
        }

        return deferred.promise;
    };

    var _obtainAccessToken = function (externalData) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'api/account/ObtainLocalAccessToken', { params: { provider: externalData.provider, externalAccessToken: externalData.externalAccessToken } }).success(function (response) {

            localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: "", useRefreshTokens: false });

            _authentication.isAuth = true;
            _authentication.userName = response.userName;
            _authentication.useRefreshTokens = false;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _registerExternal = function (registerExternalData) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'api/account/registerexternal', registerExternalData).success(function (response) {

            localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: "", useRefreshTokens: false });

            _authentication.isAuth = true;
            _authentication.userName = response.userName;
            _authentication.useRefreshTokens = false;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.forgot = _forgot;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.refreshToken = _refreshToken;
    authServiceFactory.loginData = _loginData;

    authServiceFactory.obtainAccessToken = _obtainAccessToken;
    authServiceFactory.externalAuthData = _externalAuthData;
    authServiceFactory.registerExternal = _registerExternal;

    return authServiceFactory;
}]);
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
'use strict';
cdkApp.factory('tokensManagerService', ['$http','ngAuthSettings', function ($http,ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    
    var tokenManagerServiceFactory = {};

    var _getRefreshTokens = function () {

        return $http.get(serviceBase + 'api/refreshtokens').then(function (results) {
            return results;
        });
    };

    var _deleteRefreshTokens = function (tokenid) {

        return $http.delete(serviceBase + 'api/refreshtokens/?tokenid=' + tokenid).then(function (results) {
            return results;
        });
    };

    tokenManagerServiceFactory.deleteRefreshTokens = _deleteRefreshTokens;
    tokenManagerServiceFactory.getRefreshTokens = _getRefreshTokens;

    return tokenManagerServiceFactory;

}]);
cdkApp.directive('areaSelect', ['cdkDataService', function (cdkDataService) {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            sClass: '@sclass',
            callback: '&scallback'
        },
        templateUrl: '/app/Directive/Partials/_areaSelect.html',
        controller:['$scope', '$state', function ($scope, $state) {
            $scope.areas = [];
            $scope.selectedArea = null;


            var value = ($state.params.state || "").toLocaleLowerCase();
            value += "/" + ($state.params.city || "").toLocaleLowerCase();

            if (value === "/") {
                value = "";
            }

            cdkDataService.getAreaByValue(value).then(function (d) {
                $scope.selectedArea = d.data;
                $scope.areas = [$scope.selectedArea];

                cdkDataService.getAreas().then(function (d) {
                    $scope.areas = d.data;
                }, function () {
                    $scope.areas.length = 0;
                });

            }, function () {
                $scope.selectedArea = null;
            });

            $scope.onSelectCallback = function ($item) {
                if ($scope.callback) {
                    $scope.callback($item);
                }
                var url = $item.Value.split('/');
                $state.transitionTo('map', {
                    state: url[0],
                    city: url[1],
                    type: window.mobilecheck() ? 'gallery' : 'map',
                    beds: null,
                    minPrice: 0,
                    maxPrice: "Max",
                    transaction: 0,
                    page: 1,
                    nNeighborhood: null,
                    mNeighborhood: null,
                    sNeighborhood: null
                }, {
                    location: "replace",
                    inherit: true,
                    notify: true
                });
            }
        }]
    };
}]);
cdkApp.directive('buildingDetails', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_buildingDetails.html'
        
    }
});

cdkApp.directive('contactAgent', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_contactAgent.html'
    }
});
cdkApp.directive('dropDownForSortByUnit', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_dropDownForSortByUnit.html',
        controller:['$scope', '$state', function ($scope, $state) {
            $scope.selectedAction = "Sort by price";
            $scope.setAction = function (action) {
                $scope.selectedAction = action;
                if (action === "Sort by price") {
                  
                    $state.go($state.current, { sortBy: 0,page:1 });
                } else {
                    
                    $state.go($state.current, { sortBy: 1, page: 1 });
                }
            };
        }]

    }
});
cdkApp.directive('features', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_features.html'
    }
});
cdkApp.directive('footerWrapper', function (cdkDataService) {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_footerWrapper.html',
        controller:["$scope","$state", function ($scope, $state) {
            $scope.popularAreas = [];

            cdkDataService.getPopularAreas().then(function (d) {
                $scope.popularAreas = d.data;
            }, function () {
                $scope.popularAreas = [];
            });

            $scope.selectArea = function ($item) {
                var url = $item.Value.split('/');
                $state.transitionTo('map', {
                    state: url[0],
                    city: url[1],
                    type: window.mobilecheck() ? 'gallery' : 'map',
                    beds: null,
                    minPrice: 0,
                    maxPrice: "Max",
                    transaction: 0,
                    page: 1,
                    nNeighborhood: null,
                    mNeighborhood: null,
                    sNeighborhood: null
                }, {
                    location: "replace",
                    inherit: true,
                    notify: true
                });
            };
        }]
    };
});
cdkApp.directive('gallery', function () {
 
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_gallery.html',
        controller: function ($scope) {
           
        }
    }
});
cdkApp.directive('galleryElement', function () {
 
    return {
        scope: {
          data:"="  
        },
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_galleryElement.html',
        controller: function ($scope) {
       
        }
    }
});
cdkApp.directive('likr', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_like.html',
        controller:['$scope', function($scope) {
            $scope.data = {
                Src:"#"
        };
        }]
    }
});
cdkApp.directive('listingDetails', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_listingDetails.html'
    }
});
cdkApp.directive('mapFilter', ['cdkDataService', '$timeout', '$stateParams', function (cdkDataService, $timeout, $stateParams) {
    var beds = [];

    cdkDataService.getBedsFilter().then(function (d) {
        d.data.forEach(function (bed) {
            beds.push(bed);
        });
    }, function () {
        beds = [];
    });

    return {
        restrict: 'E',
        transclude: true,
        scope: {
            sClass: '@sclass',
            callback: '&scallback'
        },
        templateUrl: '/app/Directive/Partials/_mapFilter.html',
        controller:['$scope', '$state', '$stateParams', function ($scope, $state, $stateParams) {
            $scope.selectedBeds = [];
            $scope.state = $state;
            $scope.transactionType = $stateParams.transaction;


            $scope.transactionTypeChange = function (value) {
                $state.go($state.current, {
                    transaction: value,
                    page: 1
                });
            };

            if ($stateParams.beds) {
                for (var i = 0; i < $stateParams.beds.length; i++) {
                    $scope.selectedBeds.push({ Value: $stateParams.beds[i] });
                }
            }

            $scope.beds = beds;

            $timeout(function () {
                angular.element("#bedsLists input[type=checkbox]:checked").parent().each(function () {
                    angular.element(this).addClass("labelChecked");
                });
            });



            $scope.onItemSelect = function ($item) {
                $timeout(function () {
                    angular.element("#bedsLists input[type=checkbox]:checked").parent().each(function () {
                        angular.element(this).addClass("labelChecked");
                    });
                }, 100);

                $state.go($state.current, {
                    beds: $scope.selectedBeds.map(function (bed) {
                        return bed.Value;
                    }),
                    page:1
                });
            };

            $scope.onItemDeselect = function ($item) {
                $timeout(function () {
                    angular.element("#bedsLists input[type=checkbox]:not(:checked)").parent().each(function () {
                        angular.element(this).removeClass("labelChecked");
                    });
                }, 100);

                $state.go($state.current, {
                    beds: $scope.selectedBeds.map(function (bed) {
                        return bed.Value;
                    }),
                    page: 1
                });
            };

            $scope.isMobule = window.mobilecheck;
        }]
    };
}]);

cdkApp.directive('mapInfoWindow', ["cdkDataService", "$uibModal", function (cdkDataService, $uibModal) {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_mapInfoWindow.html',
        controller:["$scope", function ($scope) {
           
            $scope.detailsPopup = function (id, type) {
          
                $scope.images = [];
                $scope.numberLoaded = false;
                cdkDataService.getDetailsPopup(id, type).then(function (d) {
                    
                    if (d != null) {
                        $scope.data = d.data;
                        if (d.data.Type == "Unit") {

                            $scope.images = d.data.Photo;
                            $scope.kindview = "Unit";

                            $uibModal.open({
                                templateUrl: "/app/View/Partials/_detailsPopup.html",
                                controller: "detailsPopupController",
                                scope: $scope,
                                size: 'lg'
                            });


                        }
                        if (d.data.Type == "Building") {

                            $scope.data = d.data;
                            $scope.images = d.data.Photo;

                            $scope.kindview = "Building";
                            $scope.numberLoaded = true;
                            var modalInstance = $uibModal.open({
                                templateUrl: "/app/View/Partials/_detailsPopup.html",
                                controller: "detailsPopupController",

                                scope: $scope

                            });
                            modalInstance.rendered.then(
                            function () {
                                angular.element(".modal-dialog").attr("style", "width: 975px");

                            }, function () {

                            });
                        }

                        $scope.numberLoaded = true;
                    }
                });
            };
        }]
    }
}]);
cdkApp.directive('mapResult', [
'cdkDataService',
'$state',
'$timeout',
'mapService',
'mapResultService',
'$rootScope',
function (cdkDataService, $state, $timeout, mapService, mapResultService, $rootScope) {
    var stateChangeSuccess = null;

    var addMapStateEvents = function () {
        stateChangeSuccess = $rootScope.$on("$stateChangeSuccess", function (event, toState, toParams, fromState, fromParams) {
            if (fromState.name !== toState.name && toState.name === "map") {
                return;
            }

            mapResultService.setBodyClass();
            if (toParams.type !== fromParams.type) {
                $timeout(function () {
                    mapResultService.destroy();
                    mapResultService.init().then(function () { });
                }, 100);

                return;
            }

            if ((toParams.nNeighborhood !== fromParams.nNeighborhood)
            || (toParams.mNeighborhood !== fromParams.mNeighborhood)
            || (toParams.sNeighborhood !== fromParams.sNeighborhood)) {
                mapResultService.destroy();
                mapResultService.init().then(function () { });
                return;
            }

            if ((toParams.minPrice !== fromParams.minPrice)
            || (toParams.maxPrice !== fromParams.maxPrice)
            || ((toParams.beds || []).length !== (fromParams.beds || []).length)
            || (toParams.page !== fromParams.page)
            || (toParams.sortBy !== fromParams.sortBy)
            || (toParams.transaction !== fromParams.transaction)) {
                mapResultService.sync().then(function () { });
                return;
            }
        });
    };

    return {
        restrict: 'E',
        transclude: true,
        scope: {
            sClass: '@sclass'
        },
        templateUrl: '/app/Directive/Partials/_map.html',
        controller:['$scope', '$rootScope', function ($scope, $rootScope) {
            $scope.isLoading = false;

            mapResultService.init($scope).then(function () {
                $scope.dataService = mapResultService;
                addMapStateEvents();
                $scope.data = mapResultService.scope.items.list;
                $scope.items = mapResultService.scope.items;
            });

            $rootScope.$on('cfpLoadingBar:loading', function (event, url) {

                if (url.url.indexOf("Map/ListView") > -1 || url.url.indexOf("Map/GalleryView") > -1) {
                    $scope.isLoading = false;
                }

            });

            $rootScope.$on('cfpLoadingBar:loaded', function (event, url) {
                if (url.url.indexOf("Map/ListView") > -1 || url.url.indexOf("Map/GalleryView") > -1) {
                    $scope.isLoading = true;

                }
            });
        }],
        link: function ($scope, element, attrs) {
            element.on('$destroy', function () {
                mapResultService.destroy();

                if (stateChangeSuccess) {
                    stateChangeSuccess();
                }
            });
        }
    };
}]);
cdkApp.directive('neighborhoodSelect', ['cdkDataService', function (cdkDataService) {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            sClass: '@sclass',
            callback: '&scallback'
        },
        templateUrl: '/app/Directive/Partials/_neighborhoodSelect.html',
        controller:['$scope', '$state', '$stateParams', function ($scope, $state, $stateParams) {
            $scope.selectedNeighborhood = null;
            $scope.neighborhoods = [];


            var value = ($state.params.state || "").toLocaleLowerCase();
            value += "/" + ($state.params.city || "").toLocaleLowerCase();

            var nNeighborhood = ($state.params.nNeighborhood || "").toLocaleLowerCase();

            if (nNeighborhood.length) {
                value += "/" + nNeighborhood;
            }

            var mNeighborhood = ($state.params.mNeighborhood || "").toLocaleLowerCase();

            if (mNeighborhood.length) {
                value += "/" + mNeighborhood;
            }

            var sNeighborhood = ($state.params.sNeighborhood || "").toLocaleLowerCase();

            if (sNeighborhood.length) {
                value += "/" + sNeighborhood;
            }

            cdkDataService.getNeighborhoodByValue(value).then(function (d) {
                $scope.selectedNeighborhood = d.data;
                $scope.neighborhoods = [$scope.selectedNeighborhood];

                cdkDataService.getNeighborhoods($state.params.state, $state.params.city).then(function (d) {
                    $scope.neighborhoods = d.data;
                }, function () {
                    $scope.neighborhoods = [$scope.selectedNeighborhood];
                });

            }, function () {
                $scope.neighborhoods = null;
            });

            cdkDataService.getNeighborhoods($state.params.state, $state.params.city).then(function(d) {
                $scope.neighborhoods = d.data;
                $scope.neighborhoods.push($scope.selectedNeighborhood);
            }, function() {
                $scope.neighborhoods = [];
            });

            $scope.search = function ($search) {
                if ($search !== "") {
                    cdkDataService.getNeighborhoods($state.params.state, $state.params.city, $search).then(function (d) {
                        $scope.neighborhoods = d.data;
                    }, function () {
                        $scope.selectedNeighborhood = [];
                    });
                }
            };

            $scope.onSelectCallback = function ($item) {
                if ($scope.callback) {
                    $scope.callback($item);
                }

                var url = $item.Value.split('/');


                var params = {
                    state: $state.params.state,
                    city: $state.params.city,
                    type: $state.params.type,
                    beds: $stateParams.beds,
                    minPrice: $stateParams.minPrice,
                    maxPrice: $stateParams.maxPrice,
                    page:1
                };

                if (url.length > 2) {
                    params.nNeighborhood = url[2];
                }

                if (url.length > 3) {
                    params.mNeighborhood = url[3];
                }

                if (url.length > 4) {
                    params.sNeighborhood = url[4];
                }

                $state.transitionTo("map", params, {
                    location: "replace",
                    inherit: true,
                    notify: true,
                    reload: false,
                });
            }
        }]
    };
}]);
cdkApp.directive('paginationDownForUnit', ["$timeout", "$state", function ($timeout, $state) {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_paginationDownForUnit.html',
        controller: ['$scope', '$state', '$stateParams' ,function ($scope, $state, $stateParams) {
             $scope.currentPage = $stateParams.page;
            $scope.pageChanged = function () {
                $timeout(function () {
                    $state.go($state.current, { page: $scope.currentPage });
                });
                return;
            }
        }],
        link: function (scope, element) {

            $timeout(function () {
                var prev = element.find('a')[0];
                var next = element.find('a:last');

                $(prev).html('');
                $(next).html('');
            });
        }
    }
}]);
cdkApp.directive('paginationUpForUnit', [
     function() {
        return {
            restrict: 'E',
            templateUrl: '/app/Directive/Partials/_paginationUpForUnit.html',
            controller:['$scope', '$stateParams', '$state','$rootScope', function ($scope, $stateParams, $state,$rootScope) {
            
                $scope.page = $state.params.page;

                $rootScope.$on("$stateChangeSuccess", function (event, toState, toParams, fromState, fromParams) {
                    if (toParams.page !== fromParams.page) {
                        $scope.page = toParams.page;
                    }
                });

                
                $scope.firstPage = function () {
                                       $state.go($state.current, { page: --$stateParams.page });

                }
                $scope.lastPage = function () {
                   $state.go($state.current, { page: ++$stateParams.page });
                 
                }
            }]
        }
    }
]);

cdkApp.directive('priceFilterMenu', ["cdkDataService",
function (cdkDataService) {
    var arrayPrice = [];
    var setMaxData;
    var dataPrice = [];

    function Calculation(datastr, dataPrice) {
        var str = parseInt(datastr);
        arrayPrice.length = 0;
        if (str == 0) {
            for (var i = 0; i < 7; i++) {

                arrayPrice.push(dataPrice[i]);
            }
        } else if (str < 600000) {
            for (var i = 0; i < 7; i++) {
                str = str + 50000;
                setMaxData = new Object();
                setMaxData.Price = str;

                arrayPrice.push(setMaxData);
            }

        } else {
            if (str < 1500000) {
                for (var i = 0; i < 7; i++) {
                    str = str + 100000;
                    setMaxData = new Object();
                    setMaxData.Price = str;

                    arrayPrice.push(setMaxData);
                }
            } else {
                if (str < 1500000) {
                    for (var i = 0; i < 6; i++) {
                        str = str + 100000;
                        setMaxData = new Object();
                        setMaxData.Price = str;

                        arrayPrice.push(setMaxData);
                    }
                } else {

                    for (var i = 0; i < 6; i++) {
                        str = str + 250000;
                        setMaxData = new Object();
                        setMaxData.Price = str;

                        arrayPrice.push(setMaxData);
                    }

                }

            }
        }

    }
    return {

        templateUrl: '/app/Directive/Partials/_priceFilterMenu.html',
        controller:['$scope', '$state', '$stateParams', function ($scope, $state, $stateParams) {
            $scope.pricesDataMin = [];
            $scope.pricesDataMax = [];
            $scope.pricesDataMax = arrayPrice;
            cdkDataService.getGetPrice().then(function (d) {
                $scope.pricesDataMin = d.data;

                dataPrice = d.data;
                var str = parseInt($stateParams.minPrice);
                Calculation(str, dataPrice);


            });

            $scope.PriceMin = $stateParams.minPrice;
            $scope.PriceMax = $stateParams.maxPrice;

            $scope.SetPriceMax = function (str) {
                $scope.PriceMax = str;

            }
            $scope.SetPriceMin = function (str) {
                $scope.PriceMin = str;
                Calculation(str, dataPrice);
                $scope.PriceMax = "Max";
                $state.go($state.current, { maxPrice: "Max", page: 1 });

            }

            $scope.showMinList = true;
            var toggleList = function (showMin, showMax) {
                $scope.showMinList = showMin;
                $scope.showMaxList = showMax;
            }
            $scope.minValFocus = function (event) {
                toggleList(true, false);
            };

            $scope.maxValFocus = function (event) {
                toggleList(false, true);
            };
            $scope.keyPressPriceMin = function (e) {
                if (e.keyCode == 13) {
                    if (isNaN($scope.PriceMin)) {
                        $scope.PriceMin = 0;
                        Calculation($scope.PriceMin, dataPrice);
                        $scope.PriceMax = "Max";
                    } else {
                        Calculation($scope.PriceMin, dataPrice);
                        $state.go($state.current, { minPrice: $scope.PriceMin, page: 1 });
                        $scope.PriceMax = "Max";
                    };

                };
            }
            $scope.keyPressPriceMax = function (e) {

                if (e.keyCode == 13) {

                    if (isNaN($scope.PriceMax)) {
                        $scope.PriceMax = "Max";
                        $state.go($state.current, { maxPrice: "Max", page: 1 });

                    } else {

                        $state.go($state.current, { maxPrice: $scope.PriceMax, page: 1 });
                    };
                }


            }

        }]
    }

}]);

cdkApp.directive('showtab', function () {
    return {
        link: function (scope, element, attrs) {
            element.click(function (e) {
                e.preventDefault();
                $(element).tab('show');
            });
        }
    };
})
cdkApp.directive('slickSlider', function () {
    return {
        restrict: 'E',
        scope: {
            images: '=',
            numberLoaded: '='
        },
        templateUrl: '/app/Directive/Partials/_slickSlider.html',
        controller:['$scope', function ($scope) {
          
            $scope.slickConfig = {
                enabled: true,
                autoplay: true,
                draggable: false,
                autoplaySpeed: 2000,
                asNavFor: '.slider-nav',
                method: {},
                event: {
                    beforeChange: function (event, slick, currentSlide, nextSlide) {
                    },
                    afterChange: function (event, slick, currentSlide, nextSlide) {
                    }
                }
            };
          
            $scope.slick2Config = {
                asNavFor: '.slider-for',
                arrows: false,
                slidesToShow: $scope.images.length,
                centerMode: true,
                focusOnSelect: true
            };

            $scope.$watch('images', function (newVal, oldVal) {
                $scope.slick2Config.slidesToShow = newVal.length;
             }, true);
        }]

    }
});
cdkApp.directive("spinner", function () {
    return {
       
        restrict: 'E',
        scope: {},
        template: ' <div style="text-align: center;margin-top: 250px"><img src="/Content/images/spinner.gif"></div>'
        
    }
});
cdkApp.directive('stringForGallery', ['cdkDataService', function (cdkDataService) {

    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_stringForGallery.html',
        controller:['$scope', '$rootScope', 'cdkDataService', '$stateParams',function ($scope, $rootScope, cdkDataService, $stateParams) {
            cdkDataService.getStringForGallery($stateParams.transaction, $stateParams.state, $stateParams.city).then(
                        function (d) {
                            $scope.datast = d.data;
                        }
                        );
            $rootScope.$on("$stateChangeSuccess", function (event, toState, toParams, fromState, fromParams) {
                if ((toParams.transaction !== fromParams.transaction
                || (toParams.state !== fromParams.state)
                || (toParams.city !== fromParams.city)
                 )) {
                    cdkDataService.getStringForGallery(toParams.transaction, toParams.state, toParams.city).then(
                        function (d) {
                            $scope.datast = d.data;
                        }
                        );
                }
            });
        }]
    }
}]);
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
cdkApp.directive('tabUnitFor', function () {
    return {
        restrict: 'E',
        scope: {
            data: "=data",
            type: "@"
        },
        templateUrl: '/app/Directive/Partials/_tabUnitFor.html',
        controller:['$scope',function ($scope) {
           
            $scope.createria = {};
            if ($scope.type == "ForRent")
                $scope.createria.TransactionType = "For rent";
            if ($scope.type == "ForSale")
                $scope.createria.TransactionType = "For sale";
        }]
       
    }
});

'use strict';

cdkApp.factory('validationErrorsParser', function () {
    var fac = {};

    fac.parseError = function (err) {
        if (err.data) {
            if (err.data.ModelState) {
                var errorMessages = [];
                for (var key in err.data.ModelState) {
                    var value = err.data.ModelState[key];

                    if (value && value.length) {
                        for (var i = 0; i < value.length; i++) {
                            errorMessages.push(value[i]);
                        }
                    }
                }

                return errorMessages;
            }
        }

        if (err.error_description) {
            return [err.error_description];
        }



        return [];
    };

    return fac;
});
cdkApp.filter('propsFilter', function () {
    return function (items, props) {
        var out = [];

        if (angular.isArray(items)) {
            var keys = Object.keys(props);

            items.forEach(function (item) {
                var itemMatches = false;

                for (var i = 0; i < keys.length; i++) {
                    var prop = keys[i];
                    var text = props[prop].toLowerCase();

                    if (!item) {
                        continue
                    }

                    if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
                        itemMatches = true;
                        break;
                    }
                }

                if (itemMatches) {
                    out.push(item);
                }
            });
        } else {
            // Let the output be the input untouched
            out = items;
        }

        return out;
    };
});
'use strict';
cdkApp.service('detailsService', ['cdkDataService',"$q", function (cdkDataService,$q) {

  
        var self = this;
 
        self.dataRequest = "";
 
        self.data = null;
    
        self.getdata = function (requestValue) {
            
            if (requestValue === self.dataRequest && self.data) {
                
                var deferred = $q.defer();

                deferred.resolve(self.data);

                return deferred.promise;
            }
            
            return cdkDataService.getDetails(requestValue).then(function (g) {
                    if (g.data) {
                        self.data = g.data;
                        self.dataRequest = requestValue;
                        

                    } else {
                        self.data = null;
                        self.dataRequest = "";
                     
                    }
                
                    return $q.resolve(self.data);
                }, function(error) {
                    return $q.reject(error);
                });
            }
    
        


    return self;


}]);
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