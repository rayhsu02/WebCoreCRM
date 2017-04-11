(function () {
    'use strict';

    angular
        .module('app')
        .directive('customerContact', customerContact);

    customerContact.$inject = ['$window'];

    function customerContact($window) {
        // Usage:
        //     <contactDirective></contactDirective>
        // Creates:
        // 
        var directive = {
            templateUrl: '/templates/CustomerContactsModal.html',
            restrict: 'E',
            transclude: true,
            replace: true,
            scope: true,
            link: link
        };
        return directive;

        function link(scope, element, attrs) {

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