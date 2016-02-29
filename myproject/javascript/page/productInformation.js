var GfoneProduct = [
                    {
                        name: 'MM01',
                        thisMonthPlan: 1985,
                        lastMonthReal: 2172.30,
                        realFinished: 1319.50,
                        finishedRate: 0.66,
                        planCost: 520.00,
                        lastMonthRealCost: 416.26,
                        realCost: 403.13,
                        costDefference: 154209.97,
                        costControlRate: -22.48
                    }, {
                        name: 'MM02',
                        thisMonthPlan: 1426,
                        lastMonthReal: 1175.50,
                        realFinished: 968.80,
                        finishedRate: 0.68,
                        planCost: 455.00,
                        lastMonthRealCost: 373.27,
                        realCost: 370.59,
                        costDefference: 81776.41,
                        costControlRate: -18.55
                    }, {
                        name: 'MM03',
                        thisMonthPlan: 0,
                        lastMonthReal: 727.00,
                        realFinished: 56.90,
                        finishedRate: 0,
                        planCost: 447.00,
                        lastMonthRealCost: 363.64,
                        realCost: 367.63,
                        costDefference: 4516.15,
                        costControlRate: -17.76
                    }, {
                        name: 'MM01A',
                        thisMonthPlan: 0,
                        lastMonthReal: 0,
                        realFinished: 0,
                        finishedRate: 0,
                        planCost: 528.00,
                        lastMonthRealCost: 0,
                        realCost: 0,
                        costDefference: 0,
                        costControlRate: 0
                    }, {
                        name: 'M01A',
                        thisMonthPlan: 0,
                        lastMonthReal: 0,
                        realFinished: 0,
                        finishedRate: 0,
                        planCost: 528.00,
                        lastMonthRealCost: 0,
                        realCost: 0,
                        costDefference: 0,
                        costControlRate: 0
                    }, {
                        name: 'M01',
                        thisMonthPlan: 0,
                        lastMonthReal: 0,
                        realFinished: 0,
                        finishedRate: 0,
                        planCost: 520.00,
                        lastMonthRealCost: 0,
                        realCost: 0,
                        costDefference: 0,
                        costControlRate: 0
                    }, {
                        name: 'M02',
                        thisMonthPlan: 0,
                        lastMonthReal: 0,
                        realFinished: 0,
                        finishedRate: 0,
                        planCost: 447.00,
                        lastMonthRealCost: 0,
                        realCost: 0,
                        costDefference: 0,
                        costControlRate: 0
                    }, {
                        name: 'M03',
                        thisMonthPlan: 0,
                        lastMonthReal: 0,
                        realFinished: 0,
                        finishedRate: 0,
                        planCost: 0.00,
                        lastMonthRealCost: 0,
                        realCost: 0,
                        costDefference: 0,
                        costControlRate: 0
                    }, {
                        name: 'M04',
                        thisMonthPlan: 0,
                        lastMonthReal: 79.50,
                        realFinished: 46.50,
                        finishedRate: 0,
                        planCost: 447.00,
                        lastMonthRealCost: 369.82,
                        realCost: 372.73,
                        costDefference: 3453.56,
                        costControlRate: -16.62
                    }, {
                        name: 'M05',
                        thisMonthPlan: 0,
                        lastMonthReal: 0,
                        realFinished: 0,
                        finishedRate: 0,
                        planCost: 0.00,
                        lastMonthRealCost: 0,
                        realCost: 0,
                        costDefference: 0,
                        costControlRate: 0
                    }, {
                        name: 'M08',
                        thisMonthPlan: 0,
                        lastMonthReal: 0,
                        realFinished: 0,
                        finishedRate: 0,
                        planCost: 447.00,
                        lastMonthRealCost: 0,
                        realCost: 0,
                        costDefference: 0,
                        costControlRate: 0
                    }
                ];
var GfthreeProduct = [

                    ];

var app = 'formApp';
var ctrl = 'producingForm';

function showdata(app, ctrl, GfoneProduct) {
    angular.module(app, []).controller(ctrl, function ($scope) {
        //载入数据
        $scope.GfoneProduct = GfoneProduct;
        //干粉一数据初始化
        $scope.GfOneThisMonthPlan = 0;
        $scope.GfOneLastMonthReal = 0;
        $scope.GfOneRealFinished = 0;
        $scope.GfOneFinishedRate = 0;
        $scope.GfOnePlanCost = 0;
        $scope.GfOneLastMonthRealCost = 0;
        $scope.GfOneRealCost = 0;
        $scope.GfOneCostDefference = 0;
        $scope.GfOneCostControlRate = 0;
        //干粉一数据逻辑运算
        for (x in GfoneProduct)
        {
            $scope.GfOneThisMonthPlan += GfoneProduct[x].thisMonthPlan;
            $scope.GfOneLastMonthReal += GfoneProduct[x].lastMonthReal;
            $scope.GfOneRealFinished += GfoneProduct[x].realFinished;
            $scope.GfOneCostDefference += GfoneProduct[x].costDefference;
            
        }
        $scope.GfOneFinishedRate = $scope.GfOneRealFinished*100 / $scope.GfOneThisMonthPlan;

        
});
}

showdata(app,ctrl,GfoneProduct);