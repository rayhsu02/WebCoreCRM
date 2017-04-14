(function () {
    'use strict';

    angular.module('app', [
        // Angular modules 
        //'ngRoute'

        // Custom modules 

        // 3rd Party Modules
        //"ngTable"
        "ui.router",
        'ngTable'
    ])
        .config(config);
        //.run(['$rootScope', '$state', '$stateParams',
        //    function ($rootScope, $state, $stateParams) {
        //        $rootScope.$state = $state;
        //        $rootScope.$stateParams = $stateParams;
        //    }]);

    config.$inject = ['$urlRouterProvider', '$stateProvider', '$locationProvider'];

    function config($urlRouterProvider, $stateProvider, $locationProvider) {
        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/CustomerList")


        $stateProvider
            .state('CustomerList', {
                url: "/CustomerList",
                templateUrl: "/templates/CustomerList.html",
                controller:"customerController"
            })
            .state('CustomerDetail', {
                url: "/CustomerDetail",
                templateUrl: "/templates/CustomerDetail.html",
                params: { selectedCustomer: null, primaryContact: null},
                controller: "customerDetailController"
            })

            .state('DocumentList', {
                url: "/DocumentList",
                templateUrl: "/templates/DocumentList.html",
                params: { selectedCustomer: null },
                controller: "documentController"
            })
            //.state('route2.list', {
            //    url: "/list",
            //    templateUrl: "route2.list.html",
            //    controller: function ($scope) {
            //        $scope.things = ["A", "Set", "Of", "Things"];
            //    }
            //})
    }

})();