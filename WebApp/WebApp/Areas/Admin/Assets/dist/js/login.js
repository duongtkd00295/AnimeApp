var loginApp = angular.module('loginApp', []);
loginApp.controller('loginController',
    function ($scope, loginService) {
        $scope.loginForm = function () {
            if (loginService.login($scope.username, $scope.password)) {
                console.log(12312);
            }
        };
    });

loginApp.factory('loginService', function ($http) {
    var isAuthenticated = false;
    return {
        login: function (username, password) {
            $http({
                url: '/admin/user/checkLogin',
                method: 'POST',
                data: { Username: username, Password: password }
            }).then(function (response) {
                isAuthenticated = response;

            }
            );
            return isAuthenticated;
        }
    };
});