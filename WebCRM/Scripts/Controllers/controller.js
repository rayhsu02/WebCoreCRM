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
        $scope.IndustryTypes = [{Name: 'Health Care', Id: '1'}];
        $scope.init = init;
        $scope.closeModal = closeModal;

        $scope.master = {};
        $scope.reset = function () {
            console.log('reset');
            $scope.newCompany = angular.copy($scope.master);
        };
        

        //modal
        $scope.showModal = false;
        $scope.buttonClicked = "";
        $scope.toggleModal = function (btnClicked) {
            console.log(btnClicked);
            $scope.buttonClicked = btnClicked;
            $scope.showModal = !$scope.showModal;
        };
        //end of modal

        function init() {
            console.log('call init');

            getAllCustomer();
            $scope.reset();
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
                       //console.log('in the if');
                       // vm.allCustomers = res.dada;
                        $scope.allCustomers = res;
                        
                       console.log('$scope.allCustomers');
                       console.log($scope.allCustomers)
                    }
                });
        }

        function addCustomer(newCompany) {

            console.log('addCustomer');
            console.log(newCompany);

            crmService.addNewCustomer(newCompany)
                .then(function (res) {
                    console.log(res);
                    getAllCustomer();

                    closeModal();
                }, function () {
                    alert(res);
                });
           
          
        }

        function closeModal() {
            $scope.reset();
            $('#myModal').modal('hide');
        }

        $scope.safeApply = function (fn) {
            var phase = this.$root.$$phase;
            if (phase == '$apply' || phase == '$digest') {
                if (fn && (typeof (fn) === 'function')) {
                    fn();
                }
            } else {
                this.$apply(fn);
            }
        };
    }
})();
