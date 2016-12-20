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