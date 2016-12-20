var cdkApp = angular.module('cdkApp', [
'ngRoute',
'ngResource',
'ui.bootstrap',
'LocalStorageModule',
'ui.router',
'angular-loading-bar',
'ui-notification',
'ngSanitize',
'ngAnimate',
'ui.select',
'angularjs-dropdown-multiselect',
'ngAside',
'slickCarousel',
'updateMeta',
'hm.readmore'
]);

var serviceBase = '/API/';
cdkApp.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'self'
});

cdkApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

cdkApp.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = false;
}]);

cdkApp.config(function (uiSelectConfig) {
    uiSelectConfig.theme = 'select2';
});

cdkApp.config(function (NotificationProvider) {
    NotificationProvider.setOptions({
        delay: 10000,
        startTop: 20,
        startRight: 10,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'center',
        positionY: 'top'
    });
});


cdkApp.run(['$rootScope', '$uibModalStack', 'authService', 'cdkDataService',
    function ($rootScope, $uibModalStack, authService, cdkDataService) {
        $rootScope.$on('$locationChangeStart', function ($event) {
            var openedModal = $uibModalStack.getTop();
            if (openedModal) {
                if (!!$event.preventDefault) {
                    $event.preventDefault();
                }
                if (!!$event.stopPropagation) {
                    $event.stopPropagation();
                }
                $uibModalStack.dismiss(openedModal.key);
            }
        });

        authService.fillAuthData();
    }]);


