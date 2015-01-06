var app = angular.module('mainApp');

app.controller('RegistrosController', function ($scope, $http, registrosService, helperService) {

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

    $scope.estados = helperService.getAllStates();

    $scope.searchFn = function (query) {
        alert(query.Busqueda + " " + query.Estado.name);
    };

    $scope.data = {};
});