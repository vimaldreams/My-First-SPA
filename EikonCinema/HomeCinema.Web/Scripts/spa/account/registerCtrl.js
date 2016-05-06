(function (app) {
    'use strict';

    app.controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', 'membershipService', '$rootScope', '$location'];

    function registerCtrl($scope, membershipService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.register = register;
        $scope.user = {};

        function register() {
            membershipService.register($scope.user, registerCompleted)
        }

        function registerCompleted(result) {
            if (result.data.success) {
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                $location.path('/');
            }
            else {
                alert('Registration failed. Try again.');
            }
        }
    }

})(angular.module('common.core'));