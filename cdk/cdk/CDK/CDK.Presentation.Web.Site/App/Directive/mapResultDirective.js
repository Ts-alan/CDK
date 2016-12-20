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