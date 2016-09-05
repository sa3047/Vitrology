'use strict';

/**
 * @ngdoc function
 * @name vitrologyApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the vitrologyApp
 */
angular.module('vitrologyApp')
  .controller('AboutCtrl', function ($scope,$rootScope) {
      $scope.info = 'This is about view.';
      $rootScope.hideMenus = true;
  });
