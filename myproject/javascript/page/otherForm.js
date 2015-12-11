var packageSituation = [
                            {
                                name: 'MM01',
                                todayPackage: 22.4,
                                totalPackage: 1374.3
                            },
                            {
                                name: 'MM02',
                                todayPackage: 114,
                                totalPackage: 1189.5
                            }
                            ,
                            {
                                name: 'MM03',
                                todayPackage: 0,
                                totalPackage: 710.55
                            },
                            {
                                name: 'MM01A',
                                todayPackage: 0,
                                totalPackage: 0
                            },
                            {
                                name: 'M01A',
                                todayPackage: 0,
                                totalPackage: 0
                            },
                            {
                                name: 'M01',
                                todayPackage: 0,
                                totalPackage: 0
                            },
                            {
                                name: 'M02',
                                todayPackage: 0,
                                totalPackage: 0
                            },
                            {
                                name: 'M03',
                                todayPackage: 0,
                                totalPackage: 0
                            },
                            {
                                name: 'M04',
                                todayPackage: 119,
                                totalPackage: 1404
                            },
                            {
                                name: 'M05',
                                todayPackage: 0,
                                totalPackage: 0
                            },
                            {
                                name: 'M08',
                                todayPackage: 0,
                                totalPackage: 331.5
                            }
];
var projectInformation = [{}];
var environmentalProject = [
                                {
                                    environmentalPs:'石灰单价480元/吨。产品单耗对应的产品量为干矿量。',
                                      data:  [{
                                            name: "石灰用量",
                                            monthPlanNum: "####",
                                            monthPlanCost : 6.9,
                                            todayNum : 1.8,
                                            todayCost: 3.77,
                                            thisMonthTotalNum: 58.00,
                                            thisMonthTotalCost: 3.01,
                                            projectPs : ''
                                        }]
                                }
                            ];
var packageForm = 'packageForm';
var packageCtrl = 'packageCtrl';


function showData(packageForm, packageCtrl, packageSituation, projectInformation, environmentalProject)
{
    angular.module(packageForm, []).controller(packageCtrl, function ($scope) {
        $scope.packageSituation = packageSituation;
        $scope.projectInformation = projectInformation;
        $scope.environmentalProject = environmentalProject[0].data;
        $scope.environmentalPs = environmentalProject[0].environmentalPs
    });
}


showData(packageForm, packageCtrl, packageSituation, projectInformation, environmentalProject);

