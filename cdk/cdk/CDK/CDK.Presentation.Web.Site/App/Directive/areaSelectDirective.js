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