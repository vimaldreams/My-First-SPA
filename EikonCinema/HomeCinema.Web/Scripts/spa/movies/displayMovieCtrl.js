(function (app) {
    'use strict';

    app.controller('displayMovieCtrl', displayMovieCtrl);

    displayMovieCtrl.$inject = ['$scope', '$modalInstance'];

    function displayMovieCtrl($scope, $modalInstance) {

        $scope.closeMovie = closeMovie;

        function closeMovie() {
            $modalInstance.dismiss();
        }

    }

})(angular.module('homeCinema'));