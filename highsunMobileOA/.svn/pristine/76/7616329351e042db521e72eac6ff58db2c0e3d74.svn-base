$(function($){
$(".PtBox li:nth-child(1)").css("background","#111").css("top","0px").css("left","160px");
$(".PtBox li:nth-child(2)").css("background","#222").css("top","0px").css("left","330px");
$(".PtBox li:nth-child(3)").css("background","#333").css("top","150px").css("left","75px");
$(".PtBox li:nth-child(4)").css("background","#444").css("top","150px").css("left","245px");
$(".PtBox li:nth-child(5)").css("background","#555").css("top","150px").css("left","415px");
$(".PtBox li:nth-child(6)").css("background","#666").css("top","300px").css("left","160px");
$(".PtBox li:nth-child(7)").css("background","#777").css("top","300px").css("left","330px");

$(".PtGat li:nth-child(1)").css("background","#111").css("top","0px").css("left","160px");
$(".PtGat li:nth-child(2)").css("background","#222").css("top","0px").css("left","330px");
$(".PtGat li:nth-child(3)").css("background","#333").css("top","150px").css("left","75px");
$(".PtGat li:nth-child(4)").css("background","#444").css("top","150px").css("left","245px");
$(".PtGat li:nth-child(5)").css("background","#555").css("top","150px").css("left","415px");
$(".PtGat li:nth-child(6)").css("background","#666").css("top","300px").css("left","160px");
$(".PtGat li:nth-child(7)").css("background","#777").css("top","300px").css("left","330px");
//////

$(".listBox li:nth-child(1)").css("border","none");

$(".screenBox li .scrLink").bind("click",function(){
	var menu=$(this).parent();
	if (menu.hasClass("screenUp")){
		menu.removeClass("screenUp");
	}else{
		menu.addClass("screenUp");
	}
});
$(".screenBox li").mouseleave(function(){
  $(".screenBox li").removeClass("screenUp")
});
		
		
//采集果篮颜色
 
$(".PtBox li label").click(function () {  
	$(this).parents("#page2").children(".PtBox").each(function () {
		$('label',this).parent().removeClass("radioUp");  
	});   
	$(this).parent().attr("class", "radioUp");
	//var valradio = $(".PtBox .radioUp input[value]").val(); 
	//alert(valradio);
	$.get("data.php",null,function(json){
	
		 //alert(json.id);
		 //alert(json.prize);
		 $(".GatColour").html('<img src='+json.img+'>');
		 //$(".GatColour").html('<span>'+json.prize+'</span><img src='+json.img+'>');
		
	},"json");
	$("#GatherPup").show();
	//$(".GatColour span").html(valradio);
	//$("#GatherPup").show().html('<div class="GatColour"><span>'+valradio+'</span></div>'); 
}); 
$("#GatherPup").click(function(){
	$(this).hide();
});
});
