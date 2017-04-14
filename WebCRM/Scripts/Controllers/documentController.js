(function () {
    'use strict';

    angular
        .module('app')
        .controller('documentController', documentController);

    documentController.$inject = ['$scope', 'crmService', '$state', '$filter', 'NgTableParams', '$window'];

    function documentController($scope, crmService, $state, $filter, NgTableParams, $window) {
        /* jshint validthis:true */
        //var vm = this;
        //vm.title = 'documentController';
        $scope.selectedCustomer = $state.params.selectedCustomer;
        $scope.addFile = addFile;

        activate();

        function activate() {
            console.log('selectedCustomer');
            console.log($scope.selectedCustomer);
        }


        function addFile() {
            console.log('addFile');

            var fileUpload = $("#file").get(0);

            console.log(fileUpload);

            crmService.addFile(fileUpload, $scope.selectedCustomer.customerId);

           
        }
    }
})();
