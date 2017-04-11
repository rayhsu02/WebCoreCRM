(function () {
    'use strict';

    angular
        .module('app')
        .controller('customerDetailController', customerDetailController);

    customerDetailController.$inject = ['$scope', 'crmService', '$state'];

    function customerDetailController($scope, crmService, $state) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'customerDetailController';
        console.log('$state.params.selectedCustomer');
        console.log($state.params.selectedCustomer);
        $scope.newCompany = angular.copy($state.params.selectedCustomer);
        $scope.updateCustomer = updateCustomer;
        $scope.IndustryTypes = [{ Name: 'Health Care', Id: '1' }];

        //activate();

        //function activate() { }

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
    }
})();
