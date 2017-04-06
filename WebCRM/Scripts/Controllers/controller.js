(function () {
    'use strict';

    angular
        .module('app')
        .controller('customerController', customerController);

    customerController.$inject = ['$scope', 'crmService'];
   

    function customerController($scope, crmService) {

        $scope.title = "customerController";
        $scope.allCustomers = [];
        $scope.getAllCustomer = getAllCustomer;
        $scope.addCustomer = addCustomer;
        $scope.init = init;

        function init() {
            console.log('call init');

            getAllCustomer();
        }

        $scope.init();
        /* jshint validthis:true */
        //var vm = this;
        //vm.title = 'customerController';
        //vm.getAllCustomer = getAllCustomer;
        //vm.allCustomers = [];

        //activate();

        //function activate() {
        //    //console.log('call activate');

        //    getAllCustomer();
        //}

        function getAllCustomer() {
            //console.log('getAllCustomer');

            crmService.getAllCustomers()
                .then(function (res) {
                    console.log(res);
                    console.log('res.data');
                    //console.log(res.data);
                    if (res) {
                       console.log('in the if');
                       // vm.allCustomers = res.dada;
                       $scope.allCustomers = res;
                       console.log('$scope.allCustomers');
                       console.log($scope.allCustomers)
                    }
                });
        }

        function addCustomer() {
            console.log('addCustomer');
        }
    }
})();
