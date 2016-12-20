
cdkApp.directive('priceFilterMenu', ["cdkDataService",
function (cdkDataService) {
    var arrayPrice = [];
    var setMaxData;
    var dataPrice = [];

    function Calculation(datastr, dataPrice) {
        var str = parseInt(datastr);
        arrayPrice.length = 0;
        if (str == 0) {
            for (var i = 0; i < 7; i++) {

                arrayPrice.push(dataPrice[i]);
            }
        } else if (str < 600000) {
            for (var i = 0; i < 7; i++) {
                str = str + 50000;
                setMaxData = new Object();
                setMaxData.Price = str;

                arrayPrice.push(setMaxData);
            }

        } else {
            if (str < 1500000) {
                for (var i = 0; i < 7; i++) {
                    str = str + 100000;
                    setMaxData = new Object();
                    setMaxData.Price = str;

                    arrayPrice.push(setMaxData);
                }
            } else {
                if (str < 1500000) {
                    for (var i = 0; i < 6; i++) {
                        str = str + 100000;
                        setMaxData = new Object();
                        setMaxData.Price = str;

                        arrayPrice.push(setMaxData);
                    }
                } else {

                    for (var i = 0; i < 6; i++) {
                        str = str + 250000;
                        setMaxData = new Object();
                        setMaxData.Price = str;

                        arrayPrice.push(setMaxData);
                    }

                }

            }
        }

    }
    return {

        templateUrl: '/app/Directive/Partials/_priceFilterMenu.html',
        controller:['$scope', '$state', '$stateParams', function ($scope, $state, $stateParams) {
            $scope.pricesDataMin = [];
            $scope.pricesDataMax = [];
            $scope.pricesDataMax = arrayPrice;
            cdkDataService.getGetPrice().then(function (d) {
                $scope.pricesDataMin = d.data;

                dataPrice = d.data;
                var str = parseInt($stateParams.minPrice);
                Calculation(str, dataPrice);


            });

            $scope.PriceMin = $stateParams.minPrice;
            $scope.PriceMax = $stateParams.maxPrice;

            $scope.SetPriceMax = function (str) {
                $scope.PriceMax = str;

            }
            $scope.SetPriceMin = function (str) {
                $scope.PriceMin = str;
                Calculation(str, dataPrice);
                $scope.PriceMax = "Max";
                $state.go($state.current, { maxPrice: "Max", page: 1 });

            }

            $scope.showMinList = true;
            var toggleList = function (showMin, showMax) {
                $scope.showMinList = showMin;
                $scope.showMaxList = showMax;
            }
            $scope.minValFocus = function (event) {
                toggleList(true, false);
            };

            $scope.maxValFocus = function (event) {
                toggleList(false, true);
            };
            $scope.keyPressPriceMin = function (e) {
                if (e.keyCode == 13) {
                    if (isNaN($scope.PriceMin)) {
                        $scope.PriceMin = 0;
                        Calculation($scope.PriceMin, dataPrice);
                        $scope.PriceMax = "Max";
                    } else {
                        Calculation($scope.PriceMin, dataPrice);
                        $state.go($state.current, { minPrice: $scope.PriceMin, page: 1 });
                        $scope.PriceMax = "Max";
                    };

                };
            }
            $scope.keyPressPriceMax = function (e) {

                if (e.keyCode == 13) {

                    if (isNaN($scope.PriceMax)) {
                        $scope.PriceMax = "Max";
                        $state.go($state.current, { maxPrice: "Max", page: 1 });

                    } else {

                        $state.go($state.current, { maxPrice: $scope.PriceMax, page: 1 });
                    };
                }


            }

        }]
    }

}]);
