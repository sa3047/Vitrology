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

            //console.log(userData);
            //UserService.register(userData).then(onUserRegister, onError);

            UserService.register(userData, function (response) {
                //console.log('Registration done : ' + response);
                var parseResponse = JSON.parse(response);
                // console.log(parseResponse.Success);
                // console.log(parseResponse.Message);

                if (parseResponse.Success) {
                    console.log(parseResponse.Success);
                    AuthenticationService.SetCredentials(userData.email, userData.password);
                    // TODO : Hide menu
                    $rootScope.hideMenus = true;
                    // Go to main page
                    $location.path('/');
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