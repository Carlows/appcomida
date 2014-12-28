var app = angular.module('mainApp');

app.factory("helperService", function () {
    return {
        getAllStates: function () {
            var states = [{ name: "Amazonas" }, { name: "Anzoátegui" }, { name: "Apure" }, { name: "Aragua" }, { name: "Barinas" }, { name: "Bolívar" }, { name: "Carabobo" },
                { name: "Cojedes" }, { name: "Delta Amacuro" }, { name: "Caracas" }, { name: "Falcón" }, { name: "Guarico" }, { name: "Lara" }, { name: "Mérida" },
                { name: "Miranda" }, { name: "Monagas" }, { name: "Nueva Esparta" }, { name: "Portuguesa" }, { name: "Sucre" }, { name: "Tachira" }, { name: "Trujillo" },
                { name: "Vargas" }, { name: "Yaracuy" }, { name: "Zulia" }];

            return states;
        }
    }
});