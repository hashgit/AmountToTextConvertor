app.controller("DashboardCtrl", ["$scope", "ApiService", function($scope, ApiService) {
    $scope.ResultName = null;
    $scope.ResultAmount = null;
    $scope.ErrorMessage = "";

    $scope.ConvertHandler = function() {
        ApiService.Convert($scope.Amount, $scope.Name, function(response) {
            $scope.ResultAmount = response.data.Text;
            $scope.ResultName = response.data.Name;

            $scope.ErrorMessage = "";
        }, function(response) {
            $scope.ErrorMessage = "Conversion failed.";
        });
    };
}]);