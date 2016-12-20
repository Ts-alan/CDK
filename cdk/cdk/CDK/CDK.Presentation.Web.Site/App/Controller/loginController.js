cdkApp.controller('loginController',['$scope', '$uibModalInstance','$location', 'authService', 'ngAuthSettings', '$uibModal', '$document', 'validationErrorsParser', 'Notification',
function ($scope, $uibModalInstance, $location, authService, ngAuthSettings, $uibModal, $document, validationErrorsParser, Notification) {
    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };
   
    $scope.registration = {
        userName: "",
        password: "",
        confirmPassword: "",
        IsAgree:"false",
        agree: false
    };

    $scope.PasswordForgot = {
        Email: ''
    };

    $scope.loginError = null;

    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {
            $location.path('/refresh');
        },
        function (err) {
            $scope.loginError = validationErrorsParser.parseError(err)
        });
    };

    $scope.forgot = function () {
        authService.forgot($scope.PasswordForgot).then(function (response) {
            Notification.success("Please check your email for reset link.");
            $scope.cancel();
        },
        function (err) {
            $scope.error = validationErrorsParser.parseError(err);
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.forgotPasswordModal = function () {
        $uibModalInstance.dismiss('cancel');

        var modalInstance = $uibModal.open({
            templateUrl: "/app/View/Partials/_forgotPasswordDialog.html",
            controller: 'loginController',
            resolve: {
                $location: $location,
                authService: authService,
                ngAuthSettings: ngAuthSettings,
                validationErrorsParser: validationErrorsParser
            },
            appendTo: $document.find('div#dialog-block').eq(0)
        });
    };


    $scope.signUp = function () {
      
        authService.saveRegistration($scope.registration).then(function (response) {
            $uibModalInstance.dismiss('cancel');
            Notification.success("User has been registered successfully. Please check your email for conformation.");
        },
        function (err) {
            $scope.error = validationErrorsParser.parseError(err);
        });
    };
    $scope.goLogin = function () {
        angular.element("li a[href='#login']").tab('show');
        return false; 
    }
}]);