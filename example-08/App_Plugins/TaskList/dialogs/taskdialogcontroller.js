(function () {
    "use strict";

    function TaskDialogController(
        $scope,
        editorService
    ) {
        var vm = this;
        vm.title = "Create task";
        vm.task = $scope.model.task;
        vm.user = {};

        vm.selectUser = function () {
            var userPicker = {
                submit: function (model) {
                    vm.user = model.selection[0];
                    vm.task.assignedTo = vm.user.id;
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.userPicker(userPicker);
        };

        vm.close = function () {
            $scope.model.close();
        };

        vm.submit = function () {
            $scope.model.submit($scope.model);
        };

        function init() {
            
        }

        init();
    }

    angular
        .module("umbraco")
        .controller("TaskDialogController", [
            "$scope",
            "editorService",
            TaskDialogController
        ]);
})();
