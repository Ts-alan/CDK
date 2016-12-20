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
