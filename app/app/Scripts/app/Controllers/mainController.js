var app = angular.module('mainApp');

app.controller('mainController', function ($scope, $location) {
    $scope.isActive = function (path) {
        return path === $location.path();
    };
});