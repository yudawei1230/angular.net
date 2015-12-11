 
--ͬ��portalchannelItem������
insert into dbo.PortalSearch(target,title,content,refid) select '../PortalManage/ItemView.aspx?id='+ CONVERT(varchar(36),ChannelItemID,36)
as target,ItemName as title,ItemContent as content,ChannelItemID as refid 
from dbo.PortalChannelItem

--ͬ��news������
insert into dbo.PortalSearch(target,title,content,refid) select '../PortalManage/NewsView.aspx?id='+ CONVERT(varchar(36),NewsID,36)
   as target,NewsTitle as title,NewsContent as content,NewsID as refid 
from  dbo.News

--ͬ����̳����
insert into portal.dbo.PortalSearch(target,title,content,refid) select 'http://portal.ehighsun.com:86/showtopic-'+ CONVERT(varchar(36),tid,36)+'.aspx'
   as target,title,title as content,'00000000-0000-0000-0000-000000000000' as refid 
from  discuz.dbo.dnt_topics

--��PortalChannelItem���д���insert������ 
CREATE TRIGGER T_INSERT_PortalChannelItem 
       On dbo.PortalChannelItem                      
instead of insert 
AS 
BEGIN
insert into dbo.PortalChannelItem(ChannelItemID,ItemName,ItemContent,ChannelID,CreateUser,UpdateUser,CreateTime,UpdateTime,ItemSubject,ItemCategoryID,MenuID,QueryKey,IsPublish)
select * from inserted
 insert into dbo.PortalSearch(target,title,content,refid) select '../PortalManage/ItemView.aspx?id='+ CONVERT(varchar(36),ChannelItemID,36)
as target,ItemName as title,ItemContent as content,ChannelItemID as refid 
from inserted
end
go



--��News���д���insert������ 
CREATE TRIGGER T_INSERT_News 
       On dbo.News                       
instead of insert
 as 
BEGIN
insert into dbo.News(NewsID,NewsTitle,NewsContent,NewsType,IsTopNews,CreateTime,PublishTime,ISAudited,ImageUrl,CreateUser,UpdateUser,UpdateTime,OrderIndex)
select * from inserted
 insert into dbo.PortalSearch(target,title,content,refid) select '../PortalManage/NewsView.aspx?id='+ CONVERT(varchar(36),NewsID,36)
as target,NewsTitle as title,NewsContent as content,NewsID as refid 
from inserted
end
go
 
 
 --��discuz��topic���д���insert������
 CREATE TRIGGER T_INSERT_dnt_topics
       On discuz.dbo.dnt_topics                    
for insert
 as 
BEGIN
 insert into Portal.dbo.PortalSearch(target,title,content,refid) select 'http://portal.ehighsun.com:86/showtopic-'+ CONVERT(varchar(36),tid,36)+'.aspx'
as target,title as title,title as content,'00000000-0000-0000-0000-000000000000' as refid 
from inserted
end
go

CREATE TRIGGER T_DELETE_PortalChannelItem 
       On dbo.PortalChannelItem                         --��PortalChannelItem���д���delete������ 
instead of delete 
AS 
BEGIN
 

delete from dbo.PortalChannelItem where ChannelItemID = (select ChannelItemID from deleted)
delete from dbo.PortalSearch where dbo.PortalSearch.refid = (select ChannelItemID from deleted)

end
go


CREATE TRIGGER T_DELETE_News 
       On dbo.News                         --��News���д���delete������ 
instead of delete
AS 
BEGIN
delete from dbo.News where News.NewsID=(select NewsID from deleted)
delete from  dbo.PortalSearch where PortalSearch.refid=(select NewsID from deleted)
end
go

 