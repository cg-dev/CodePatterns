app.controller("ContinentsController", function ($scope, $http) {
    $http
        .get("/api/Continent/")
        .success(function (data) {
            $scope.Continents = data;
        })
        .error(function (data) {
            alert("Problem retrieving continent data: " + data);
        });
});