app.controller("CountryController", function ($scope, $http) {
    $http.get("http://www.w3schools.com/website/Customers_JSON.php").success(function (response) { $scope.names = response; });
    $scope.sortOrder = "Name";
    $scope.toggleSortOrder = function () {
        if ($scope.sortOrder === "Name") {
            $scope.sortOrder = "Country";
        } else {
            $scope.sortOrder = "Name";
        }
    };
});