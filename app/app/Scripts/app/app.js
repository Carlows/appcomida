var app = angular.module('mainApp', ['ngRoute'])

app.constant("serverURL", "http://localhost:57916/Registros")

app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider
        .when("/", {
            controller: "RegistrosController",
            templateUrl: "ViewsAngular/productos.html"
        })
        .when("/registro/:registroID", {
            controller: "RegistroController",
            templateUrl: "ViewsAngular/product.html"
        })
        .otherwise({
            redirectTo: "/"
        });
});