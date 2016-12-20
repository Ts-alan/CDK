cdkApp.directive('galleryElement', function () {
 
    return {
        scope: {
          data:"="  
        },
        restrict: 'E',
        templateUrl: '/app/Directive/Partials/_galleryElement.html',
        controller: function ($scope) {
       
        }
    }
});