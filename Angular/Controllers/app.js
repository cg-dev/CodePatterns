var app = angular.module("angularApp", ['ngRoute', 'ngResource', 'ui.bootstrap']);

app.directive('simpleDirective', function () {
    return {
            restrict: 'AE',
            require: '^ngModel',
            scope: { testvalue: '=' },
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

app.directive('ngSparkline', function () {
    return {
        restrict: 'A',
        require: '^ngModel',
        scope: { city: '=' },
        template: '<div><h4>Weather for {{city}}</h4></div>'
    };
});