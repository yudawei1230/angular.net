var GfData =	[
    				{
    				    name: 'MM01',
    				    planYield: 20,
    				    lRealYield: 22.4,
    				    lLS: 10.65,
    				    lBXF: 13.33,
    				    lLP: 2.06,
    				    lDC: 2.00,
    				    lYJ: 3.29,
    				    lBeizhu: '保险粉用量+3°~+4°',
    				    bRealYield: 0,
    				    bLS: 0,
    				    bBXF: 0,
    				    bLP: 0,
    				    bDC: 0,
    				    bYJ: 0,
    				    bBeizhu: '',
    				    zRealYield: 0,
    				    zLS: 0,
    				    zBXF: 0,
    				    zLP: 0,
    				    zDC: 0,
    				    zYJ: 0,
    				    zBeizhu: ''
    				},
				{
				    name: 'MM02',
				    planYield: 110,
				    lRealYield: 0,
				    lLS: 0,
				    lBXF: 0,
				    lLP: 0,
				    lDC: 0,
				    lYJ: 0,
				    lBeizhu: '',
				    bRealYield: 46,
				    bLS: 10.96,
				    bBXF: 13.62,
				    bLP: 2.04,
				    bDC: 1.96,
				    bYJ: 3.23,
				    bBeizhu: '保险粉用量+3°~+4°',
				    zRealYield: 68,
				    zLS: 11.27,
				    zBXF: 14.02,
				    zLP: 2.07,
				    zDC: 2.00,
				    zYJ: 3.29,
				    zBeizhu: '保险粉用量+3°~+4°'
				},
				{
				    name: 'M04',
				    planYield: 20,
				    lRealYield: 19,
				    lLS: 10.65,
				    lBXF: 13.33,
				    lLP: 2.06,
				    lDC: 2.00,
				    lYJ: 3.29,
				    lBeizhu: '保险粉用量+3°~+4°',
				    bRealYield: 0,
				    bLS: 0,
				    bBXF: 0,
				    bLP: 0,
				    bDC: 0,
				    bYJ: 0,
				    bBeizhu: '',
				    zRealYield: 0,
				    zLS: 0,
				    zBXF: 0,
				    zLP: 0,
				    zDC: 0,
				    zYJ: 0,
				    zBeizhu: ''
				}
			];
var CtData = [
    {
        Name: '瓷土一',
        planYield: 400,
        lRealYield: 56,
        lLS: 5.67,
        lBXF: 6.73,
        lLP: 0,
        lDC: 0,
        lYJ: 0,
        lBeizhu: '保险粉用量+3°~+4°',
        bRealYield: 125,
        bLS: 3.54,
        bBXF: 8.19,
        bLP: 0,
        bDC: 0,
        bYJ: 0,
        bBeizhu: '保险粉用量+3°~+4°',
        zRealYield: 169,
        zLS: 3.95,
        zBXF: 9.14,
        zLP: 0,
        zDC: 0,
        zYJ: 0,
        zBeizhu: '保险粉用量+3°~+4°'
    },
        {
            Name: '瓷土三',
            planYield: 400,
            lRealYield: 56,
            lLS: 5.67,
            lBXF: 6.73,
            lLP: 0,
            lDC: 0,
            lYJ: 0,
            lBeizhu: '',
            bRealYield: 125,
            bLS: 3.54,
            bBXF: 8.19,
            bLP: 0,
            bDC: 0,
            bYJ: 0,
            bBeizhu: '',
            zRealYield: 169,
            zLS: 3.95,
            zBXF: 9.14,
            zLP: 0,
            zDC: 0,
            zYJ: 0,
            zBeizhu: ''
        }

];
var WptData = [
    {
            Name: '无漂土',
            planYield: 0,
            lRealYield: 1,
            lLS: 0,
            lBXF: 0,
            lLP: 0,
            lDC: 0,
            lYJ: 0,
            lBeizhu: '',
            bRealYield: 0,
            bLS: 0,
            bBXF: 0,
            bLP: 0,
            bDC: 0,
            bYJ: 0,
            bBeizhu: '',
            zRealYield: 0,
            zLS: 0 ,
            zBXF: 0,
            zLP: 0,
            zDC: 0,
            zYJ: 0,
            zBeizhu: '',
    }
];
var GftData = [];
var app = 'myapp';
var ctrl = 'Chart';


