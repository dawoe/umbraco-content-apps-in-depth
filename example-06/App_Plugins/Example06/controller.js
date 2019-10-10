(function() {
  "use strict";

  function ExampleSixController($scope, $timeout) {
    var vm = this;

    $timeout(function() {
      $scope.model.view = "/App_Plugins/Example06/view01.html";
    }, 1000);
  }

  angular
    .module("umbraco")
    .controller("ExampleSixController", [
      "$scope",
      "$timeout",
      ExampleSixController
    ]);
})();
