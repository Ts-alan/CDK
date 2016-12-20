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