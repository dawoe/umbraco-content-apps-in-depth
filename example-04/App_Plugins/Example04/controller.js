(function() {
  "use strict";

  function ExampleFourController($scope) {
    var vm = this;

    vm.data = $scope.model.viewModel;
  }

  angular
    .module("umbraco")
    .controller("ExampleFourController", ["$scope", ExampleFourController]);
})();
