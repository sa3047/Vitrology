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
                    // After registration log in and fill global details for user
                    AuthenticationService.Login(user.email, user.password, function (response) {
                        var parseResponse = JSON.parse(response);
                        console.log('Authenticate user after registration: ' + parseResponse);
                        if (parseResponse) {
                            console.log('user id: ' + parseResponse.Id);
                            AuthenticationService.SetCredentials($scope.email, $scope.password, parseResponse.Id);
                            // TODO : Hide menu
                            $rootScope.hideMenus = true;
                            // Go to main page
                            $location.path('/');
                        }
                    });
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