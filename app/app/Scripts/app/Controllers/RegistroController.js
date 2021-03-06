﻿var app = angular.module('mainApp');

app.controller('RegistroController', function ($scope, $routeParams, $timeout, uiGmapGoogleMapApi, registrosService) {
    init();

    function init() {
        var recordsPromise = registrosService.getRecord($routeParams.registroID);
        $scope.loadingContent = true;
        $scope.mapLoaded = false;

        $scope.data = {
            record: {}
        };

        $scope.map = {
            center: { latitude: 9.82743, longitude: -68.24695 }, zoom: 4, options: { styles: [{ "stylers": [{ "hue": "#007fff" }, { "saturation": 89 }] }, { "featureType": "water", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "administrative.country", "elementType": "labels", "stylers": [{ "visibility": "off" }] }] },
            marker: {
                id: 1,
                coords: {
                    latitude: 9.82743,
                    longitude: -68.24695
                }
            }
        };

        recordsPromise.then(function (datos) {
            $scope.data.record = datos.data;

            if (datos.data.Producto.Regulado) {
                $scope.regulado = true;
            }
            else {
                $scope.noRegulado = true;
            }

            $scope.map = {
                center: { latitude: datos.data.Direccion.Position.Latitud, longitude: datos.data.Direccion.Position.Longitud },
                zoom: 14,
                options: { styles: [{ "stylers": [{ "hue": "#007fff" }, { "saturation": 89 }] }, { "featureType": "water", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "administrative.country", "elementType": "labels", "stylers": [{ "visibility": "off" }] }] },
                marker: {
                    id: 1,
                    coords: {
                        latitude: datos.data.Direccion.Position.Latitud,
                        longitude: datos.data.Direccion.Position.Longitud
                    }
                }
            };

            $timeout(function () {
                $scope.mapLoaded = true;
            }, 1000);

            $scope.loadingContent = false;
        }, function (error) {
            $scope.data.error = error;
            $scope.loadingContent = false;
        });
    };
    
    $scope.voteUp = function (id) {
        registrosService.voteOnRecord(id, true).then(function (votes) {
            $scope.data.record.VoteCount = votes.data.count;
        });
    };

    $scope.voteDown = function (id) {
        registrosService.voteOnRecord(id, false).then(function (votes) {
            $scope.data.record.VoteCount = votes.data.count;
        });
    };
});