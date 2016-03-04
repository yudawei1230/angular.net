var myApp = angular.module("myApp", []);

myApp.controller("MyCtrl",['$scope',function($scope){
	$scope.ctrlFlavor = "百威";
}]);

myApp.directive("drink",function(){
	return{
		restrict: "AE",
		scope : {
			flavor:"@"
		},
		replace: true,
		template: "<div contenteditable ='true'>{{flavor+flavor}}</div>"
	}
});

myApp.directive("myDirective",function(){
	return{
		restrict: 'A',
		replace: true,
		scope:{
			myUrl: '@',
			myLinkText: '@'
		},
		template: '<a href="{{myUrl}}">'+'{{myLinkText}}</a>'
	}
});
