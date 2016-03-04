var myApp = angular.module("myApp", []);

myApp.controller("MyCtrl",['$scope',function($scope){
	$scope.sayHello = function(name){
		alert("hello  "+name);
	}
}]);

myApp.directive("greeting",function(){
	return{
		restrict: "AE",
		scope:{
			greet:'&'
		},
		template: '<input type="text" ng-model="username">'+'<button class="btn btn-default" ng-click="greet({name:username})">Greeting</button><br/>', 
	}
});