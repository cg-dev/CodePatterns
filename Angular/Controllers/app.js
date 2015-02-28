var angularApp = angular.module('angularApp', ['ngRoute', 'ngResource']).
    config(function($routeProvider) {
        $routeProvider.
            when('/', { controller: ListCtrl, templateUrl: 'list.html' }).
            otherwise({ redirectTo: '/' });
    });

angularApp.factory('angularApp', function ($scope, $resource) {
    $scope.eventLog = eventLog & "angularApp called.";
    return $resource('/api/countries/', { update: { method: 'PUT' } });
});

var ListCtrl = function($scope, $location, angularApp) {
    $scope.eventLog = eventLog & "ListCtrl called.";
    $scope.countries = angularApp.query();
}