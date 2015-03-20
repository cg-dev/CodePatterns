var app = angular.module("angularApp", ['ngRoute', 'ngResource', 'ui.bootstrap']);

//app.directive('simpleDirective', function() {
//    return {
//        restrict: 'AE',
//        replace: 'true',
//        template: '<h4>A bit of text that has been constructed by a Simple Directive</h4>'
//    };
//});

app.directive('simpleDirective', function () {
    return {
        restrict: 'AE',
        replace: 'true',
        templateUrl: '/Templates/simpleDirective.html'
    };
});