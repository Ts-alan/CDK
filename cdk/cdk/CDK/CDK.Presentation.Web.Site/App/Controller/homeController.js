'use strict';
cdkApp.controller('homeController',["$scope","$document","$state","Notification", function ($scope, $document, $state, Notification) {
    var controller = this;

    if ($state.params.status === "Success") {
        Notification.success("You confirmed email successfully. Now you can login.");
    }

    $scope.$parent.index.openSelectCityModal();
}]);