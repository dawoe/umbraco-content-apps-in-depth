(function() {
  "use strict";

  function ExampleSevenController($scope) {
    var vm = this;

    vm.content = $scope.content;

    $scope.model.badge = {
      count: 5,
      type: "warning"
    };
  }

  angular
    .module("umbraco")
    .controller("ExampleSevenController", ["$scope", ExampleSevenController]);
})();
