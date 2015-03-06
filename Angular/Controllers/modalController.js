
app.controller('modalController', function ($scope, $modal) {
    $scope.open = function(size) {
        var modalInstance = $modal.open({
            templateUrl: '/Templates/modalForm.html',
            controller: 'modalInstanceController',
            size: size
        });
    }
});

app.controller('modalInstanceController', function ($scope, $modalInstance) {
    $scope.ok = function() {
        $modalInstance.close();
    };

    $scope.cancel = function() {
        $modalInstance.dismiss('cancel');
    };
});