(function() {
  "use strict";

  function ExampleOneController($scope) {
    var vm = this;

    vm.content = $scope.content;
  }

  angular
    .module("umbraco")
    .controller("ExampleOneController", ["$scope", ExampleOneController]);
})();
