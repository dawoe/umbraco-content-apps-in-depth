(function () {
    "use strict";

    function TaskListAppController(
        $scope,
        $http,
        umbRequestHelper,
        notificationsService,
        editorService,
        authResource
    ) {
        var apiUrl = Umbraco.Sys.ServerVariables.TaskList.TaskListApi;

        var vm = this;

        vm.tasks = [];
       

        function openDialog(task, isNew, onSubmit) {
           
            var taskDialog = {
                title: "Create task",
                task: angular.copy(task),
                view:
                    "/App_Plugins/TaskList/dialogs/taskdialog.html",
                size: "small",
                submit: function (model) {
                    onSubmit(model.task);
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.open(taskDialog);
        }

        vm.addTask = function () {
            var task = {
                id: "",
                title: "",
                description: "",
                createDate: null,
                createdby: 0,
                assignedto: 0,
                contentId : $scope.content.id

            };

            openDialog(task, true, function (newTask) {
                var data = JSON.stringify(newTask);

                 umbRequestHelper.resourcePromise(
                    $http.post(apiUrl + "CreateTask", data),
                    "Failed to create task"
                 ).then(function(response) {
                     vm.tasks.push(response);
                     notificationsService.success("Task created");
                 });

                
            });
        };

       

        function init() {
            vm.tasks = $scope.model.viewModel;

            authResource.getCurrentUser()
                .then(function (data) {
                    var userId = data.id;

                    var assignedTasks = _.filter(vm.tasks,
                        function(t) {
                            return t.assignedTo === userId;
                        });

                    if (assignedTasks.length > 0) {
                        $scope.model.badge = {
                            count: assignedTasks.length,
                            type: 'alert'
                        };
                    }
                });
        }

        init();
    }

    angular
        .module("umbraco")
        .controller("TaskListAppController", [
            "$scope",
            "$http",
            "umbRequestHelper",
            "notificationsService",
            "editorService",
            "authResource",
            TaskListAppController
        ]);
})();
