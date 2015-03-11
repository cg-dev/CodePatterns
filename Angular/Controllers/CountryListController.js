app.controller("countryListController", function ($scope, $http, $modal) {
    
    $http.get("/api/Country/")
    .success(function (data) {
        $scope.Countries = data;
    })
    .error(function (data) {
        alert("Problem retrieving country data: " + data);
    });
    
    $http.get("/api/Continent/")
    .success(function (data) {
        $scope.Continents = data;
    })
    .error(function (data) {
        alert("Problem retrieving continent data: " + data);
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
    
    $scope.open = function (countryId) {
        $modal.open({
            templateUrl: '/Templates/countryDetails.html?countryId=' + countryId.toString(),
            controller: 'countryDetailsController',
            size: size
        });
    };
});

app.controller('countryDetailsController', function ($scope, $modalInstance) {
    $scope.ok = function () {
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});