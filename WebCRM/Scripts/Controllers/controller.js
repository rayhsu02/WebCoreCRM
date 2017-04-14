(function () {
    'use strict';

    angular
        .module('app')
        .controller('customerController', customerController);

    customerController.$inject = ['$scope', 'crmService', '$state', '$filter', 'NgTableParams', '$window'];
   

    function customerController($scope, crmService, $state, $filter, NgTableParams, $window) {

        $scope.title = "customerController";
        $scope.allCustomers = [];
        $scope.customerList = [];
        $scope.getAllCustomer = getAllCustomer;
        $scope.addCustomer = addCustomer;
        $scope.deleteCustomer = deleteCustomer;
        $scope.goToState = goToState;
        $scope.IndustryTypes = [];
        $scope.getIndustryTypes = getIndustryTypes;
        $scope.init = init;
        $scope.closeModal = closeModal;
        $scope.newCompany = { "companyName": "", "websiteUrl": "", "industryTypeId": '', "clientDesignation": true };
        $scope.redirectTo = redirectTo;

        $scope.master = {};
        $scope.reset = function () {
            console.log('reset');
            //$scope.newCompany = angular.copy($scope.master);
        };
        

        //modal
        $scope.showModal = false;
        $scope.buttonClicked = "";
        $scope.toggleModal = function (model) {
            console.log(model);
            debugger;
            if (model == 'new') {
               // model = { "companyName": "", "websiteUrl": "", "industryTypeId": '', "clientDesignation": true };
                $scope.newCompany = { "companyName": "", "websiteUrl": "", "industryTypeId": '', "clientDesignation": true };
            } else {
                model.industryTypeId = model.industryTypeId.toString();
                $scope.newCompany = angular.copy(model);
            }
            //$scope.buttonClicked = model;
           
            $scope.showModal = !$scope.showModal;
        };
        //end of modal

        function init() {
            console.log('call init');

            getAllCustomer();
            getIndustryTypes();
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
                       console.log($scope.allCustomers);

                       $scope.customerList = new NgTableParams({
                           // initial filter
                           filter: { companyName: "" }
                       }, {
                               dataset: res
                           });
                       
                    }
                });
        }

        function addCustomer(newCompany) {

            console.log('addCustomer');
            console.log(newCompany);

            if (newCompany.customerId != undefined) {

                crmService.updateCustomer(newCompany)
                    .then(function (res) {
                        console.log(res);
                        getAllCustomer();

                        closeModal();
                    }, function () {
                        alert(res);
                    });
            } else {

                crmService.addNewCustomer(newCompany)
                    .then(function (res) {
                        console.log(res);
                        getAllCustomer();

                        closeModal();
                    }, function () {
                        alert(res);
                    });
            }
          
        }

        function deleteCustomer(customer) {
            crmService.deleteCustomer(customer)
                .then(function (res) {
                    console.log(res);
                    getAllCustomer();

                    closeModal();
                }, function () {
                    alert(res);
                });
        }

        function goToState(state, model) {
            console.log('goToState');
            $state.go(state, { selectedCustomer: model.customer, primaryContact: model.primaryContact});
        }

        function closeModal() {
            $scope.reset();
            $('#myModal').modal('hide');
        }

        function redirectTo(url) {
            $window.open('http://' + url, '_blank');
        };

        function getIndustryTypes() {
            crmService.getIndustryTypes()
                .then(function (res) {
                    console.log(res);
                    $scope.IndustryTypes = res;
                  
                }, function () {
                    alert(res);
                });
        }
    }
})();
