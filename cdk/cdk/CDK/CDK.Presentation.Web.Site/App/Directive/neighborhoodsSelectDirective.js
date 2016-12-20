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