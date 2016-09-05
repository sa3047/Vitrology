'use strict';

/**
 * @ngdoc function
 * @name vitrologyApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the vitrologyApp
 * Create user service which will give us registered users
 */
angular.module('vitrologyApp')
  .controller('MainCtrl', function ($scope, $rootScope,$location, UserService) {
      $scope.header = 'Registered users.';
      $rootScope.hideMenus = true;

      UserService.getAllUser(function(response){
          var parseResponse = JSON.parse(response);
          console.log('Users ' + parseResponse);

          if (parseResponse) {
              $scope.users = parseResponse;
          }
          
      });

      $scope.deleteUser = function (Id) {
          console.log('Delete customer Id ' + Id);
          UserService.deleteUser(Id, function (response) {
              var parseResponse = JSON.parse(response);
              console.log('Deleted user ' + parseResponse);

              if (parseResponse) {
                  console.log('Refreshing main page');

                  UserService.getAllUser(function (result) {
                      var parseUsers = JSON.parse(result);
                      console.log('Users ' + parseUsers);

                      if (parseUsers) {
                          $scope.users = parseUsers;
                      }

                  });
              }

          });

      };

  });
