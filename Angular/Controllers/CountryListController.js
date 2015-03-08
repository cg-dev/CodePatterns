app.controller("CountryListController", function ($scope, $http) {
    $http
        .get("/api/Country/")
        .success(function (data) {
            $scope.Countries = data;
        })
        .error(function (data) {
            alert("Problem retrieving country data: " + data);
        });
    
    $http
    .get("/api/Continent/")
    .success(function (data) {
        $scope.Continents = data;
    })
    .error(function (data) {
        alert("Problem retrieving continent data: " + data);
    });
    
    $scope.GetCountriesFilteredByContinent = function (continentId) {
        $http
            .get("/api/CountriesForContinent?continentId=" + continentId.toString())
            .success(function (data) {
                $scope.Countries = data;
            })
            .error(function (data) {
                alert("Problem retrieving continent data: " + data);
            });
    };
});