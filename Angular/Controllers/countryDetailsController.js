app.controller('countryDetailsController', function ($scope, $http, $modalInstance) {

    $http.get("/api/Country/4")
    .success(function (data) {
        $scope.Country = data;
    })
    .error(function (data) {
        alert("Problem retrieving country data: " + data);
    });
    
    $scope.ok = function () {
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});