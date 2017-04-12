(function () {
    'use strict';

    angular
        .module('app')
        .controller('customerDetailController', customerDetailController);

    customerDetailController.$inject = ['$scope', 'crmService', '$state', '$filter', 'NgTableParams'];

    function customerDetailController($scope, crmService, $state, $filter, NgTableParams) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'customerDetailController';
        console.log('$state.params.selectedCustomer');
        console.log($state.params.selectedCustomer);
        console.log('$state.params.primaryContact');
        console.log($state.params.primaryContact);

        $scope.newCompany = $state.params.selectedCustomer;
        $scope.primaryContact = $state.params.primaryContact;
        $scope.updateCustomer = updateCustomer;
        $scope.IndustryTypes = [{ Name: 'Health Care', Id: '1' }];
        $scope.newContact = { "firstName": "", "lastName": "", "email": "", "phoneNumber": "", "primaryContact": false, "customerId": $scope.newCompany.customerId };
        $scope.showContactModal = showContactModal;
        $scope.addContact = addContact;
        $scope.resetContact = resetContact;
        $scope.getContactsList = getContactsList;
        $scope.getContact = getContact;
        $scope.contacts = [];
        activate();

        function activate() {

           
        }
        //modal
        $scope.showModal = false;
        $scope.buttonClicked = "";
        

        function updateCustomer(newCompany) {

            console.log('updateCustomer');
            console.log(newCompany);

            if (newCompany.customerId != undefined) {

                crmService.updateCustomer(newCompany)
                    .then(function (res) {
                        console.log(res);
                        $state.go('CustomerList');

                    }, function () {
                        alert(res);
                    });
            } 

        } 

        function showContactModal(model) {
            console.log('showContactModal 2');
            if (model == 'new') {
                // model = { "companyName": "", "websiteUrl": "", "industryTypeId": '', "clientDesignation": true };
                //$scope.newCompany = { "companyName": "", "websiteUrl": "", "industryTypeId": '', "clientDesignation": true };
            } else {
                //model.industryTypeId = model.industryTypeId.toString();
                //$scope.newCompany = angular.copy(model);
            }
            //$scope.buttonClicked = model;

            $scope.showModal = !$scope.showModal;

            console.log('$scope.newCompany 2');
            console.log($scope.newCompany);

            if ($scope.showModal) {
                console.log('$scope.newCompany');
                console.log($scope.newCompany);
                resetContact();
                getContactsList($scope.newCompany.customerId);
            }
        }

        function addContact(contact) {
            console.log('select customer id');
            console.log($scope.newCompany.customerId);
            contact.customerId = $scope.newCompany.customerId;

            if (contact.customerContactId != undefined) {
                crmService.updateContact(contact)
                    .then(function (res) {
                        console.log('updateContact');
                        console.log(res);
                        getContactsList($scope.newCompany.customerId);

                    }, function () {
                        alert(res);
                    });

            } else {
                crmService.addNewContact(contact)
                    .then(function (res) {
                        console.log('addNewContact');
                        console.log(res);
                        resetContact();
                        getContactsList($scope.newCompany.customerId);

                    }, function () {
                        alert(res);
                    });
            }

            
        }

        function resetContact() {
            console.log('resetContact');
            $scope.newContact = { "firstName": "", "lastName": "", "email": "", "phoneNumber": "", "primaryContact": false, "customerId": $scope.newCompany.customerId };
        }

        function getContactsList(customerId) {
            crmService.getCustomerContacts(customerId)
                .then(function (res) {
                    console.log('getContactsList');
                    console.log(res);

                   // $scope.contacts = res;

                    $scope.contacts = new NgTableParams({
                        // initial filter
                        //filter: { firstName: "" }
                        count: 5
                    }, {
                            dataset: res
                        });

                }, function () {
                    alert(res);
                });
        }

        function getContact(contact) {
            console.log('getContact');
            console.log(contact);
            $scope.newContact = contact;
        }
    }
})();
