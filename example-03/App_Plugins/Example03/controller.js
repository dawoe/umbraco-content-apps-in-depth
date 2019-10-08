(function() {
  "use strict";

  function ExampleThreeController($scope) {
    var vm = this;

    vm.content = $scope.content;
  }

  angular
    .module("umbraco")
    .controller("ExampleThreeController", ["$scope", ExampleThreeController]);
})();
