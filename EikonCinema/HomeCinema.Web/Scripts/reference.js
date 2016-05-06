var app = angular.module('app', []);

app.directive('fancybox', function($compile, $parse) 
{
    return {
        restrict: 'C',
        replace: false,
        link: function($scope, element, attrs) {

            $scope.$watch(function() { return element.attr('openbox') }, function(openbox) 
            {
                if (openbox == 'show') {

                    var options = $parse(attrs.options)($scope) || {};

                    if (!options.href && !options.content) {

                        options.content = angular.element(element.html()); 

                        $compile(options.content)($scope);

                    }
					
                    var onClosed = options.onClosed || function() {};

                    options.onClosed = function() {
                        $scope.$apply(function() {
                            onClosed();
                            element.attr('openbox', 'hide');
                        });
                    };

                    $.fancybox(options);
                }
            });		 
        }
    };
})

//add controller
app.controller('SearchController', function ($scope, $http) {

    $scope.openBox = function (id) {
        $(id).attr('openbox', 'show');
    }

    $scope.init = function () {
        $scope.items = [];
        //$scope.search = search;
        //$scope.clearSearch = clearSearch;

        //perform ajax call.
        $http({
            url: "/response/search",
            method: "GET"
        }).success(function (data, status, headers, config) {

            //copy the data we get to our items array. we need to use angular.copy so that
            //angular can track the object and bind it automatically.
            angular.copy(data, $scope.items);

        }).error(function (data, status, headers, config) {
            //something went wrong
            alert('Error getting data');
        });
    }
                        
    $scope.search = function () {
                
        $scope.searchterm = $("#inputSearchMovies").val();
                
        //perform ajax call.
        $http({
            url: "/response/search",
            method: "GET",                
            params: { searchTerm: $scope.searchterm },
        }).success(function (data, status, headers, config) {

            //copy the data we get to our items array. we need to use angular.copy so that
            //angular can track the object and bind it automatically.
            angular.copy(data, $scope.items);

        }).error(function (data, status, headers, config) {
            //something went wrong
            alert('Error getting data');
        });
    }


    $scope.clearSearch = function () {
        $scope.filterMovies = '';
        $scope.init();
    }
});
