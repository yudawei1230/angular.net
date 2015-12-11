var GfData =	[
				{
					name : 'MM01' ,
					planYield : 20 ,
					lRealYield :22.4 ,
					lLS : 10.65 ,
					lBXF : 13.33,
					lLP : 2.06 ,
					lDC : 2.00 ,
					lYJ : 3.29 ,
					bRealYield : 0 ,
					bLS : 0 ,
					bBXF : 0 ,
					bLP : 0 ,
					bDC : 0 ,
					bYJ : 0 ,
					zRealYield : 0 ,
					zLS : 0 ,
					zBXF : 0 ,
					zLP : 0 ,
					zDC : 0 ,
					zYJ : 0 
				},
				{
					name : 'MM02' ,
					planYield : 110 ,
					lRealYield :0 ,
					lLS : 0 ,
					lBXF : 0,
					lLP : 0 ,
					lDC : 0 ,
					lYJ : 0 ,
					bRealYield : 46 ,
					bLS :10.96 ,
					bBXF : 13.62 ,
					bLP : 2.04 ,
					bDC :1.96 ,
					bYJ : 3.23 ,
					zRealYield : 68 ,
					zLS : 11.27 ,
					zBXF : 14.02 ,
					zLP : 2.07 ,
					zDC : 2.00 ,
					zYJ : 3.29 
				},
				{
					name : 'MM03' ,
					planYield : 20 ,
					lRealYield :19 ,
					lLS : 10.65 ,
					lBXF : 13.33,
					lLP : 2.06 ,
					lDC : 2.00 ,
					lYJ : 3.29 ,
					bRealYield : 0 ,
					bLS : 0 ,
					bBXF : 0 ,
					bLP : 0 ,
					bDC : 0 ,
					bYJ : 0 ,
					zRealYield : 0 ,
					zLS : 0 ,
					zBXF : 0 ,
					zLP : 0 ,
					zDC : 0 ,
					zYJ : 0 
				}
			];
var CtData = [
    {
        Name: '瓷土一',
        planYield: 400,
        lRealYield: 56,
        lLS: 5.67,
        lBXF: 6.73,
        lBZ: '-2°~0°',
        lLP: 0,
        lDC: 0,
        lYJ: 0,
        bRealYield: 125,
        bLS: 3.54,
        bBXF: 8.19,
        bBZ: '+2°~+8°',
        bLP: 0,
        bDC: 0,
        bYJ: 0,
        zRealYield: 169,
        zLS: 3.95,
        zBXF: 9.14,
        zBZ: '0°~+2°',
        zLP: 0,
        zDC: 0,
        zYJ: 0
    },
        {
            Name: '瓷土三',
            planYield: 400,
            lRealYield: 56,
            lLS: 5.67,
            lBXF: 6.73,
            lBZ: '-2°~0°',
            lLP: 0,
            lDC: 0,
            lYJ: 0,
            bRealYield: 125,
            bLS: 3.54,
            bBXF: 8.19,
            bBZ: '+2°~+8°',
            bLP: 0,
            bDC: 0,
            bYJ: 0,
            zRealYield: 169,
            zLS: 3.95,
            zBXF: 9.14,
            zBZ: '0°~+2°',
            zLP: 0,
            zDC: 0,
            zYJ: 0
        }

];
var app = 'myapp';
var ctrl = 'Chart';


function GfproductRepeat(app, ctrl,CtDate, GfData) {
    angular.module(app, []).controller(ctrl, function ($scope) {
        //载入干粉数据
	    $scope.GfProduction = GfData;
        // 载入瓷土数据
	    $scope.Ctproduction = CtDate;
        // 干粉数据初始化
	    $scope.ProductOutput = 0;
        $scope.GfSum = 0;
        $scope.GfLsCost = 0;
        $scope.GfBxfCost = 0;
        $scope.GfLpCost = 0;
        $scope.GfDcCost = 0;
        $scope.GfYjCost = 0;
        // 干粉数据计算
        for (x in GfData)
	    {  
            $scope.ProductOutput += GfData[x].lRealYield + GfData[x].bRealYield + GfData[x].zRealYield;
            $scope.GfSum += GfData[x].planYield;
            $scope.GfLsCost += GfData[x].lLS * GfData[x].lRealYield + GfData[x].bLS * GfData[x].bRealYield + GfData[x].zLS * GfData[x].zRealYield;
            $scope.GfBxfCost += GfData[x].lBXF * GfData[x].lRealYield + GfData[x].bBXF * GfData[x].bRealYield + GfData[x].zBXF * GfData[x].zRealYield;
            $scope.GfLpCost += GfData[x].lLP * GfData[x].lRealYield + GfData[x].bLP * GfData[x].bRealYield + GfData[x].zLP * GfData[x].zRealYield;
            $scope.GfDcCost += GfData[x].lDC * GfData[x].lRealYield + GfData[x].bDC * GfData[x].bRealYield + GfData[x].zDC * GfData[x].zRealYield;
            $scope.GfYjCost += GfData[x].lYJ * GfData[x].lRealYield + GfData[x].bYJ * GfData[x].bRealYield + GfData[x].zYJ * GfData[x].zRealYield;
	    }
	    $scope.GfLsCost /= $scope.ProductOutput;
	    $scope.GfBxfCost /= $scope.ProductOutput;
	    $scope.GfLpCost /= $scope.ProductOutput;
	    $scope.GfDcCost /= $scope.ProductOutput;
	    $scope.GfYjCost /= $scope.ProductOutput;
	  
	});
}
function CtproductRepeat(app,ctrl,data){
    angular.module(app,[]).controller(ctrl,function($scope){
        $scope.CtProduction = data;
    });
}
GfproductRepeat(app,ctrl,CtData,GfData);




	
