'use strict';
cdkApp.controller('detailsController', ["$scope", 'detailsService', '$stateParams', "$state",
function ($scope, detailsService, $stateParams, $state) {
    
    $scope.images = [];
    $scope.numberLoaded = false;
    $scope.snipper = true;
    detailsService.getdata($stateParams.path).then(function (d) {
       if (d != null) {
            $scope.data = d;
           
            if (d.Type === "Unit") {
                $scope.images = d.Photo;
                $scope.kindview = false;
            } else if (d.Type == "Building") {
                $scope.images = d.Photo;
                $scope.kindview = true;
            }
        } else {

            $state.go("otherwise");
        }
        $scope.snipper = false;
        $scope.numberLoaded = true;
    });
}]);