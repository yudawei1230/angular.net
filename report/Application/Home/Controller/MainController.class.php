<?php
namespace Home\Controller;
class MainController extends FrontController {
    protected function _init() {
        $this->assign('user',$this->user);
        if (!$this->checkConsoleLogin()){
            $this->redirect('Login/login');
            exit;
        }
    }
    //初始页面
    public function index(){
    	//管理员跳转
    	if($this->user['type'] == 1){
    		$db = D('User');
    		$data = $db->getList();
    		$this->assign('data',$data['data_list']);
    		$this->assign('page',$data['page_list']);
        	$this->display('Main/admin');
        }else{
        	//查询ID report列表
        	$report_db = D('Report');
        	$re = $report_db->getList($map,$this->user['id']);
        	//设置默认年月
        	$curr_year = intval(date('Y'));
			$curr_month = "ALL";
			$this->assign('curr_year',"ALL");	
			//设置年月下拉标签
			$year[]= ['所有','ALL'];
			for($i=5;$i>=0;$i--){
			    if($i<0){break;}
			    $year[]= [$curr_year+$i,$curr_year+$i];
			}
			for ($i=1; $i<=5; $i++) { 
				$year[]= [$curr_year-$i,$curr_year-$i];
			}
			//设置季度月份下拉标签
			$season = array(array("全部",'ALL'),array("一月",'01'),array("二月",'02'),array("三月",'03'),array("四月",'04'),array("五月",'05'),array("六月",'06'),array("七月",'07'),array("八月",'08'),array("九月",'09'),array("十月",'10'),array("十一月",'11'),array("十二月",'12'));
			$this->assign('season',$season);
			//列表名，频度名转换	
			for($i=0;$i<count($re['data_list']);$i++)
			{
				if($re['data_list'][$i]['frequentness']==0)
				{
					if($re['data_list'][$i]['reportname']=="LR")
					{
						$re['data_list'][$i]['frequentness']="年报";
						$re['data_list'][$i]['reportname'] = "利润表";
						continue;
					}
					else
						$re['data_list'][$i]['frequentness']="初始";
				}
				switch($re['data_list'][$i]['reportname'])
				{
					case "JGZB": $re['data_list'][$i]['reportname'] = "监管指标表";$re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."季度"; break;
					case "ZXTJ": $re['data_list'][$i]['reportname'] = "专项统计表";$re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."季度"; break;
					case "LR": $re['data_list'][$i]['reportname'] = "利润表"; $re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."季度";break;
					case "ZCFZ": $re['data_list'][$i]['reportname'] = "资产负债表";$re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."月"; break;
				}
			}
			//传递数据
			$this->assign('display','initial');
			$this->assign('year',$year);
        	$this->assign('report_list',$re['data_list']);
        	$this->assign('page',$re['page_list']);
        	//跳转USER页
        	$this->display('main/user');
        }
    }


