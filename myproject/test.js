console.log(1);
var myModule = angular.module("Mymodule",[]);
myModule.directive("superman", function(){

    return {
        scope: {},
        restrict: 'AE',
        controller: function($scope){
            $scope.name = [];
            this.addyu = function(){
                $scope.name.push('yu');
            };
            this.addda = function(){
                $scope.name.push('da');
            };
            this.addwei = function(){
                $scope.name.push('wei');
            };
        },
        link: function(scope, element, attrs){
            element.addClass('btn btn-primary');
            element.bind("mouseenter",function(){
                console.log(scope.name);
            });
        }
    }
});

myModule.directive("yu",function(){
    return {
        require: '^superman',
        link: function(scope,element,attrs,surpermanCtrl){
            surpermanCtrl.addyu();
        }
    }
});

myModule.directive("da",function(){
    return {
        require: '^superman',
        link: function(scope,element,attrs,surpermanCtrl){
            surpermanCtrl.addda();
        }
    }
});

myModule.directive("wei",function(){
    return {
        require: '^superman',
        link: function(scope,element,attrs,surpermanCtrl){
            surpermanCtrl.addwei();
        }
    }
});