'use strict';

var app = angular.module('vitrologyApp');

app.factory('UserService', function ($http, $rootScope) {
    var urlBase = 'http://localhost:54522/';

    // Register a user
    var register = function (user, callback) {
        $http.post(urlBase + 'api/User/RegisterUser', user)
            .success(function (response) {
                callback(response);
            });
    };

    //Get all users
    var getAllUser = function (callback) {
        $http.get(urlBase + 'api/User/GetAllUser')
            .success(function (response) {
                callback(response);
            });
    };

    //Delete a User
    var deleteUser = function (id, callback) {
        $http.delete(urlBase + 'api/User/DeleteUser/' + id)
           .success(function (response) {
               callback(response);
           });
    };

    //Save address
    var saveAddress = function (address, callback) {
        $http.post(urlBase + 'api/User/AddAddress', address)
            .success(function (response) {
                callback(response);
            });
    };

    //Get a address
    var getAddress = function (id, callback) {
        $http.get(urlBase + 'api/User/GetAddress/'+id)
            .success(function (response) {
                callback(response);
            });
    };

    return {
        register: register,
        getAllUser: getAllUser,
        deleteUser: deleteUser,
        saveAddress: saveAddress,
        getAddress: getAddress
    };
});