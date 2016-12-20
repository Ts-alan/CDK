cdkApp.config(['$routeProvider', '$locationProvider', '$stateProvider', function ($routeProvider, $locationProvider, $stateProvider) {

    $stateProvider
        .state('home', {
            url: "/?:status",
            params: {
                status: {
                    value: null,
                    squash: true
                }
            },
            views: {
                "body": {
                    templateUrl: "/app/View/home.html",
                    controller: "homeController"
                }
            }
        })
        .state('mapBase', {
            abstract: true,
            url: '/search/:state/:city',
            params: {
                city: {
                    value: null,
                    squash: false
                },
                state: {
                    value: null,
                    squash: false
                }
            },
            views: {
                "body": {
                    templateUrl: "/app/View/map.html"
                },
                "mapfilter": {
                    templateUrl: "/app/View/Partials/_mapFilter.html"
                }
            }
        })
        .state('map', {
            url: "/:nNeighborhood/:mNeighborhood/:sNeighborhood?:type&:minPrice&:maxPrice&:beds&:page&:sortBy&:transaction",
            params: {
                type: {
                    value: window.mobilecheck() ? "gallery" : "map",
                    squash: true
                },
                minPrice: {
                    value: "0",
                    squash: true
                },
                maxPrice: {
                    value: "Max",
                    squash: true
                },
                beds: {
                    array: true

                },
                transaction: {
                    value: "0",
                    squash: true
                },
                page: {
                    value: "1",
                    squash: true
                },
                sortBy: {
                    value: "0",
                    squash: true
                },
                nNeighborhood: {
                    value: null,
                    squash: true
                },
                mNeighborhood: {
                    value: null,
                    squash: true
                },
                sNeighborhood: {
                    value: null,
                    squash: true
                }
            },
            parent: "mapBase",
            views: {
            }
        })
        .state('reset', {
            url: "/reset?code={}",
            views: {
                "body": { templateUrl: "/app/View/reset.html" }
            }
        })
        .state('account', {
            url: "/account",
            views: {
                "secondnav": { templateUrl: "/app/View/Account/Partials/subnav.html" },
                "body": { templateUrl: "/app/View/Account/index.html" }
            },
            abstract: true
        })
        .state('account.edit', {
            url: "",
            views: {
                "subbody": { templateUrl: "/app/View/Account/edit.html" }
            }
        })
 
        .state("path", {
            url: "/{path:.*}",

            views: {
                "secondnav": { templateUrl: "/App/View/Partials/_partDetails.html", controller: 'detailsController' },
                "body": {
                    controller: 'detailsController',
                    templateUrl: "/app/View/details.html"
                }
            }

        });


    $stateProvider.state("otherwise", {
        url: "/404",
        views: {
            "body": { templateUrl: "/app/View/Partials/404.html" }
        }
    });


    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $locationProvider.hashPrefix('!');
}]);
