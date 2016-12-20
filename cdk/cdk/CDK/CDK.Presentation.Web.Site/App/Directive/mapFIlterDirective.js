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
