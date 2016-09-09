﻿'use strict';

/**
 * @ngdoc function
 * @name vitrologyApp.controller:LoginCtrl
 * @description 
 * # LoginCtrl handles authentication for user.
 */
angular.module('vitrologyApp')
    .controller('LoginCtrl', function ($scope, $rootScope, $location, AuthenticationService) {
        $scope.header = 'Login page.';
        $rootScope.hideMenus = false;
        $scope.error = false;
        $scope.errorMessage = '';
        // reset login status
        AuthenticationService.ClearCredentials();

        $scope.login = function () {
            $scope.dataLoading = true;
            AuthenticationService.Login($scope.email, $scope.password, function (response) {
                var parseResponse = JSON.parse(response);
                console.log('Authenticated user ' + parseResponse.Success);
                //console.log('Authenticated Message ' + parseResponse.Message);
                if (parseResponse.Success) {
                    console.log('user id: ' + parseResponse.Id);
                    AuthenticationService.SetCredentials($scope.email, $scope.password, parseResponse.Id);
                    // TODO : Hide menu
                    $rootScope.hideMenus = true;
                    // Go to main page
                    $scope.error = false;

                    $location.path('/');
                } else {
                    console.log('Authenticated Message: ' + parseResponse.Message);
                    $scope.error = true;
                    $scope.errorMessage = parseResponse.Message;
                    $scope.dataLoading = false;
                    $rootScope.hideMenus = false;
                }

            });
        };
    });