var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/home", {
            templateUrl: "js/Home/home.html",
            controller: "home",
            controllerAs: "vm"
        })
        .when("/about", {
            templateUrl: "js/About/about.html",
            controller: "about",
            controllerAs: "vm"

        })
        .otherwise({ redirectTo: "/home" });
    //$locationProvider.html5Mode(true);
}); 


