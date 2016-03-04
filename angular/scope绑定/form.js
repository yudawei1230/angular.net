var myApp = angular.module("myApp", []);

myApp.controller("MyCtrl",['$scope',function($scope){
	$scope.user={
		userName:"yudawei",
		password:"YDW52025"
	}
	$scope.save = function(data){
		console.log(data);
	}
}]);
