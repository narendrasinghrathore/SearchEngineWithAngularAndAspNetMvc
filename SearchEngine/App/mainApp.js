var mainApp = angular.module('mainApp', ['ngRoute', 'serviceApp']);

//Routing
mainApp.config(function ($routeProvider) {
    $routeProvider.when('/About', {
        controller: 'aboutCtrl',
        templateUrl: 'Partials/About.html'
    }).when('/Search', {
        controller: 'searchCtrl',
        templateUrl: 'Partials/Search.html'
    }).when('/Home',{
        controller:'homeCtrl',
        templateUrl:'Partials/Home.html'
    }).otherwise({
        controller:'homeCtrl',
        templateUrl:'Partials/Home.html'
    })
    
});


//Controllers

// 1.Home page.
mainApp.controller('homeCtrl', ['$scope', function ($scope) {
    $scope.title = "Welcome to home page";
                        
}]);
// 2.Search page.
mainApp.controller('searchCtrl', ['$scope','$http', function ($scope,$http) {

    $scope.title = "Search page";
    $scope.m = "";
    $scope.term = "";
    $scope.results = "";
    $scope.validate = function () {

        if ($scope.term.length < 3) {
            $scope.m = "Search term should have more than 3 characters.";
        }
        else {
            $scope.m = "Wait, searching for: " + $scope.term;
            $scope.results = load();
            console.log($scope.results);
        }
    };
    var load = function () {
        console.log('Hi');
        $http.get('http://localhost:64318/api/values').then(function (response) {
            return response;
        });
       };
    


}]);
// 3.About page.
mainApp.controller('aboutCtrl',['$scope',function($scope){
    $scope.title="About Page";
}]);

