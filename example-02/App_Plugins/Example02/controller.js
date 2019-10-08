(function() {
  "use strict";

  function ExampleTwoController($scope) {
    var vm = this;

    vm.content = $scope.content;
  }

  angular
    .module("umbraco")
    .controller("ExampleTwoController", ["$scope", ExampleTwoController]);
})();
