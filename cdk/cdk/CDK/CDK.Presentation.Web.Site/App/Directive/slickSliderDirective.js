cdkApp.directive('slickSlider', function () {
    return {
        restrict: 'E',
        scope: {
            images: '=',
            numberLoaded: '='
        },
        templateUrl: '/app/Directive/Partials/_slickSlider.html',
        controller:['$scope', function ($scope) {
          
            $scope.slickConfig = {
                enabled: true,
                autoplay: true,
                draggable: false,
                autoplaySpeed: 2000,
                asNavFor: '.slider-nav',
                method: {},
                event: {
                    beforeChange: function (event, slick, currentSlide, nextSlide) {
                    },
                    afterChange: function (event, slick, currentSlide, nextSlide) {
                    }
                }
            };
          
            $scope.slick2Config = {
                asNavFor: '.slider-for',
                arrows: false,
                slidesToShow: $scope.images.length,
                centerMode: true,
                focusOnSelect: true
            };

            $scope.$watch('images', function (newVal, oldVal) {
                $scope.slick2Config.slidesToShow = newVal.length;
             }, true);
        }]

    }
});