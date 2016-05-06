(function (app) {
    'use strict';

    app.controller('moviesCtrl', moviesCtrl);

    moviesCtrl.$inject = ['$scope', '$modal', 'apiService'];

    function moviesCtrl($scope, $modal, apiService) {
        $scope.loadingMovies = true;
        $scope.Movies = [];

        $scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.openEditDialog = openEditDialog;

        function openEditDialog(movie) {
            $scope.DisplayMovie = movie;
            $modal.open({
                templateUrl: 'scripts/spa/movies/displayMovieModal.html',
                controller: 'displayMovieCtrl',
                scope: $scope
            }).result.then(function ($scope) {
                clearSearch();
            }, function () {
            });
        }

        function search() {

            $scope.loadingMovies = true;

            var config = {
                params: {
                    filter: $scope.filterMovies
                }
            };
            
            apiService.get('/api/movies/', config, moviesLoadCompleted);
        }

        function moviesLoadCompleted(result) {
            $scope.Movies = result.data;
            $scope.loadingMovies = false;
        }

        function clearSearch() {
            $scope.filterMovies = '';
            search();
        }

        $scope.search();
    }

})(angular.module('homeCinema'));