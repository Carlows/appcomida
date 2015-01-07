var app = angular.module('mainApp');

app.controller('RegistrosController', function ($scope, $http, registrosService, helperService) {

    $scope.loadingContent = true;
    $scope.emptyContent = false;

    registrosService.getAllRecords().then(function (datos) {
        $scope.data.records = datos.data;
        $scope.loadingContent = false;
        $scope.emptyContent = datos.data.length == 0 ? true : false;
    }, function (error) {
        $scope.data.error = error;
        $scope.loadingContent = false;
    });

    $scope.estados = helperService.getAllStates();
    
    $scope.searchFn = function (query) {
        
        $scope.data.records = {};

        var querydata = "";
        var statedata = "";

        if (angular.isDefined(query)) {
            querydata = angular.isDefined(query.Busqueda) ? query.Busqueda : "";
            statedata = angular.isDefined(query.Estado) ? query.Estado.name : "";
        }

        $scope.loadingContent = true;

        registrosService.findRecords(querydata, statedata).then(function(datos){
            $scope.data.records = datos.data;
            $scope.emptyContent = datos.data.length == 0 ? true : false;
            $scope.loadingContent = false;
            $scope.data.error = null;
        }, function(error){
            $scope.data.error = error;
            $scope.loadingContent = false;
        });
    };

    $scope.data = {};
});