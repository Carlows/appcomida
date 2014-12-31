var app = angular.module('mainApp');

app.controller('mainController', function ($scope, $location, authService) {
    $scope.isActive = function (path) {
        return path === $location.path();
    };

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/');
    }

    $scope.authentication = authService.authentication;
});