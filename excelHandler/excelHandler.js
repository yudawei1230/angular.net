var app=angular.module("hh",[]);
app.controller("mymodule",function($scope,loadExcel){
	$scope.title="小贷数据上报系统";
	$scope.times= 4;
	$scope.keyCode = "I00000";
	$scope.organizationCode = "j020";
	$scope.areaCode = "4401041";
	$scope.ExcelChart = true;
	$scope.fileAction = true;
	$scope.date = (new Date().getFullYear())+"-"+(new Date().getMonth()+1);
	$scope.loadData = function(){
		$scope.codeInput = true;
		$scope.ChartData = loadExcel.GetExcelData();
		$scope.ExcelChart = false;
		$scope.fileAction = false;
	} ;
	$scope.createFile = function(){
		var ChartDate = $scope.date.split("-");
		//$scope.codeInput = false;
		$scope.fileAction = true;
		$scope.ExcelChart = true;
		loadExcel.readExcel($scope.keyCode,$scope.organizationCode,$scope.areaCode,ChartDate[0]+ChartDate[1],$scope.times);
	}
});