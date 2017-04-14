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
        $scope.getCustomerDocumentsByCustomerID = getCustomerDocumentsByCustomerID;
        $scope.documentList = [];
        $scope.deleteDocument = deleteDocument;
        $scope.viewFile = viewFile;
        $scope.requestSignOnDocument = requestSignOnDocument;
        $scope.showDocSignModal = showDocSignModal;
        //modal
        $scope.showModal = false;

        activate();

        function activate() {
            console.log('selectedCustomer');
            console.log($scope.selectedCustomer);
            getCustomerDocumentsByCustomerID($scope.selectedCustomer.customerId);
        }


        function addFile() {
            console.log('addFile');

            var fileUpload = $("#file").get(0);

            console.log(fileUpload);

            crmService.addFile(fileUpload, $scope.selectedCustomer.customerId)
                .then(function (res) {
                    getCustomerDocumentsByCustomerID($scope.selectedCustomer.customerId);

                }, function () {
                    alert(res);
                });
        }

        function getCustomerDocumentsByCustomerID(customerId) {

            crmService.getCustomerDocumentsByCustomerID(customerId)
                .then(function (res) {
                   

                    $scope.documentList = new NgTableParams({
                        // initial filter
                        //filter: { firstName: "" }
                        //count: 5
                    }, {
                            dataset: res
                        });

                }, function () {
                    alert(res);
                });
        }

        function deleteDocument(document) {

            crmService.deleteDocument(document)
                .then(function (res) {
                    getCustomerDocumentsByCustomerID($scope.selectedCustomer.customerId);

                }, function () {
                    alert(res);
                });
        }

        function viewFile(document) {
            console.log('view file');
            console.log(document);

            $window.open('/api/CustomerDocuments/' + document.fileId);

           
        }

        function requestSignOnDocument(document) {
            crmService.requestSignatureOnDocument(document)
                .then(function (res) {
                    console.log('requestSignOnDocument sent');

                }, function () {
                    alert(res);
                });
        }

        function showDocSignModal(model) {

            console.log('showDocSignModal');
            
            //$scope.buttonClicked = model;

            $scope.showModal = !$scope.showModal;

          

            if ($scope.showModal) {
              
            }
        }
    }
})();
