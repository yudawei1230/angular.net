<?php if (!defined('THINK_PATH')) exit();?><!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>基础设置</title>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<link rel="stylesheet" type="text/css" href="/Application/Home/View/Main/css/bootstrap.min.css">
		<link  href="/Application/Home/View/Main/css/admin.css" type="text/css" rel="stylesheet" />
		<link rel="stylesheet" type="text/css" href="/Application/Home/View/Main/css/admin.css">
		<script type="text/javascript" src="/Application/Home/View/js/jquery-1.10.2.min.js"></script>
		<?php echo ($other_script); ?>
	</head>
	<body>
		<div class="navbar navbar-inverse">
			<div class="container">
				<div class="navbar-header">
					<a href="<?php echo U('main/index');?>" class="navbar-brand">报表工具</a>
				</div>
				<div class="navbar-collapse collapse">
					<span class="pull-right">当前登录用户：<?php echo ($user['username']); ?> [<a href="<?php echo U('login/logout');?>" >[退出]</a>]</span>
					<span class="pull-right">[<a href="<?php echo U('main/editpassword');?>" >修改密码]&nbsp;&nbsp;</a></span>
					<span class="pull-right">[<a href="<?php echo U('main/reportset');?>" >基本设置]&nbsp;&nbsp;</a></span>
					
				</div><!--/.navbar-collapse -->
			</div>
		</div>
		<div id="container">



	<div class="container">
		<div id="contentWrap" class="row">
			<div class="col-xs-12">
				<div class="boxx">
					<div class="boxx-body">
						<div class="row">
							<div class="col-sm-12">
									<div class="tab-content">
										<div class="box">
											<div class="box-header blue-background mb">
												<div class="title"><i class="glyphicon glyphicon-edit"></i> 基础设置</div>
											</div><!--/box-header-->
											<div class="boxx-body pt">
												<form class="form-horizontal" role="form" action="<?php echo U('main/setpost');?>" method="post" enctype="multipart/form-data" id="form">
													<div class="form-group">
														<label for="organizationcode" class="col-lg-2 control-label">机构类代码</label>
														<div class="col-lg-10">
															<input type="text" class="form-control" id="organizationcode" name="organizationcode" placeholder="机构类代码，4位" value="<?php echo ($set["organizationcode"]); ?>">
														</div>
													</div>

													<div class="form-group">
														<label for="areascode" class="col-lg-2 control-label">地区代码</label>
														<div class="col-lg-10">
															<input type="text" class="form-control" id="areascode" name="areascode" placeholder="地区代码,7位" value="<?php echo ($set["areascode"]); ?>">
														</div>
													</div>
													<div class="form-group">
														<label for="institutioncode" class="col-lg-2 control-label">标准化机构编码</label>
														<div class="col-lg-10">
															<input type="text" class="form-control" id="institutioncode" name="institutioncode" placeholder="标准化机构编码,14位" value="<?php echo ($set["institutioncode"]); ?>">
														</div>
													</div>
													<hr class="hr-normal">
													<div class="form-actions form-actions-padding-sm">
														<div class="row">
															<div class="col-md-10 col-md-offset-2">
																<button type="submit" class="btn btn-success" id="submit"><i class="glyphicon glyphicon-ok"></i> 保存</button>
																<input type="button" class="btn btn-defalt" style="margin-left:50px;width:72px" value="返回" id="back"></input>  
															</div>
														</div>
													</div>
												</form>
											</div><!--/boxx-body-->
										</div><!--/box-->
									</div><!--/tab-content-->


							</div><!--/col-sm-12-->
						</div><!--/row-->
					</div><!--/boxx-body-->
				</div><!--/boxx-->
			</div><!--/col-xs-12-->
	</div><!--/container-->

<script type="text/javascript">
$(function(){
	$('#back').click(function(){
		window.location.href = '<?php echo U("main/index");?>';
	});
})
</script>