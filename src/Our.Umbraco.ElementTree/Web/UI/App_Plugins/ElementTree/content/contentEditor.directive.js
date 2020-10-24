(function () {

    'use strict';

    angular.module('umbraco.directives')
        .directive('contentEditor',
            function () {
                return {
                    restrict: 'E',
                    replace: true,
                    templateUrl: 'views/components/content/edit.html',
                    controller: 'Our.Umbraco.ElementTree.ContentEditController',
                    scope: {
                        contentId: "=",
                        isNew: "=?",
                        treeAlias: "@",
                        page: "=?",
                        saveMethod: "&",
                        getMethod: "&",
                        getScaffoldMethod: "&?",
                        culture: "=?",
                        segment: "=?",
                        infiniteModel: "=?"
                    }
                };
            });

}());