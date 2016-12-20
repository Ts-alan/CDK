'use strict';
cdkApp.controller('indexController', ['$scope', '$location', 'authService', '$uibModal', '$document', 'ngAuthSettings', 'validationErrorsParser', "$aside",
function ($scope, $location, authService, $uibModal, $document, ngAuthSettings, validationErrorsParser, $aside) {
    var controller = this;

    controller.logOut = function () {
        authService.logOut();
        $location.path('/');
    }

    controller.authentication = authService.authentication;


    controller.openSelectCityModal = function () {
        var modalInstance = $uibModal.open({
            templateUrl: "/app/View/Partials/_selectCityDialog.html",
            controller:["$scope", "$uibModalInstance", "cdkDataService", "$state", function ($scope, $uibModalInstance, cdkDataService, $state) {
                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                    angular.element("a:last").focus();
                   
                };

                $scope.onSelectCallback = function () {
                    $scope.cancel();

                };

                $scope.selectArea = function ($item) {
                    $scope.cancel();
                    var url = $item.Value.split('/');
                    $state.transitionTo('map', {
                        state: url[0],
                        city: url[1],
                        type: window.mobilecheck() ? 'gallery' : 'map',
                        beds: null,
                        minPrice: 0,
                        maxPrice: "Max",
                        transaction: 0,
                        page: 1,
                        nNeighborhood: null,
                        mNeighborhood: null,
                        sNeighborhood: null
                    }, {
                        location: "replace",
                        inherit: true,
                        notify: true
                    });
                };

                $scope.popularAreas = [];

                cdkDataService.getPopularAreas().then(function (d) {
                    $scope.popularAreas = d.data;
                }, function () {
                    $scope.popularAreas = [];
                });

                $scope.isMobule = window.mobilecheck;
            }],
            resolve: {
                $location: $location,
                $uibModal: $uibModal,
                $document: $document
            },
            appendTo: $document.find('div#dialog-block').eq(0)
        });

        modalInstance.result.then(function () {
            // Redirect to the logged-in area of your site
        }, function () {
            // optional function. Do something if the user cancels.
        });
    };

    controller.openLoginModal = function () {
        var modalInstance = $uibModal.open({
            templateUrl: "/app/View/Partials/_loginDialog.html",
            controller: 'loginController',
            resolve: {
                $location: $location,
                authService: authService,
                ngAuthSettings: ngAuthSettings,
                $uibModal: $uibModal,
                $document: $document,
                validationErrorsParser: validationErrorsParser
            },
            appendTo: $document.find('div#dialog-block').eq(0)
        });

        modalInstance.result.then(function () {
            // Redirect to the logged-in area of your site
        }, function () {
            // optional function. Do something if the user cancels.
        });
    };

    $scope.menuClass = function (page) {
        var current = $location.path().substring(1);
        return page === current ? "active" : "";
    };

    $scope.openAside = function () {
        $aside.open({
            templateUrl: '/app/View/Partials/_mobileMenu.html',
            placement: 'right',
            size: 'lg',
            scope: $scope,
            controller: ["$uibModalInstance",function ($uibModalInstance) {
                $scope.openSelectCityModal = function () {
                    $uibModalInstance.dismiss('cancel');
                    controller.openSelectCityModal();
                };

                $scope.cancel = function (e) {

                    $uibModalInstance.dismiss();
                    e.stopPropagation();
                };

                $scope.openLoginModal = function () {
                    $uibModalInstance.dismiss('cancel');
                    controller.openLoginModal();
                };

                $scope.logOut = function () {
                    $uibModalInstance.dismiss('cancel');
                    controller.logOut();
                };
            }]
        });
    }
}]);