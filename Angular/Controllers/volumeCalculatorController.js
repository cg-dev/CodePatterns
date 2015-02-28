function VolumeCalculator($scope) {
    $scope.volume = function () {
        if ($scope.height && $scope.width && $scope.depth) {
            return $scope.height * $scope.width * $scope.depth;
        } else {
            return "Missing at least one value";
        }
    };
};