var app = angular.module("angularApp", ['ngRoute', 'ngResource', 'ui.bootstrap']);

app.directive('simpleDirective', function () {
    return {
        restrict: 'AE',
        scope: {
            sdValue: '@'
        },
        replace: 'true',
        templateUrl: '/Templates/simpleDirective.html',
        link: function($scope, element, attrs) {
            element.bind('mouseenter', function() {
                element.css('background-color', 'yellow');
            });
            element.bind('mouseleave', function () {
                element.css('background-color', 'white');
            });
        }
    };
});