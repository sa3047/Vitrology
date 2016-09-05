'use strict';

var app = angular.module('vitrologyApp');

app.factory('AuthenticationService',
    ['$http', '$cookieStore', '$rootScope', '$timeout',
        function ($http, $cookieStore, $rootScope, $timeout) {
            var service = {};
            var urlBase = 'http://localhost:54522/';

            service.Login = function (email, password, callback) {

                $http.post(urlBase + 'api/User/AuthenticateUser', { email: email, password: password })
                    .success(function (response) {
                        callback(response);
                    });

            };

            // Create global variable 
            service.SetCredentials = function (email, password,id) {

                $rootScope.globals = {
                    currentUser: {
                        id:id,
                        email: email,
                        password: password
                    }
                };

                $cookieStore.put('globals', $rootScope.globals);
            };

            // Clear global variable for user.
            service.ClearCredentials = function () {
                $rootScope.globals = {};
                $cookieStore.remove('globals');
            };

            return service;
        }]);