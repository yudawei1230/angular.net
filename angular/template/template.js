var module = angular.module("MyModule",['ngRoute']);

module.directive("hello",function(){
	return{
		restrict: 'AECM',
		template: '<div>hi everyone!</div>',
		replace: true
	}
});
module.directive("shit", function(){
	return{
		restrict : 'AECM',
		templateUrl : '../template/shit.html',
		replace : true
	}
});