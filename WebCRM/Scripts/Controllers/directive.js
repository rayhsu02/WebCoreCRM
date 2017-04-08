(function () {
    'use strict';

    angular
        .module('app')
        .directive('mymodal', mymodal);

    //mymodal.$inject = ['$window'];

    function mymodal() {
       
        var directive = {
            templateUrl: '/templates/customerModal.html',
            restrict: 'E',
            transclude: true,
            replace: true,
            scope: true,
            link: link
        };
        return directive;

        function link(scope, element, attrs) {

            console.log('link scope');
            console.log(scope);

            scope.$watch(attrs.visible, function (value) {
                if (value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });

            $(element).on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = true;
                });
            });

            $(element).on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = false;
                });
            });
        }
    }

})();