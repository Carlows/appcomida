var app = angular.module('mainApp');

app.filter("bolivares", function () {
    return function (value) {
        stringified = String(value);

        return stringified + " Bs.";
    };
});