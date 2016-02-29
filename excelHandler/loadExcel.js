app.factory("loadExcel",function(){
	 function readExcel(keyCode,organizationCode,areaCode,date,times)
 {
 try{
 	var oXL = new ActiveXObject("Excel.Application");
    var path = document.getElementById("filePath");
    var oWB = oXL.Workbooks.open(path.value);
 }catch(e){
  alert('打开文件失败！');
  console.log(e);
 }
    var o;
    var oSheet = oWB.ActiveSheet;
    var nRows=oSheet.usedrange.rows.count;
    var nColumns =oSheet.usedrange.columns.count;
/*    try
    { */   
    	var fso = new ActiveXObject("Scripting.FileSystemObject");
    	var filepath = "BIJD"+organizationCode+areaCode+date+"31"+times+"11";
		// 创建新文件
	//fso.DeleteFolder("D:\\Yu\\excelHandler\\"+filepath);
	//console.log(fso.GetFolder("D:\\Yu\\excelHandler\\"+filepath));
	fso.CreateFolder("D:\\Yu\\excelHandler\\"+filepath);
	var tf = fso.CreateTextFile("D:\\Yu\\excelHandler\\"+filepath+"\\"+"BJ"+organizationCode+areaCode+date+"31"+times+"11"+".DAT", true);
	var df = fso.CreateTextFile("D:\\Yu\\excelHandler\\"+filepath+"\\"+"BI"+organizationCode+areaCode+date+"31"+times+"11"+".IDX", true);
	var sf = fso.CreateTextFile("D:\\Yu\\excelHandler\\"+filepath+"\\"+"BD"+organizationCode+areaCode+date+"31"+times+"11"+".TXT", true);
	sf.Close();
	df.WriteLine(keyCode+"|"+"A1411"+"|"+organizationCode+"|"+areaCode+"|"+"1"+"|"+"CNY0001"+"|"+"1"+"|"+"1"+"|"+"1"+"|"+"Z1558144000011");
    for(var i=0;i<nRows;i++)
    {
			if(i>3)
			{
				o = typeof(oSheet.Cells(i,4).value);
				if(o.indexOf("undefine")!=0&&o.indexOf("string")!=0)
				{
					tf.WriteLine(keyCode+"|"+oSheet.Cells(i,1).value+'|'+oSheet.Cells(i,4).value);
				}
				
			}
    }
	alert("文件生成成功！");
	/*}*/
/*    catch(e){
    	oWB.close();
    	tf.Close();
    	df.Close(); 
    	alert("文件生成失败");
    	console.log(e+"!");
    }  */
 tf.Close();
 df.Close(); 
 oSheet=null;
 oWB.close();
 oXL=null;
 }
 function GetExcelData(){
 	try{
 	 	var oXL = new ActiveXObject("Excel.Application");
	    var path = document.getElementById("filePath");
	    var oWB = oXL.Workbooks.open(path.value);
	}catch(e){
	  alert('打开文件失败！');
	  console.log(e);
	}
	try{
		var data = [];
	    var oSheet = oWB.ActiveSheet;
	    var nRows=oSheet.usedrange.rows.count;
        for(var i=0;i<nRows;i++)
    	{
			if(i>3)
			{
				data.push({
					DataName:oSheet.Cells(i,2).value,
					DataCode:oSheet.Cells(i,1).value,
					DataValue:oSheet.Cells(i,4).value
				});				
			}
    	}
	 }
	 catch(e){
	 	alert('Excel导入失败！');
	 }
	 return data;
 }
	return{
		'readExcel':readExcel,
		'GetExcelData' : GetExcelData
	}
});