cdkApp.directive('stringForGallery', ['cdkDataService', function (cdkDataService) {

    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_stringForGallery.html',
        controller:['$scope', '$rootScope', 'cdkDataService', '$stateParams',function ($scope, $rootScope, cdkDataService, $stateParams) {
            cdkDataService.getStringForGallery($stateParams.transaction, $stateParams.state, $stateParams.city).then(
                        function (d) {
                            $scope.datast = d.data;
                        }
                        );
            $rootScope.$on("$stateChangeSuccess", function (event, toState, toParams, fromState, fromParams) {
                if ((toParams.transaction !== fromParams.transaction
                || (toParams.state !== fromParams.state)
                || (toParams.city !== fromParams.city)
                 )) {
                    cdkDataService.getStringForGallery(toParams.transaction, toParams.state, toParams.city).then(
                        function (d) {
                            $scope.datast = d.data;
                        }
                        );
                }
            });
        }]
    }
}]);