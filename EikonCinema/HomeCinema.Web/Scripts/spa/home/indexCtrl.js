(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'apiService'];

    function indexCtrl($scope, apiService) {
        $scope.loadingMovies = true;

        $scope.latestMovies = [];
        $scope.loadData = loadData;

        function loadData() {
            apiService.get('/api/movies/latest', null,
                        moviesLoadCompleted);
        }

        function moviesLoadCompleted(result) {
            $scope.latestMovies = result.data;
            $scope.loadingMovies = false;
        }

        $scope.loadData();
    }

})(angular.module('homeCinema'));