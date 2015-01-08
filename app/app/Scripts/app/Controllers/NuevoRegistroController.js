var app = angular.module('mainApp');

app.controller("NuevoRegistroController", function ($scope, $location, registrosService, helperService, uiGmapGoogleMapApi, $log, authService) {

    init();

    function init() {
        if (!authService.authentication.isAuth) {
            $location.path("/login");
        }

        $scope.data = {};
        $scope.currentStep = 1;
        $scope.currentData = {};
        $scope.currentData.Direccion = {};
        $scope.currentData.Direccion.Position = {};
        $scope.currentData.Direccion.Position.Latitud = 9.82743;
        $scope.currentData.Direccion.Position.Longitud = -68.24695;
        $scope.estados = {};
        $scope.estados = helperService.getAllStates();

        $scope.map =
					{
					    center: { latitude: 9.82743, longitude: -68.24695 },
					    zoom: 4,
					    options: { styles: [{ "stylers": [{ "hue": "#007fff" }, { "saturation": 89 }] }, { "featureType": "water", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "administrative.country", "elementType": "labels", "stylers": [{ "visibility": "off" }] }] },
					    marker: {
					        id: 1,
					        coords: {
					            latitude: 9.82743,
					            longitude: -68.24695
					        },
					        options: { draggable: true },
					        events: {
					            dragend: function (marker, eventName, args) {					                
					                $scope.currentData.Direccion.Position.Latitud = marker.getPosition().lat();
					                $scope.currentData.Direccion.Position.Longitud = marker.getPosition().lng();
					            }
					        }
					    }
					};
    }

    function setStep(step) {
        $scope.currentStep = step;
    };

    $scope.setStep = setStep;
    
    $scope.addNewRecord = function () {
        $scope.currentData.Direccion.Estado = $scope.currentData.Direccion.Estado.name;

        var recordPromise = registrosService.addNewRecord($scope.currentData);

        recordPromise.then(function (data) {
            $scope.currentData = {};
            $scope.data.success = true;

            $location.path("/");
        }, function (error) {
            $scope.data.error = true;
        });
    };
});