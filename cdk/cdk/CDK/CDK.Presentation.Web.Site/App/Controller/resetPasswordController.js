'use strict';
cdkApp.controller('resetPasswordController',[ "$scope", "resetService", "$stateParams", "validationErrorsParser","Notification", "$location",
function ($scope, resetService, $stateParams, validationErrorsParser, Notification, $location) {
    $scope.resetModel = {
        code: $stateParams.code,
        email: "",
        rassword: "",
        confirmPassword: ""
    };

    $scope.error = null;

    $scope.resetPassword = function () {
        resetService.resetPassword($scope.resetModel).then(function (response) {
            $scope.error = null;
            Notification.success("Now You can Try Sign In with new password.");
            $location.search('');
            $location.path('/');
        },
        function (err) {
            $scope.error = err.data || {};
            $scope.error.Messages = validationErrorsParser.parseError(err);
        });
    };
}]).factory('resetService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var fac = {};

    fac.resetPassword = function (resetModel) {
        return $http.post(serviceBase + 'Account/ResetPassword', resetModel);
    };

    return fac;
}]);