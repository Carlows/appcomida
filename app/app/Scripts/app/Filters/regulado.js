var app = angular.module('mainApp');

app.filter("regulado", function () {
    return function (value) {
        if (value) {
            return "regulado";
        }
        else {
            return "no regulado";
        }
    };
});