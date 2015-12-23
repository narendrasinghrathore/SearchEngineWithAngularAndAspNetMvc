var serviceApp = angular.module('serviceApp').
factory('getData', ['$resource', 'appSettings'], getData);

var getData = function ($resource, appSettings) {
    return $resource(appSettings.serverPath + '/api/Search/:id');
}