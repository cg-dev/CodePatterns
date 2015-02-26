(function() {
    'use strict';
    var countriesServices = angular.module('countriesServices', ['ngRescource']);
    countriesServices.factory('Countries', [
        '$resource',
        function($resource) {
            return $resource('/api/countries/', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }
    ]);
})();