    // 账号基础设置页面初始化
    public function reportSet(){
    	if($this->user['type'] == 2){
    		$set = M('User_set')->where(array('u_id'=>$this->user['id']))->find();
     		$this->assign('set',$set);
    		$this->display('main/reportset');
    	}
    }
    // 账号基础设置操作
    public function setPost(){
    	if($this->post){
				$data["organizationcode"] = $_POST['organizationcode'];
				$data["areascode"] = $_POST['areascode'];
				$data["institutioncode"] = $_POST['institutioncode'];
				if(empty($data["organizationcode"]) || empty($data["areascode"]) || empty($data["institutioncode"])){
					alert('机构类代码,地区代码,标准化机构编码不能为空','Main/reportSet');
					exit;
				}
				if(strlen($data["organizationcode"]) != 4){
					alert('机构类代码为4位字符','Main/reportSet');
					exit;
				}
				if(strlen($data["areascode"]) != 7){
					alert('地区代码为7位字符','Main/reportSet');
					exit;
				}
				if(strlen($data["institutioncode"]) != 14){
					alert('标准化机构编码为14位字符','Main/reportSet');
					exit;
				}
				$user_set_db = M('User_set');
				$set_val = $user_set_db->where(array('u_id'=>$this->user['id']))->find();
				if($set_val){
					$user_set_db->data($data)->where(array('u_id'=>$this->user['id']))->save();
				}else{
					$data['u_id'] = $this->user['id'];
					$user_set_db->data($data)->add();
				}
				alert('设置成功','Main/index');
    	}
    }
    // 上传操作
    public function uploadReport(){
    	$set = M('User_set')->where(array('u_id'=>$this->user['id']))->find();
    	if(!$set){
    		alert('请先进行基本设置','main/reportset');
    		exit;
    	}

	    $upload = new \Think\Upload();// 实例化上传类
	    $upload->maxSize   =     3145728 ;// 设置附件上传大小
	    $upload->exts      =     array('xls');// 设置附件上传类型
	    $upload->rootPath  =     './upload/'; // 设置附件上传根目录
	    $upload->savePath  =     ''; // 设置附件上传（子）目录
	    // 上传文件 
	    $info   =   $upload->upload();
	    if(!$info) {// 上传错误提示错误信息
	        alert($upload->getError(),'Main/index');
	    }else{// 上传成功
	    	session('upload_file',$info);
	    	session('backurl',$_POST['backurl']);
	    }
	    alert('上传成功','main/report');
    }
    // EXCEL页面初始化
    public function report(){
    	//获取ID 列表
    	$report_db = D('Report');
    	$re = $report_db->getList($map,$this->user['id']);
    	//获取ID基本设置数据
    	$set = M('User_set')->where(array('u_id'=>$this->user['id']))->find();
    	//设置默认年月
    	$curr_year = intval(date('Y'));
		$curr_month = date('m');			
		for($i=5;$i>0;$i--){
		    if($i<0){break;}
		    $year[]= $curr_year+$i;
		}
		$year[] = $curr_year;
		for ($i=1; $i<=5; $i++) { 
			$year[]= $curr_year-$i;
		} 
		$this->assign('curr_year',$curr_year);
		$this->assign('year',$year);
		//列表名，频度名转换
		for($i=0;$i<count($re['data_list']);$i++)
		{
			if($re['data_list'][$i]['frequentness']==0)
			{
				if($re['data_list'][$i]['reportname']=="LR")
				{
					$re['data_list'][$i]['frequentness']="年报";
					$re['data_list'][$i]['reportname'] = "利润表";
					continue;
				}
				else
					$re['data_list'][$i]['frequentness']="初始";
			}
			switch($re['data_list'][$i]['reportname'])
			{
				case "JGZB": $re['data_list'][$i]['reportname'] = "监管指标表";$re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."季度"; break;
				case "ZXTJ": $re['data_list'][$i]['reportname'] = "专项统计表";$re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."季度"; break;
				case "LR": $re['data_list'][$i]['reportname'] = "利润表"; $re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."季度";break;
				case "ZCFZ": $re['data_list'][$i]['reportname'] = "资产负债表";$re['data_list'][$i]['frequentness'] = $re['data_list'][$i]['frequentness']."月"; break;
			}

		}
		//excel操作，读取excel
		/** PHPExcel_IOFactory */
		vendor('PHPExcel.PHPExcel.IOFactory');
		// Check prerequisites
		$info = session('upload_file');
		session('upload_file',null);
		$file_path = './upload/'.$info['table']['savepath'].$info['table']['savename'];
		$file_org_name = $info['table']['name'];
		if(!file_exists($file_path) || empty($info)) {
			alert("没有找到xls文件.",'main/index');
		}
		$reader = \PHPExcel_IOFactory::createReader('Excel5'); //设置以Excel5格式(Excel97-2003工作簿)
		//$PHPExcel = $PHPReader->load($dir.$templateName);
		$PHPExcel = $reader->load($file_path); // 载入excel文件
		$sheet = $PHPExcel->getSheet(0); // 读取第一個工作表
		$highestRow = $sheet->getHighestRow(); // 取得总行数
		$highestColumm = $sheet->getHighestColumn(); // 取得总列数
		$dat_con = '';
		/** 循环读取每个单元格的数据 */
		$reportName = $sheet->getCell('A'.'1')->getValue();
		$datacol1 = 'B';
		$datacol2 = 'A';
		$row = 4;
		if($reportName =="")
		{
			$reportName = "监管指标表";
			$datacol1 = 'C';
			$datacol2 = 'B';
			$datacol3 = 'D';
			$row = 6;
		}
		else if($reportName !="人行资产负债表")
			$datacol3 = 'C';
		else
			$datacol3 = 'D';
		$this->assign('reportName',$reportName);
		for (; $row <= $highestRow; $row++){//行数是以第1行开始
			$table_val[$row]['0'] = $sheet->getCell($datacol1.$row)->getValue();
			$table_val[$row]['1'] = $sheet->getCell($datacol2.$row)->getValue();
			$table_val[$row]['2'] = trim($sheet->getCell($datacol3.$row)->getValue());
		}
		//根据不同列表显示不同频度
		switch($reportName)
		{
			case "监管指标表" : $frequent=[["初始",0],["第一季度",1],["第二季度",2],["第三季度",3],["第四季度",4]]; $reportName="JGZB"; break;
			case "人行资产负债表" : $frequent=[["初始",0],["1月",1],["2月",2],["3月",3],["4月",4],["5月",5],["6月",6],["7月",7],["8月",8],["9月",9],["10月",10],["11月",11],["12月",12]];$reportName="ZCFZ"; break;
			case "人行专项统计表" : $frequent=[["初始",0],["第一季度",1],["第二季度",2],["第三季度",3],["第四季度",4]];$reportName="ZXTJ"; break;
			case "人行利润表" : $frequent=[["年度",0],["第一季度",1],["第二季度",2],["第三季度",3],["第四季度",4]];$reportName="LR"; break;
		}
		//数据传递
		$this->assign('frequent',$frequent);
		$this->assign('table_val',$table_val);
		//建立文件夹 移动，并重命名excel	
		if (!file_exists('./upload/'.$info['table']['savepath'].$set['institutioncode']))
			mkdir('./upload/'.$info['table']['savepath'].$set['institutioncode']);
		$rename = './upload/'.$info['table']['savepath'].$set['institutioncode'].'/'.$curr_year."-".$curr_month."-".$set['institutioncode']."-".$reportName.".xls";
		rename($file_path,$rename);
		//传递返回URL
		$this->assign('backpath',session('backurl'));
		session('backurl',null);	
		$this->assign('display','none');
		$this->assign('path',$rename);	
		$this->display('main/report');

    }
    //保存EXCEL操作及跳转
    public function editreport(){
    	//获取ajax数据
    	$year = $_POST['year'];
    	unset($_POST['year']);
    	$month = $_POST['month'];
    	unset($_POST['month']);
    	$days = $_POST['day'];
    	unset($_POST['day']);
    	$frequent = ($_POST['frequent']);
    	unset($_POST['frequent']);
		$isDel = ($_POST['isDel']);
    	unset($_POST['isDel']);
    	$Excelpath = $_POST['path'];
    	unset($_POST['path']);
    	$reportName = $_POST['reportName'];
    	unset($_POST['reportName']);
    	//获取ID基础设置
    	$set = M('User_set')->where(array('u_id'=>$this->user['id']))->find();
    	//截取excel地址字符串
    	$rename = explode('-',explode('/', $Excelpath)[4])[3];
    	//新建文件夹
		if(!file_exists('./upload/'.date('Y-m-d')))
		{
			mkdir('./upload/'.date('Y-m-d'));
			if(!file_exists('./upload/'.date('Y-m-d').'/'.$set['institutioncode']))
				mkdir('./upload/'.date('Y-m-d').'/'.$set['institutioncode']);
		}
		//移动并重命名EXCEL	
    	if($frequent == '0'&& ($reportName == '人行资产负债表'||$reportName == "人行利润表"))
    	{
    		rename($Excelpath,'./upload/'.date('Y-m-d').'/'.$set['institutioncode'].'/'.$year."-".$month."-".'max'.$set['institutioncode']."-".$rename);
    		$Excelpath = './upload/'.date('Y-m-d').'/'.$set['institutioncode'].'/'.$year."-".$month."-".'max'.$set['institutioncode']."-".$rename;
    	}
    	else
    	{
	    	rename($Excelpath,'./upload/'.date('Y-m-d').'/'.$set['institutioncode'].'/'.$year."-".$month."-".$set['institutioncode']."-".$rename);
    		$Excelpath = './upload/'.date('Y-m-d').'/'.$set['institutioncode'].'/'.$year."-".$month."-".$set['institutioncode']."-".$rename;
    	}
    	//更改报表名
    	switch($reportName)
    	{
    		case "人行资产负债表": $reportName = 'ZCFZ'; $zipfrequent ='4'; break;
    		case "人行利润表": $reportName = 'LR'; if($frequent == '0')$zipfrequent ='0';else $zipfrequent ='3'; break;
    		case "人行专项统计表": $reportName = 'ZXTJ'; $zipfrequent ='3'; break;
    		case "监管指标表": $reportName = 'JGZB'; $zipfrequent ='3'; break;
    	}
    	//读取report页表格数据
    	foreach($_POST as $val){
    		if(strpos($val,"&nbsp;"))
    			{
    				$val = str_replace("&nbsp;","",$val);
    			}
    		$data[] = explode('*', $val);

    	}
		$user_set[0] = 'I00001';//关键字代码
		$user_set[1] = 'A1411';//表单代码
		$user_set[2] = $set['organizationcode'];//机构类代码
		$user_set[3] = $set['areascode'];//地区代码
		$user_set[4] = '1';//数据属性
		$user_set[5] = 'CNY0001';//币种
		$user_set[6] = '1';//单位
		$user_set[7] = '1';//业务数据标志
		$user_set[8] = '1';//数值型类型
		$user_set[9] = $set['institutioncode'];//标准化机构编码
		
		//idx
		$idx_con = implode('|', $user_set);
		//dat
		$dat_con = '';
		$counts=1;
		//excel操作
		if(file_exists($Excelpath)) {
			//保存数据于本地操作，如文件不存在则保存不成功
			/** PHPExcel_IOFactory */
			vendor('PHPExcel.PHPExcel.IOFactory');
			$reader = \PHPExcel_IOFactory::createReader('Excel5'); //设置以Excel5格式(Excel97-2003工作簿)
			//$PHPExcel = $PHPReader->load($dir.$templateName);
			$PHPExcel = $reader->load($Excelpath); // 载入excel文件
			$sheet = $PHPExcel->getSheet(0); // 读取第一個工作表
			$highestRow = $sheet->getHighestRow(); // 取得总行数
			$highestColumm = $sheet->getHighestColumn(); // 取得总列数
			$excelName = $sheet->getCell('A'.'1')->getValue();
			$datacol1 = 'B';
			$datacol2 = 'A';
			$row = 4;
			$p =0;
			if($excelName =="")
			{
				$excelName = "监管指标表";
				$datacol1 = 'C';
				$datacol2 = 'B';
				$datacol3 = 'D';
				$row = 6;
			}
			else if($excelName !="人行资产负债表")
				$datacol3 = 'C';
			else
				$datacol3 = 'D';
			//创立数据文件
			foreach($data as $val){
				if($counts++==count($data))
					break;
				if($val[1]=="")
					break;
				$dat_con .=$user_set[0].'|'.$val[0].'|'.$val[1]."\r\n";
			}
			//保存页面数据于EXCEL
			for($i=0;$i<$highestRow;$row++){
				if($row>$highestRow)
					break;

				if($data[$i][0]==substr($sheet->getCell($datacol2.$row)->getValue(),0,strlen($data[$i][0])))
				{
					$sheet->getCell($datacol3.$row)->setValue($data[$i][1]);
					$i++;
				}
				else
				{
					$sheet->getCell($datacol3.$row)->setValue("");
					$g[$p++] = substr($sheet->getCell($datacol2.$row)->getValue(),0,strlen($data[$i][0]));
				}		
			}
			$PHPWriter = \PHPExcel_IOFactory::createWriter($PHPExcel, 'Excel5');
			$PHPWriter->save($Excelpath);	
		}
		//创建ZIP文件
		$dat_con = trim($dat_con);

		/*filename;
		1         代号（金融统计监测管理信息系统-数值型统计指标数据－B）
		2		  标志位（头文件：I；数据文件：J；数据说明文件：D）
		3—6	  机构类代码
		7—13	  地区代码
		14—21	  年（4位），月（2位，01、02…11、12月），日（2位）
		22	  频度 报送银行的次数，没做报文前让用户选。
		23	  批次 固定1
		24    顺序号（文件名的顺序码没有特别的含义，主要为区分多次报送而设置，也可以在数据修改阶段，用于对不同时间报送的数据进行区分）
		*/
		//头文件

		$idx_filename = 'B'.'I'.$user_set[2].$user_set[3].$year.$month.$days.$zipfrequent.'1'.'1'.'.idx';
		//数据文件
		$dat_filename = 'B'.'J'.$user_set[2].$user_set[3].$year.$month.$days.$zipfrequent.'1'.'1'.'.dat';
		//说明文件
		$txt_filename = 'B'.'D'.$user_set[2].$user_set[3].$year.$month.$days.$zipfrequent.'1'.'1'.'.txt';



		file_put_contents(TEMP_PATH.$idx_filename, $idx_con);
		file_put_contents(TEMP_PATH.$dat_filename, $dat_con);
		file_put_contents(TEMP_PATH.$txt_filename, '');
     	vendor('PclZip');

     	$data['path'] = date('Y-m-d').'/'.$this->user['id'].'-'.$year.'-'.$month.'-'.$frequent.$reportName.'.zip';
     	$data['u_id'] = $this->user['id'];
     	$data['year'] = $year;
     	$data['month'] = $month;
     	$data['frequentness'] = $frequent;
     	$data['reportname'] = $reportName;
     	$data['updatetime'] = $this->timestamp;

     	$zipfile = './upload/'.$data['path'];
		$archive = new \PclZip($zipfile);
		$file_path = TEMP_PATH.$idx_filename.','.TEMP_PATH.$dat_filename.','.TEMP_PATH.$txt_filename;
        $v_list = $archive->create($file_path,PCLZIP_OPT_REMOVE_PATH, 'Application/Runtime/Temp/');
		//查询数据库此报表是否存在并覆盖 
		if ($v_list == 0) {
			echo json_encode(array(
				'err'=>1,
				'msg'=>$archive->errorInfo(true)
			),true);
		}else{
			$report_db = M('Report');
			$tmp = $report_db ->where(array('u_id'=>$this->user['id'],'year'=>$year,'month'=>$month,'frequentness'=>$frequent,'reportname'=>$reportName))->find();
			if($tmp){
				$a = $report_db ->where(array('u_id'=>$this->user['id'],'year'=>$year,'month'=>$month,'frequentness'=>$frequent,'reportname'=>$reportName))->data($data)->save();
				$exsitPf = 1;
			}else{
				$a = M('Report')->data($data)->add();	
				$exsitPf = 0;
			}
		}

		if($a){
			unset($_POST['reportName']);
			@unlink(realpath(TEMP_PATH.$idx_filename));
			@unlink(realpath(TEMP_PATH.$dat_filename));
			@unlink(realpath(TEMP_PATH.$txt_filename));
			echo json_encode(array(
				'err'=>0,
				'exsitPf' =>$exsitPf,
				'Excelpath' =>$Excelpath
			),true);
		}

    }
    //报表筛选操作
    public function changereport(){
    	//获取ajax数据
    	$years = $_GET['year'];
    	$report = $_GET['report'];
    	$month = $_GET['month'];
		$report_db = M('Report');
		//设置默认年月
    	$curr_year = intval(date('Y'));
		$this->assign('curr_year',$years);	
		//设置年月下拉标签
		$year[]= ['所有','ALL'];
		for($i=5;$i>=0;$i--){
		    if($i<0){break;}
		    $year[]= [$curr_year+$i,$curr_year+$i];
		}
		for ($i=1; $i<=5; $i++) { 
			$year[]= [$curr_year-$i,$curr_year-$i];
		}
		//根据报表名及月份修改频度
		if($report=="LR")
		{
			$season = [["全部",'ALL'],["第一季度",'03'],["第二季度",'06'],["第三季度",'09'],["第四季度",'12']];
			if($month ==""||$month=="undefined")
			{
			    $curr_season = "全部";
			    $month = 'ALL';
			}
			else if($month=='01'||$month=='02')
				{
					$month = "03";
					$curr_season = "03";
				}
			else if($month=='04'||$month=='05')
				{
					$month = "06";
					$curr_season = "06";
				}
			else if($month=='07'||$month=='08')
				{
					$month = "09";
					$curr_season = "09";
				}
			else if($month=='10'||$month=='11')
				{
					$month = "12";
					$curr_season = "12";
				}
			else
				$curr_season = $month;
		}
		else if($report=="ZCFZ"||$report=="ALL")
		{
			$season = [["全部",'ALL'],["一月",'01'],["二月",'02'],["三月",'03'],["四月",'04'],["五月",'05'],["六月",'06'],["七月",'07'],["八月",'08'],["九月",'09'],["十月",'10'],["十一月",'11'],["十二月",'12']];
			if($month==""||$month=="undefined")
			{
			    $curr_season = "全部";
			    $month = 'ALL';
			}
			else
				$curr_season = $month;
		}
		else
		{
			$season = [["全部",'ALL'],["初始",'01'],["第一季度",'03'],["第二季度",'06'],["第三季度",'09'],["第四季度",'12']];
			if($month==""||$month=="undefined")
			{
			    $curr_season = "全部";
			    $month = 'ALL';
			}
			else if($month=='02')
				{
					$month = "03";
					$curr_season = "03";
				}
			else if($month=='04'||$month=='05')
				{
					$month = "06";
					$curr_season = "06";
				}
			else if($month=='07'||$month=='08')
				{
					$month = "09";
					$curr_season = "09";
				}
			else if($month=='10'||$month=='11')
				{
					$month = "12";
					$curr_season = "12";
				}
			else
				$curr_season = $month;

		}
		$this->assign('curr_season',$curr_season);
		$this->assign('season',$season);	
		//筛选操作
		$selectSql= array('u_id'=>$this->user['id']);
		if($years != "ALL")
			$selectSql['year'] = $years;
		if($month !="ALL")
			$selectSql['month'] = $month;
		if($report != "ALL")
			$selectSql['reportname'] = $report;
		$tmp = $report_db ->where($selectSql)->select();
		for($i=0;$i<count($tmp);$i++)
		{

			if($tmp[$i]['frequentness']==0)
			{
				if($tmp[$i]['reportname']=="LR")
				{
					$tmp[$i]['frequentness']="年报";
					$tmp[$i]['reportname'] = "利润表";
					continue;
				}
				else
					$tmp[$i]['frequentness']="初始";
			}
			switch($tmp[$i]['reportname'])
			{
				case "JGZB": $tmp[$i]['reportname'] = "监管指标表";$tmp[$i]['frequentness'] = $tmp[$i]['frequentness']."季度"; break;
				case "ZXTJ": $tmp[$i]['reportname'] = "专项统计表";$tmp[$i]['frequentness'] = $tmp[$i]['frequentness']."季度"; break;
				case "LR": $tmp[$i]['reportname'] = "利润表";$tmp[$i]['frequentness'] = $tmp[$i]['frequentness']."季度";break;
				case "ZCFZ": $tmp[$i]['reportname'] = "资产负债表";$tmp[$i]['frequentness'] = $tmp[$i]['frequentness']."月"; break;
			}
		}
		//传递数据
		$this->assign('display','initial');
		$this->assign('year',$year);
    	$this->assign('report_list',$tmp);
    	$this->display('main/user');
    }
    //下载操作
    public function download(){
    	$id = abs($_GET['id']);
    	if($id == 0){
    		alert('下载文件不存在','main/index');
    	}
    	$report = M('report')->find($id);
    	$tmp_path = $report['path'];
    	$path = explode('/', $tmp_path);
    	$dir = './upload/'.$path[0].'/';
    	$filename = $path[1];
         
        if (!file_exists($dir.$filename)){
            header("Content-type: text/html; charset=utf-8");
            echo "File not found!";
            exit; 
        } else {
            $file = fopen($dir.$filename,"r"); 
            Header("Content-type: application/octet-stream");
            Header("Accept-Ranges: bytes");
            Header("Accept-Length: ".filesize($dir . $filename));
            Header("Content-Disposition: attachment; filename=".$filename);
            echo fread($file, filesize($dir.$filename));
            fclose($file);
        }
    }
    //EXCEL查看及更改操作
    public function checkExcel(){
    	//获取ajax数据
    	$id = $_GET['id'];
    	$backpath = $_GET['backpath'];
    	$report = M('report')->find($id);
    	$set = M('User_set')->where(array('u_id'=>$this->user['id']))->find();
    	$tmp_path = $report['path'];
    	$date = explode('/', $tmp_path)[0];
    	if($report['frequentness']=="0"&&($report['reportname']=='ZCFZ'||$report['reportname']=='LR'))
    		$day = 'max';
    	else
    		$day = '';
    	if(!file_exists('./upload/'.$date.'/'.$set['institutioncode'].'/'.$report['year'].'-'.$report['month'].'-'.$day.$set['institutioncode'].'-'.$report['reportname'].'.xls'))
    		alert('数据文件异常，无法查看，请重新上传','Main/index');
    	$excelPath = './upload/'.$date.'/'.$set['institutioncode'].'/'.$report['year'].'-'.$report['month'].'-'.$day.$set['institutioncode'].'-'.$report['reportname'].'.xls';
    			/** PHPExcel_IOFactory */
		vendor('PHPExcel.PHPExcel.IOFactory');		 
		$reader = \PHPExcel_IOFactory::createReader('Excel5'); //设置以Excel5格式(Excel97-2003工作簿)
		//$PHPExcel = $PHPReader->load($dir.$templateName);
		$PHPExcel = $reader->load($excelPath); // 载入excel文件
		$sheet = $PHPExcel->getSheet(0); // 读取第一個工作表
		$highestRow = $sheet->getHighestRow(); // 取得总行数
		$highestColumm = $sheet->getHighestColumn();//取得总列数
		$dat_con = '';
		/** 循环读取每个单元格的数据 */
		$reportName = $sheet->getCell('A'.'1')->getValue();
		$datacol1 = 'B';
		$datacol2 = 'A';
		$row = 4;
		if($reportName =="")
		{
			$reportName = "监管指标表";
			$datacol1 = 'C';
			$datacol2 = 'B';
			$datacol3 = 'D';
			$row = 6;
		}
		else if($reportName !="人行资产负债表")
			$datacol3 = 'C';
		else
			$datacol3 = 'D';
		for (; $row <= $highestRow; $row++){//行数是以第1行开始
			$table_val[$row]['0'] = $sheet->getCell($datacol1.$row)->getValue();
			$table_val[$row]['1'] = $sheet->getCell($datacol2.$row)->getValue();
			$table_val[$row]['2'] = trim($sheet->getCell($datacol3.$row)->getValue());
		}

		switch($reportName)
		{
			case "监管指标表" : $frequent=[["初始",0],["第一季度",1],["第二季度",2],["第三季度",3],["第四季度",4]]; break;
			case "人行资产负债表" : $frequent=[["初始",0],["1月",1],["2月",2],["3月",3],["4月",4],["5月",5],["6月",6],["7月",7],["8月",8],["9月",9],["10月",10],["11月",11],["12月",12]]; break;
			case "人行专项统计表" : $frequent=[["初始",0],["第一季度",1],["第二季度",2],["第三季度",3],["第四季度",4]]; break;
			case "人行利润表" : $frequent=[["年度",0],["第一季度",1],["第二季度",2],["第三季度",3],["第四季度",4]]; break;
		}
		$curr_year = $report['year'];
		$curr_month = date('m');
		for($i=5;$i>0;$i--){
		    if($i<0){break;}
		    $year[]= $curr_year+$i;
		}

		$year[] = $curr_year;
		for ($i=1; $i<=5; $i++) { 
			$year[]= $curr_year-$i;
		}
		$this->assign('display','none');
		$this->assign('reportName',$reportName);
		$this->assign('frequentSelected',$report['frequentness']);
		$this->assign('path',$excelPath);
		$this->assign('curr_year',$curr_year);
		$this->assign('year',$year);
		$this->assign('frequent',$frequent);
		$this->assign('id',$id);
		//@unlink(realpath($file_path));
		$this->assign('table_val',$table_val);
		if($_GET['report']!=""&&$_GET['year']!=""&&$_GET['month']!="")
			$this->assign('backpath',$backpath.'.html&report='.$_GET['report'].'&year='.$_GET['year'].'&month='.$_GET['month']);
		else
			$this->assign('backpath',"/index.php?s=/home/main/index.html");
		$this->display('main/report');

    }
    //删除旧数据文件
    public function checkDel(){
    	$id = abs($_GET['id']);
    	$report = M('report')->find($id);
    	@unlink(realpath('./upload/'.$report['path']));
    	$report = M('report')->delete($id);
    }
    //删除数据文件
    public function reportDel(){
    	$id = abs($_GET['id']);
    	if($id == 0){
    		alert('请选择要删除的报表','main/index');
    	}
    	$report = M('report')->find($id);
    	if($this->user['id'] != $report['u_id']){
    		alert('删除失败','main/index');
    	}
    	@unlink(realpath('./upload/'.$report['path']));
    	$report = M('report')->delete($id);
    	alert('删除成功','main/index');
    }
    //用户更改密码操作
    public function editPassword(){
    	if($this->post){
    		$old_pwd = trim($_POST['old_password']);
    		$new_pwd1 = trim($_POST['new_password1']);
    		$new_pwd2 = trim($_POST['new_password2']);
    		if($new_pwd1 != $new_pwd2){
    			alert('两次输入不一致','main/editPassword');
    			exit;
    		}

    		if(empty($old_pwd)){
    			alert('请填写旧密码','main/editPassword');
    			exit;
    		}
    		if(empty($new_pwd1)|| empty($new_pwd2)){
    			alert('请填写新密码','main/editPassword');
    			exit;
    		}
    		$old_pwd = md5($_POST['old_password']);
    		$new_pwd = md5($_POST['new_password1']);
    		if($old_pwd == M('User')->where(array('id'=>$this->user['id']))->find()['password']){
    			M('User')->data(array('password'=>$new_pwd))->where(array('id'=>$this->user['id']))->save();
    			$this->disAuthCookie();
    			$this->redirect('login/login');
    		}
    		else
    			alert('旧密码输入错误','main/editpassword');
    	}else{
    		$this->display('main/editpassword');
    	}
    }
    //管理员修改密码操作
    public function adminEditPassword(){
    		$new_pwd =md5('888888');
			$p=M('User')->data(array('password'=>$new_pwd))->where(array('username'=>$_GET['id']))->save();
			if($p)
				echo json_encode(array(
				'msg'=>'已修改用户'.$_GET['id'].'密码。'
				),true); 
			else
				echo json_encode(array(
				'msg'=>'修改密码失败,用户名不存在或密码已为初始密码'
				),true); 
    }
    //管理员删除账号
    public function adminDeleteUser(){
    	$id = $_GET['id'];
		$p=M('User')->where(array('username'=>$_GET['id']))->find();
		while($report = M('report')->where(array('u_id'=>$p['id']))->find())
		{
	    	@unlink(realpath('./upload/'.$report['path']));	
	    	M('report')->where(array('id'=>$report['id']))->delete();	
		}
			if($p)
			{
				M('User')->where(array('username'=>$_GET['id']))->delete();
				echo json_encode(array(
				'msg'=>'删除用户'.$_GET['id'].'成功。'
				),true); 
			}
			else
				echo json_encode(array(
				'msg'=>'删除用户失败'
				),true); 
    }
    public function admin(){
    	if($this->user['type'] == 1){
    		$db = D('User');
    		$data = $db->getList();
    		$this->assign('data',$data['data_list']);
    		$this->assign('page',$data['page_list']);
    		$this->display('main/admin');
    	}else{
    		$this->disAuthCookie();
    		$this->redirect('login/login');
    	}
    }

    public function adduser(){
    	if($this->user['type'] == 1){
    		$user_name = trim($_POST['username']);
    		if(empty($user_name)){
    			alert('用户名不能为空','main/admin');
    			exit;
    		}
    		if(M('User')->where(array('username'=>$user_name))->find()){
    			alert('用户名已存在','main/admin');
    			exit;	
    		}
    		$data['username'] = $user_name;
    		$data['password'] = md5('888888');
    		$data['type'] = 2;
    		$data['updatetime'] = $this->timestamp;
    		M('User')->data($data)->add();
    		alert('新增成功','main/admin');
    	}else{
    		$this->disAuthCookie();
    		$this->redirect('login/login');
    	}
    }
}