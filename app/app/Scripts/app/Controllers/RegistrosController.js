var app = angular.module('mainApp');

app.controller('RegistrosController', function ($scope, $http, registrosService) {

    init();
    
    function init() {
        var recordsPromise = registrosService.getAllRecords();
        $scope.loadingContent = true;

        recordsPromise.then(function (datos) {
            $scope.data.records = datos.data;
            $scope.loadingContent = false;
        }, function (error) {
            $scope.data.error = error;
            $scope.loadingContent = false;
        });
    };

    $scope.data = {};
});