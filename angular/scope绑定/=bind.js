var myApp = angular.module("myApp", []);

myApp.controller("MyCtrl",['$scope',function($scope){
	$scope.ctrlFlavor = "百威";
}]);

myApp.directive("drink",function(){
	return{
		restrict: "AE",
		scope : {
			flavors:"="
		},
		replace: true,
		template: '<input type="text" ng-model="flavors" contenteditable ="true">',
		link:function(scope,element,attr){
			scope.flavors ="百威百威";
		}

	}
});