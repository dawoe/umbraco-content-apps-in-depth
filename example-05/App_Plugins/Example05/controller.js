(function() {
  "use strict";

  function ExampleFiveController($scope) {
    var vm = this;

    vm.variant = _.find($scope.content.variants, function(v) {
      return v.active;
    });
  }

  angular
    .module("umbraco")
    .controller("ExampleFiveController", ["$scope", ExampleFiveController]);
})();
