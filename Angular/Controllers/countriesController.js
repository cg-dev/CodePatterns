app.controller("CountriesController", function ($scope, $http) {
    $http
        .get("/api/Country/")
        .success(function (data) {
            $scope.Countries = data;
        })
        .error(function (data) {
            alert("Problem retrieving country data: " + data);
        });
});