var app = angular.module("ConversionApp", []);
app.service("ApiService", function($http) {
    this.Convert = function(amount, name, successF, errorF) {
        $http.post("/api/textconversion", { Amount: amount, Name: name }).then(successF, errorF);
    };
});