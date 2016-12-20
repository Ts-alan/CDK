cdkApp.directive('mapInfoWindow', ["cdkDataService", "$uibModal", function (cdkDataService, $uibModal) {
    return {
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_mapInfoWindow.html',
        controller:["$scope", function ($scope) {
           
            $scope.detailsPopup = function (id, type) {
          
                $scope.images = [];
                $scope.numberLoaded = false;
                cdkDataService.getDetailsPopup(id, type).then(function (d) {
                    
                    if (d != null) {
                        $scope.data = d.data;
                        if (d.data.Type == "Unit") {

                            $scope.images = d.data.Photo;
                            $scope.kindview = "Unit";

                            $uibModal.open({
                                templateUrl: "/app/View/Partials/_detailsPopup.html",
                                controller: "detailsPopupController",
                                scope: $scope,
                                size: 'lg'
                            });


                        }
                        if (d.data.Type == "Building") {

                            $scope.data = d.data;
                            $scope.images = d.data.Photo;

                            $scope.kindview = "Building";
                            $scope.numberLoaded = true;
                            var modalInstance = $uibModal.open({
                                templateUrl: "/app/View/Partials/_detailsPopup.html",
                                controller: "detailsPopupController",

                                scope: $scope

                            });
                            modalInstance.rendered.then(
                            function () {
                                angular.element(".modal-dialog").attr("style", "width: 975px");

                            }, function () {

                            });
                        }

                        $scope.numberLoaded = true;
                    }
                });
            };
        }]
    }
}]);