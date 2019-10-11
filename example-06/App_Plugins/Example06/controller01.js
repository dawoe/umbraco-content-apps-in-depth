(function() {
  "use strict";

  function ExampleSix1Controller($scope, $timeout) {
    var vm = this;

    $timeout(function() {
      vm.variant = _.find($scope.content.variants, function(v) {
        return v.active;
      });
      vm.variant.apps = _.shuffle(vm.variant.apps);
      $scope.model.view = "/App_Plugins/Example06/view.html";
    }, 1000);
  }

  angular
    .module("umbraco")
    .controller("ExampleSix1Controller", [
      "$scope",
      "$timeout",
      ExampleSix1Controller
    ]);
})();
