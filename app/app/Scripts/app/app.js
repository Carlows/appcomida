var app = angular.module('mainApp', ['ngRoute', 'uiGmapgoogle-maps', 'ngAnimate', 'LocalStorageModule'])

app.constant("serverBase", "http://appcomida.apphb.com/");
app.constant("serverURL", "http://appcomida.apphb.com/Registros");

app.config(function ($routeProvider, $locationProvider, $httpProvider) {
    $locationProvider.html5Mode(true);

    $httpProvider.interceptors.push('authInterceptorService');
    
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
        .when("/login", {
            controller: "LoginController",
            templateUrl: "ViewsAngular/login.html"
        })
        .when("/registrarse", {
            controller: "SignupController",
            templateUrl: "ViewsAngular/registro.html"
        })
        .otherwise({
            redirectTo: "/"
        });
});

app.run(function (authService) {
    authService.fillAuthData();
});