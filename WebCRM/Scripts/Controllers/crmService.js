﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('crmService', crmService);

    crmService.$inject = ['$http'];

    function crmService($http) {
        

        var service = {
            getAllCustomers: getAllCustomers,
            addNewCustomer: addNewCustomer,
            updateCustomer: updateCustomer,
            deleteCustomer: deleteCustomer,
            getCustomerContacts: getCustomerContacts,
            addNewContact: addNewContact,
            updateContact: updateContact,
            deleteContact: deleteContact,
            getIndustryTypes: getIndustryTypes,
            addFile: addFile
        };

        return service;

        function getAllCustomers() {
           
            return $http.get('/api/Customers/').then(handleSuccess, handleError('Error getting all customers'));
        }

        function addNewCustomer(newCustomer) {
          
            return $http.post('/api/Customers/', newCustomer);
        }

        function updateCustomer(customer) {

            return $http.put('/api/Customers/' + customer.customerId, customer);
        }

        function deleteCustomer(customer) {

            return $http.delete('/api/Customers/' + customer.customerId);
        }

        function getCustomerContacts(customerId) {

            return $http.get('/api/CustomerContacts/GetCustomerContactsByCustomerID/' + customerId).then(handleSuccess, handleError('Error getting contacts'));
        }

        function addNewContact(contact) {
            return $http.post('/api/CustomerContacts/', contact);
        }

        function updateContact(contact) {

            return $http.put('/api/CustomerContacts/' + contact.customerContactId, contact);
        }

        function deleteContact(contact) {
            console.log('deleteContact');
            console.log(contact);
            return $http.delete('/api/CustomerContacts/' + contact.customerContactId);
        }

        function getIndustryTypes() {

            return $http.get('/api/IndustryTypes/').then(handleSuccess, handleError('Error getting Industry Types'));
        }

        function addFile(fileUpload, customerId) {
           
            var files = fileUpload.files;
            var fd = new FormData();
            for (var i = 0; i < files.length; i++) {
                fd.append(files[i].name, files[i]);
            }

            fd.append("customerId", JSON.stringify(customerId));

            console.log('addFile data');
            console.log(fd);

            $http.post("/api/CustomerDocuments/", fd, {
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        }

        // private functions

        function handleSuccess(res) {
           // return { success: true, data: res.data };
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }


    }
})();