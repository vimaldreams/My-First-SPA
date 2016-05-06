(function (app) {
    'use strict';

    app.factory('apiService', apiService);

    apiService.$inject = ['$http', '$location', '$rootScope'];

    function apiService($http, $location, $rootScope) {
        var service = {
            get: get
        };

        function get(url, config, success) {
            return $http.get(url, config)
                    .then(function (result) {
                        success(result);
                    });
        }

        return service;
    }

})(angular.module('common.core'));