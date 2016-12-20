'use strict';
cdkApp.controller('detailsPopupController', ["$scope", "$uibModalInstance",
function ($scope, $uibModalInstance) {
     $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
     };
    
  
  
}]);