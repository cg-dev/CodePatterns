app.controller("CountryController", function ($scope, $http) {
    $http.get("http://www.w3schools.com/website/Customers_JSON.php").success(function (response) { $scope.names = response; });
    $scope.sortOrder = "Name";
    $scope.nextOrder = "Name (descending)";
    $scope.toggleSortOrder = function () {
        if ($scope.sortOrder === "Name") {
            $scope.sortOrder = "-Name";
            $scope.nextOrder = "Country";
        } else {
            if ($scope.sortOrder === "-Name") {
                $scope.sortOrder = "Country";
                $scope.nextOrder = "Country (descending)";
            } else {
                if ($scope.sortOrder === "Country") {
                    $scope.sortOrder = "-Country";
                    $scope.nextOrder = "Name";
                } else {
                    $scope.sortOrder = "Name";
                    $scope.nextOrder = "Name (descending)";
                }
            }
        }
    };
});