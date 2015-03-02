app.controller("VolumeCalculatorController", function ($scope) {
    
    $scope.height = 0;
    $scope.width = 0;
    $scope.depth = 0;
    
    $scope.volume = function () {
        if ($scope.height && $scope.width && $scope.depth) {
            return $scope.height * $scope.width * $scope.depth;
        } else {
            return "Missing at least one value.";
        }
    };
});