var myApp = angular.module("myApp", []);

myApp.controller("MyCtrl",['$scope',function($scope){
	$scope.ctrlFlavor = "百威";
}]);

myApp.directive("drink",function(){
	return{
		restrict: "AE",
		template: "<div>{{flavors+flavors}}</div>",
		link : function(scope,element,attrs){
			scope.flavors = attrs.flavor;
		}
	}
});