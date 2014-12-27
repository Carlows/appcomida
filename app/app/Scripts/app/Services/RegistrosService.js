var app = angular.module('mainApp');

app.factory("registrosService", function ($http, $q, serverURL) {
    return {
        getAllRecords: function () {
            var deferred = $q.defer();

            $http.get(serverURL + '/GetAllRecords').then(function (data) {
                deferred.resolve(data);
            });
            
            return deferred.promise;
        }
    }
});