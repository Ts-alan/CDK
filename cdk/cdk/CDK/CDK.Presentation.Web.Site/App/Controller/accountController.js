'use strict';
cdkApp.controller('accountController', ['$scope', '$location', '$document', 'ngAuthSettings', '$state', 'userService', 'validationErrorsParser',
function ($scope, $location, $document, ngAuthSettings, $state, userService, validationErrorsParser) {
    var controller = this;

    $scope.user = {};

    $scope.userMessage = '';
    $scope.passwordMessage = '';

    userService.getUserData().then(function (d) {
        $scope.user = d.data;

    }, function () {
        //$location.path('/');
    });

    $scope.passwordModel = {
        oldPassword: "",
        newPassword: "",
        confirmPassword: ""
    };

    $scope.updateUser = function () {
        userService.updateUser($scope.user).then(function (response) {
            $state.go($state.current, {}, { reload: true });
        },
        function (err) {
            $scope.userError = err.data;
            $scope.userError.Messages = validationErrorsParser.parseError(err);
        });
    };

    $scope.updatePassword = function () {
        userService.updatePassword($scope.passwordModel).then(function (response) {
            $state.go($state.current, {}, { reload: true });
        },
        function (err) {
            $scope.error = err.data || {};
            $scope.error.Messages = validationErrorsParser.parseError(err);
        });
    };

    $scope.passwordChangeShow = false;
}]).factory('userService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var fac = {};
    fac.getUserData = function () {
        return $http.get(serviceBase + 'Account/UserInfo');
    };

    fac.updatePassword = function (passwordModel) {
        return $http.post(serviceBase + 'Account/ChangePassword', passwordModel);
    };

    fac.updateUser = function (userModel) {
        return $http.post(serviceBase + 'Account/UpdateUser', userModel);
    };

    return fac;
}]);