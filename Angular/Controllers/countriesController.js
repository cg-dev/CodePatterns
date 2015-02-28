(function() {
    'use strict';
    angular
        .module('demoApp')
        .controller('countriesController', countriesController);

    countriesController.$inject = ['$scope', 'Countries'];

    function countriesController($scope, Countries) {
        $scope.Countries = Countries.query();
    }
})();