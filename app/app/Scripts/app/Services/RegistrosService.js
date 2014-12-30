var app = angular.module('mainApp');

app.factory("registrosService", function ($http, $q, serverURL) {
    return {
        getAllRecords: function () {
            var deferred = $q.defer();

            $http.get(serverURL + '/GetAllRecords').then(function (data) {
                deferred.resolve(data);
            });
            
            return deferred.promise;
        },
        addNewRecord: function (newRecord) {
            var deferred = $q.defer();

            $http.post(serverURL + "/CreateRecord", newRecord).then(function (data) {
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        },
        getRecord: function (id) {
            var deferred = $q.defer();

            if (angular.isNumber(Number(id))) {
                var query = serverURL + "/GetRecord/" + id;

                $http.get(query).then(function (data) {
                    deferred.resolve(data);
                }, function (error) {
                    deferred.reject(error);
                });
            } else {
                deferred.reject("el id debe ser un numero");
            }

            return deferred.promise;
        }
    }
});