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