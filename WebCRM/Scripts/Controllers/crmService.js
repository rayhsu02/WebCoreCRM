(function () {
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
            deleteContact: deleteContact
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

            return $http.delete('/api/CustomerContacts/' + contact.CustomerContactId);
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