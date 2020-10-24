(function () {

    'use strict';

    angular.module('umbraco.services')
        .config(function ($httpProvider) {
            $httpProvider.interceptors.push(
                ['$q', 'eventsService', '$routeParams', function ($q, eventsService, $routeParams) {
                    return {
                        'request': function (request) {
                            var path = '/App_Plugins/ElementTree/backoffice/' + $routeParams.tree + '/';

                            if (request.url.includes(path)) {
                                request.url = request.url.replace(path, '/umbraco/views/content/');
                            }

                            return request || $q.when(request);
                        }
                    };
                }]
            );
        });

}());