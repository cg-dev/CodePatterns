app.controller("countryListController", function ($scope, $http, $modal) {

    $http.get("/api/Continent/")
    .success(function (data) {
        $scope.Continents = data;
    })
    .error(function (data) {
        alert("Problem retrieving continent data: " + data);
    });
    
    $http.get("/api/Country/")
    .success(function (data) {
        $scope.Countries = data;
    })
    .error(function (data) {
        alert("Problem retrieving country data: " + data);
    });
    
    $scope.GetCountriesFilteredByContinent = function (continentId) {
        $http.get("/api/CountriesForContinent?continentId=" + continentId.toString())
            .success(function (data) {
                $scope.Countries = data;
            })
            .error(function (data) {
                alert("Problem retrieving continent data: " + data);
            });
    };
    
    $scope.open = function (continentId, size) {
        $modal.open({
            templateUrl: '/Templates/countryDetails.html?ContinentId=' + continentId.toString(),
            controller: 'countryDetailsController',
            size: size
        });
    };
});