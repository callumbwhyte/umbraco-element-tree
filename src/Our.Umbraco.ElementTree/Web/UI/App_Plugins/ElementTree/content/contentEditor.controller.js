(function () {

    'use strict';

    angular.module('umbraco')
        .controller('Our.Umbraco.ElementTree.ContentEditController',
            function ($scope, $controller) {

                var vm = this;

                angular.extend(vm, $controller('Umbraco.Editors.Content.EditorDirectiveController', { $scope: $scope }));

            });

}());