'use strict';

/**
 * @ngdoc overview
 * @name vitrologyApp
 * @description
 * # vitrologyApp
 *
 * Main module of the application.
 */

angular
  .module('vitrologyApp', ['ngRoute', 'ngCookies'])
    .controller('appCtrl',function ($scope) {
        $scope.message = 'on Index page';
    })
  .config(function ($routeProvider) {
      $routeProvider
        .when('/login', {
            templateUrl: 'app/views/login.html',
            controller: 'LoginCtrl'
        })
        .when('/', {
            templateUrl: 'app/views/main.html',
            controller: 'MainCtrl',
            controllerAs: 'main'
        })
        .when('/about', {
            templateUrl: 'app/views/about.html',
            controller: 'AboutCtrl',
            controllerAs: 'about'
        })
        .when('/contact', {
            templateUrl: 'app/views/contact.html',
            controller: 'ContactCtrl',
            controllerAs: 'contact'
        })
        .when('/userdetails', {
            templateUrl: 'app/views/userdetails.html',
            controller: 'UserdetailsCtrl',
            controllerAs: 'userdetails'
        })
        .when('/register', {
            templateUrl: 'app/views/register.html',
            controller: 'RegisterCtrl',
            controllerAs: 'register'
        })
        .otherwise({
            redirectTo: '/login'
        });
  })
  .run(['$rootScope', '$location', '$cookieStore', '$http',
    function ($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in
            //
            if ($location.path() !== '/register' && $location.path() !== '/login' && !$rootScope.globals.currentUser) {
                console.log($location.path());
                $location.path('/login');
            }
        });
    }]);