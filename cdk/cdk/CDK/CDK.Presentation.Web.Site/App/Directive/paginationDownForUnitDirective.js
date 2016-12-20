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