function GfproductRepeat(app, ctrl, CtData, GfData, WptData, GftData) {
    angular.module(app, []).controller(ctrl, function ($scope) {
        //干粉一数据初始化
        $scope.GfProductOutput = 0;
        $scope.GfSum = 0;
        $scope.GfLsCost = 0;
        $scope.GfBxfCost = 0;
        $scope.GfLpCost = 0;
        $scope.GfDcCost = 0;
        $scope.GfYjCost = 0;
        //干粉三数据初始化
        $scope.GftProductOutput = 0;
        $scope.GftSum = 0;
        $scope.GftLsCost = 0;
        $scope.GftBxfCost = 0;
        $scope.GftLpCost = 0;
        $scope.GftDcCost = 0;
        $scope.GftYjCost = 0;
        //瓷土数据初始化
        $scope.CtProductOutput = 0;
        $scope.CtSum = 0;
        $scope.CtLsCost = 0;
        $scope.CtBxfCost = 0;
        $scope.CtLpCost = 0;
        $scope.CtDcCost = 0;
        $scope.CtYjCost = 0;
        //无漂土数据初始化
        $scope.WptProductOutput = 0;
        $scope.WptSum = 0;
        $scope.WptLsCost = 0;
        $scope.WptBxfCost = 0;
        $scope.WptLpCost = 0;
        $scope.WptDcCost = 0;
        $scope.WptYjCost = 0;
        // 干粉数据计算
       	for (x in GfData)
    	{  
	            $scope.GfProductOutput += GfData[x].lRealYield + GfData[x].bRealYield + GfData[x].zRealYield;
	            $scope.GfSum += GfData[x].planYield;
	            $scope.GfLsCost += GfData[x].lLS * GfData[x].lRealYield + GfData[x].bLS * GfData[x].bRealYield + GfData[x].zLS * GfData[x].zRealYield;
	            $scope.GfBxfCost += GfData[x].lBXF * GfData[x].lRealYield + GfData[x].bBXF * GfData[x].bRealYield + GfData[x].zBXF * GfData[x].zRealYield;
	            $scope.GfLpCost += GfData[x].lLP * GfData[x].lRealYield + GfData[x].bLP * GfData[x].bRealYield + GfData[x].zLP * GfData[x].zRealYield;
	            $scope.GfDcCost += GfData[x].lDC * GfData[x].lRealYield + GfData[x].bDC * GfData[x].bRealYield + GfData[x].zDC * GfData[x].zRealYield;
	            $scope.GfYjCost += GfData[x].lYJ * GfData[x].lRealYield + GfData[x].bYJ * GfData[x].bRealYield + GfData[x].zYJ * GfData[x].zRealYield;
    	}
		$scope.GfLsCost /= $scope.GfProductOutput;
		$scope.GfBxfCost /= $scope.GfProductOutput;
		$scope.GfLpCost /= $scope.GfProductOutput;
		$scope.GfDcCost /= $scope.GfProductOutput;
		$scope.GfYjCost /= $scope.GfProductOutput;
        //干粉三数据计算
		for (x in GftData) {
		    $scope.GftProductOutput += GftData[x].lRealYield + GftData[x].bRealYield + GftData[x].zRealYield;
		    $scope.GftSum += GftData[x].planYield;
		    $scope.GftLsCost += GftData[x].lLS * GftData[x].lRealYield + GftData[x].bLS * GftData[x].bRealYield + GftData[x].zLS * GftData[x].zRealYield;
		    $scope.GftBxfCost += GftData[x].lBXF * GftData[x].lRealYield + GftData[x].bBXF * GftData[x].bRealYield + GftData[x].zBXF * GftData[x].zRealYield;
		    $scope.GftLpCost += GftData[x].lLP * GftData[x].lRealYield + GftData[x].bLP * GftData[x].bRealYield + GftData[x].zLP * GftData[x].zRealYield;
		    $scope.GftDcCost += GftData[x].lDC * GftData[x].lRealYield + GftData[x].bDC * GftData[x].bRealYield + GftData[x].zDC * GftData[x].zRealYield;
		    $scope.GftYjCost += GftData[x].lYJ * GftData[x].lRealYield + GftData[x].bYJ * GftData[x].bRealYield + GftData[x].zYJ * GftData[x].zRealYield;
		}
		$scope.GftLsCost /= $scope.GftProductOutput;
		$scope.GftBxfCost /= $scope.GftProductOutput;
		$scope.GftLpCost /= $scope.GftProductOutput;
		$scope.GftDcCost /= $scope.GftProductOutput;
		$scope.GftYjCost /= $scope.GftProductOutput;
        // 瓷土数据计算
     	for(x in CtData)
    	{
    		$scope.CtSum += CtData[x].planYield;
    		$scope.CtProductOutput += CtData[x].lRealYield+CtData[x].bRealYield+CtData[x].zRealYield;
    		$scope.CtLsCost += CtData[x].lLS * CtData[x].lRealYield + CtData[x].bLS * CtData[x].bRealYield + CtData[x].zLS * CtData[x].zRealYield;
    	    $scope.CtBxfCost += CtData[x].lBXF * CtData[x].lRealYield + CtData[x].bBXF * CtData[x].bRealYield + CtData[x].zBXF * CtData[x].zRealYield;
    	    $scope.CtLpCost += CtData[x].lLP * CtData[x].lRealYield + CtData[x].bLP * CtData[x].bRealYield + CtData[x].zLP * CtData[x].zRealYield;
    	    $scope.CtDcCost += CtData[x].lDC * CtData[x].lRealYield + CtData[x].bDC * CtData[x].bRealYield + CtData[x].zDC * CtData[x].zRealYield;
    	    $scope.CtYjCost += CtData[x].lYJ * CtData[x].lRealYield + CtData[x].bYJ * CtData[x].bRealYield + CtData[x].zYJ * CtData[x].zRealYield;
           	 }
    		$scope.CtLsCost /= $scope.CtProductOutput;
    		$scope.CtBxfCost /= $scope.CtProductOutput;
    		$scope.CtLpCost /= $scope.CtProductOutput;
    		$scope.CtDcCost /= $scope.CtProductOutput;
    		$scope.CtYjCost /= $scope.CtProductOutput;
        //无漂土数据计算
        for(x in WptData)
        {
            $scope.WptSum += WptData[x].planYield;
            $scope.WptProductOutput += WptData[x].lRealYield+WptData[x].bRealYield+WptData[x].zRealYield;
            $scope.WptLsCost += WptData[x].lLS * WptData[x].lRealYield + WptData[x].bLS * WptData[x].bRealYield + WptData[x].zLS * WptData[x].zRealYield;
            $scope.WptBxfCost += WptData[x].lBXF * WptData[x].lRealYield + WptData[x].bBXF * WptData[x].bRealYield + WptData[x].zBXF * WptData[x].zRealYield;
            $scope.WptLpCost += WptData[x].lLP * WptData[x].lRealYield + WptData[x].bLP * WptData[x].bRealYield + WptData[x].zLP * WptData[x].zRealYield;
            $scope.WptDcCost += WptData[x].lDC * WptData[x].lRealYield + WptData[x].bDC * WptData[x].bRealYield + WptData[x].zDC * WptData[x].zRealYield;
            $scope.WptYjCost += WptData[x].lYJ * WptData[x].lRealYield + WptData[x].bYJ * WptData[x].bRealYield + WptData[x].zYJ * WptData[x].zRealYield;
        }
            $scope.WptLsCost /= $scope.WptProductOutput;
            $scope.WptBxfCost /= $scope.WptProductOutput;
            $scope.WptLpCost /= $scope.WptProductOutput;
            $scope.WptDcCost /= $scope.WptProductOutput;
            $scope.WptYjCost /= $scope.WptProductOutput;
            $scope.GfSumBeizhu = '——';
            $scope.CtSumBeizhu = '——';
            $scope.WptSumBeizhu = '——';
            $scope.GftSumBeizhu = '——';
        // 干粉总数据计算
            if ((GftData.length > 1) && (GfData.length > 1)) {
                $scope.GFSum = $scope.GfSum + $scope.GftSum;
                $scope.GFProductOutput = $scope.GfProductOutput + $scope.GftProductOutput;
                $scope.GFLsCost = ($scope.GfLsCost * $scope.GfProductOutput + $scope.GftLsCost * $scope.GftProductOutput) / ($scope.GfProductOutput + $scope.GftProductOutput);
                $scope.GFBxfCost = ($scope.GfBxfCost * $scope.GfProductOutput + $scope.GftBxfCost * $scope.GftProductOutput) / ($scope.GfProductOutput + $scope.GftProductOutput);
                $scope.GFLpCost = ($scope.GfLpCost * $scope.GfProductOutput + $scope.GftLpCost * $scope.GftProductOutput) / ($scope.GfProductOutput + $scope.GftProductOutput);
                $scope.GFDcCost = ($scope.GfDcCost * $scope.GfProductOutput + $scope.GftDcCost * $scope.GftProductOutput) / ($scope.GfProductOutput + $scope.GftProductOutput);
                $scope.GFYjCost = ($scope.GfYjCost * $scope.GfProductOutput + $scope.GftYjCost * $scope.GftProductOutput) / ($scope.GfProductOutput + $scope.GftProductOutput);
            }
            else if (GfData.length > 1) {
                $scope.GFSum = $scope.GfSum;
                $scope.GFProductOutput = $scope.GfProductOutput;
                $scope.GFLsCost = $scope.GfLsCost;
                $scope.GFBxfCost = $scope.GfBxfCost;
                $scope.GFLpCost = $scope.GfLpCost;
                $scope.GFDcCost = $scope.GfDcCost;
                $scope.GFYjCost = $scope.GfYjCost;
            }
            else {
                $scope.GFSum = $scope.GftSum;
                $scope.GFProductOutput = $scope.GftProductOutput;
                $scope.GFLsCost = $scope.GftLsCost;
                $scope.GFBxfCost = $scope.GftBxfCost;
                $scope.GFLpCost = $scope.GftLpCost;
                $scope.GFDcCost = $scope.GftDcCost;
                $scope.GFYjCost = $scope.GftYjCost;
            }
        //干粉数据导入
            $scope.GfProduction = GfData;
        //干粉三数据导入
            $scope.GftProduction = GftData;
        // 瓷土数据导入
            $scope.Ctproduction = CtData;
        // 无漂土数据导入
            $scope.Wptproduction = WptData;
    	});
}

GfproductRepeat(app, ctrl, CtData, GfData, WptData, GftData);




	
