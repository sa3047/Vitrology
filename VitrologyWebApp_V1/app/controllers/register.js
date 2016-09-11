'use strict';

/**
 * @ngdoc overview
 * @name vitrologyApp
 * @description
 * # vitrologyApp
 *
 * Register controller.
 */
angular.module('vitrologyApp')
    .controller('RegisterCtrl', function ($scope, $rootScope, $location, AuthenticationService, UserService) {
        $scope.info = 'Registration Info';
        $scope.errorMessage = '';
        $scope.error = false;

        $scope.registerUser = function (user) {
            var userData = {
                FirstName: user.firstName,
                LastName: user.lastName,
                Email: user.email,
                Password: user.password
            };

            UserService.register(userData, function (response) {
                //console.log('Registration done : ' + response);
                var parseResponse = JSON.parse(response);
                // console.log(parseResponse.Success);
                // console.log(parseResponse.Message);

                if (parseResponse.Success) {
                    console.log(parseResponse.Success);
                    $scope.error = false;
                    // After registration log in and fill global details for user
                    AuthenticationService.Login(user.email, user.password, function (response) {
                        var parseResponse = JSON.parse(response);
                        console.log('Authenticate user after registration: ' + parseResponse);
                        if (parseResponse) {
                            
                            AuthenticationService.SetCredentials($scope.email, $scope.password, parseResponse.Id, parseResponse.FirstName);
                            // TODO : Hide menu
                            $rootScope.hideMenus = true;
                            console.log('User Name: ' + $rootScope.globals.currentUser.username);
                            // Go to main page
                            $location.path('/');
                        }
                    });
                } else {
                    console.log('Register error Message: ' + parseResponse.Message);
                    $scope.error = true;
                    $scope.errorMessage = parseResponse.Message;
                    $rootScope.hideMenus = false;
                }

            });

        };

        //var onUserRegister = function (data) {
        //    //Handle user Registration
        //    console.log('On user registration ' + data);
        //    AuthenticationService.SetCredentials($scope.email, $scope.password);
        //    $location.path('/');
        //};

        //var onError = function (error) {
        //    console.log('On error :' + error);
        //};
    });