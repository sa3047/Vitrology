'use strict';

/**
 * @ngdoc overview
 * @name vitrologyApp
 * @description
 * # vitrologyApp
 *
 * Contact controller.
 */
angular.module('vitrologyApp')
  .controller('UserdetailsCtrl', function ($scope, $rootScope, UserService) {

      $scope.info = 'Address Information.';
      $scope.id = $rootScope.globals.currentUser.id;
      $scope.message = '';
      $rootScope.hideMenus = true;

      $scope.saveAddress = function (address) {

          console.log('In save address function');

          var address = {
              street: address.street,
              state: address.state,
              pincode: address.pincode,
              country: address.country,
              userid: $rootScope.globals.currentUser.id
          };

          UserService.saveAddress(address, function (response) {
              var parseResponse = JSON.parse(response);
              console.log('Addressed save ' + parseResponse);

              if (parseResponse) {
                  console.log('user id: ' + parseResponse);
                  $scope.message = 'Address saved';
              }

          });
      }

      UserService.getAddress($scope.id, function (response) {
          var parseResponse = JSON.parse(response);
          console.log('Got address : ' + parseResponse);

          if (parseResponse) {
              $scope.address = {
                  street: parseResponse.Street,
                  state: parseResponse.State,
                  pincode: parseResponse.PinCode,
                  country: parseResponse.Country
              }

          }
      });

  });