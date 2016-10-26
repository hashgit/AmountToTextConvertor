app.controller("DashboardCtrl", ["$scope", "ApiService", function($scope, ApiService) {
    $scope.ResultName = null;
    $scope.ResultAmount = null;
    $scope.ErrorMessage = "";

    $scope.Views = {
        Display: "Display.html",
        Error: "Error.html",
        Blank: "Blank.html"
    };

    $scope.CurrentView = $scope.Views.Blank;

    $scope.ConvertHandler = function() {
        ApiService.Convert($scope.Amount, $scope.Name, function(response) {
            $scope.ResultAmount = response.data.Text;
            $scope.ResultName = response.data.Name;
            $scope.CurrentView = $scope.Views.Display;
        }, function(response) {
            $scope.ErrorMessage = "Conversion failed.";
            $scope.CurrentView = $scope.Views.Error;
        });
    };
}]);