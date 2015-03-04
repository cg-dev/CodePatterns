app.controller("CountriesController", function ($scope, $http) {
    $http
        .get('http://localhost:33651/api/NewCountry')
        .success(function (data) {
            $scope.Countries = data;
        })
        .error(function (data) {
            alert("Problem retrieving data: " + data);
        });
});