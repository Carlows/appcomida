var app = angular.module('mainApp', ['ngRoute', 'uiGmapgoogle-maps', 'ngAnimate'])

app.constant("serverURL", "http://localhost:57916/Registros")

app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider
        .when("/", {
            controller: "RegistrosController",
            templateUrl: "ViewsAngular/productos.html"
        })
        .when("/nuevoRegistro", {
            controller: "NuevoRegistroController",
            templateUrl: "ViewsAngular/nuevoregistro.html"
        })
        .when("/registro/:registroID", {
            controller: "RegistroController",
            templateUrl: "ViewsAngular/producto.html"
        })
        .otherwise({
            redirectTo: "/"
        });
});