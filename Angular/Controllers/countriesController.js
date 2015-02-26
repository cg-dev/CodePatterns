(function() {
    'use strict';
    angular
        .module('MyApp')
        .controller('countriesController', countriesController);

    countriesController.$inject = ['$scope', 'Countries'];

    function countriesController($scope, Countries) {
        $scope.Countries = Countries.query();
    }
})();