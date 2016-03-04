<?php if (!defined('THINK_PATH')) exit();?><!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title><?php echo ($site_cfg["sitename"]); ?></title>
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
									<div class="tabbable">

									<div class="box">
										<div class="box-header blue-background mb">
											<div class="title"><i class="glyphicon glyphicon-edit"></i> 用户管理</div>
										</div><!--/box-header-->
										<div class="boxx-body pt">
											<form action="/index.php?s=/home/main/adduser"  method="post" id="table_post" >
												<label class="checkbox-inline">
													用户名：<input type="text" name="username"/>
													<button type="submit" class="btn btn-primary" id="save">新增普通用户</button>
													<p class="help-block">普通用户密码默认6个8。</p>
												</label>
												
											</form>


										</div><!--/boxx-body-->
									</div><!--/box-->

									<div class="tab-content">
										
											<table class="table table-bordered table-striped" id="table_list">
												<thead>
													<th>用户名</th>
												</thead>
												<tbody>
													<!-- <?php if(is_array($data)): $i = 0; $__LIST__ = $data;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?>-->
													<tr>
														<td><?php echo ($vo["username"]); ?><button class ="btn btn-primary" changePassword style="float:right ;margin-right:60px">修改密码</button>
															<button class ="btn btn-defalt" deleteUser style="float:right ;margin-right:60px">删除</button>
														</td>
													</tr>
													<!--<?php endforeach; endif; else: echo "" ;endif; ?> -->
												</tbody>
											</table>
											<ul class="pagination">
												<?php echo ($page); ?>
											</ul>
										
									</div><!--/tab-content-->
								</div><!--/tabbable-->

							</div><!--/col-sm-12-->
						</div><!--/row-->
					</div><!--/boxx-body-->
				</div><!--/boxx-->
			</div><!--/col-xs-12-->

	</div><!--/container-->

<script type="text/javascript">
$(function(){
	$('button[changePassword]').click(function(e){
		$.get('<?php echo U('main/adminEditPassword');?>',{'id':e.target.parentNode.firstChild.data},function(data){
			alert(JSON.parse(data).msg);
		});
	});
	$('button[deleteUser]').click(function(e){
		$.get('<?php echo U('main/adminDeleteUser');?>',{'id':e.target.parentNode.firstChild.data},function(data){
			alert(JSON.parse(data).msg);
			window.location.reload();
		});
	});
})
</script>