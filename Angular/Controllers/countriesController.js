app.controller("CountriesController", function ($scope, $http) {
    $http.get('http://localhost:49679/api/countries')
        .success(function (data) {
            $scope.Countries = data;
        })
        .error(function (data) {
            alert(data);
        });
});