﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('crmService', crmService);

    crmService.$inject = ['$http'];

    function crmService($http) {
        var service = {
            getAllCustomers: getAllCustomers,
            addNewCustomer: addNewCustomer
        };

        return service;

        function getAllCustomers() {
           
            return $http.get('/api/Customers/').then(handleSuccess, handleError('Error getting all customers'));
        }

        function addNewCustomer() {
            console.log('addNewCustomer');
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