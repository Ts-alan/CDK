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