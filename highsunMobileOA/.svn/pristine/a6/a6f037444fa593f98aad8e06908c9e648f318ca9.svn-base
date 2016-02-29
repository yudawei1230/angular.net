using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebSite.Models;

namespace WebSite.BLL
{
    public class PublicHandler
    {
        public IList<Complaint> GetAllEntities(string AskPerson, int Top, string Range)
        {
            return new WebSite.DAL.PublicHandler().GetAllEntities(AskPerson, Top, Range);
        }
        public IList<Complaint> GetAllEntitiesByCategory(string Category, int Top)
        {
            return new WebSite.DAL.PublicHandler().GetAllEntitiesByCategory(Category, Top);
        }
        public int InsertAsk(Complaint complaint)
        {
            return new WebSite.DAL.PublicHandler().InsertAsk(complaint);
        }
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="tab">表名</param>
        /// <param name="id"></param>
        /// <param name="val">IsSort</param>
        /// <returns></returns>
        public int EditSort(string tab, int sort, int val)
        {
            return new DAL.PublicHandler().EditSort(tab, sort, val);
        }
        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="items">需要删除的项目</param>
        /// <returns>执行结果</returns>
        public int DelItems(string tab, string idGroup)
        {
            return new WebSite.DAL.PublicHandler().DelFun(tab, idGroup);
        }

        public DataTable IndustryDt()
        {
            return new WebSite.DAL.PublicHandler().IndustryDt();
        }
        public bool delIndustry(int Id)
        {
            return new WebSite.DAL.PublicHandler().delIndustry(Id);
        }
        public bool MemberIsHave(string Phone, string Pwd)
        {
            return new WebSite.DAL.PublicHandler().MemberIsHave(Phone,Pwd);
        }
        public Member MemberByPhone(string Phone)
        {
            return new WebSite.DAL.PublicHandler().MemberByPhone(Phone);
        }
        public IList<Shop> ShopByBrokerID(int BrokerID)
        {
            return new WebSite.DAL.PublicHandler().ShopByBrokerID(BrokerID);
        }
        public IList<Advert> AdvertByBrokerID(int BrokerID)
        {
            return new WebSite.DAL.PublicHandler().AdvertByBrokerID(BrokerID);
        }
        //public int addShopImg(IList<ShopImg> ShopImg)
        //{
        //    return new WebSite.DAL.PublicHandler().addShopImg(ShopImg);
        //}
        public System.Data.DataSet GetShopImgDs(string ShopID)
        {
            return new WebSite.DAL.PublicHandler().GetShopImgDs(ShopID);
        }
        public System.Data.DataSet GetAdvertImgDs(string AdvertID)
        {
            return new WebSite.DAL.PublicHandler().GetAdvertImgDs(AdvertID);
        }
        //public bool IsHaveShopImg(int ShopID, int Number)
        //{
        //    return new WebSite.DAL.PublicHandler().IsHaveShopImg(ShopID, Number);
        //}
        public int ShopImgGetID(int ShopID, int Number)
        {
            return new WebSite.DAL.PublicHandler().ShopImgGetID(ShopID, Number);
        }
        public int AdvertImgGetID(int AdvertID, int Number)
        {
            return new WebSite.DAL.PublicHandler().AdvertImgGetID(AdvertID, Number);
        }
        public IList<Market> MarketList()
        {
            return new WebSite.DAL.PublicHandler().MarketList();
        }
        public IList<MediaSource> MediaSourceList()
        {
            return new WebSite.DAL.PublicHandler().MediaSourceList();
        }
        public System.Data.DataTable MarketListByDt()
        {
            return new WebSite.DAL.PublicHandler().MarketListByDt();
        }
        public System.Data.DataTable MediaSourceByDt()
        {
            return new WebSite.DAL.PublicHandler().MediaSourceByDt();
        }
        public System.Data.DataTable IndustryListByDt()
        {
            return new WebSite.DAL.PublicHandler().IndustryListByDt();
        }
        public System.Data.DataTable MemberListByDt()
        {
            return new WebSite.DAL.PublicHandler().MemberListByDt();
        }
        public IList<IndexImg> IndexImgList()
        {
            return new WebSite.DAL.PublicHandler().IndexImgList();
        }
        public IList<Industry> IndustryList(int ParentID)
        {
            return new WebSite.DAL.PublicHandler().IndustryList(ParentID);
        }
        public IList<Shop> ShopList()
        {
            return new WebSite.DAL.PublicHandler().ShopList();
        }
        public IList<Advert> AdvertList()
        {
            return new WebSite.DAL.PublicHandler().AdvertList();
        }
        public IList<Shop> ShopList(string market, string area, string industry, string name)
        {
            return new WebSite.DAL.PublicHandler().ShopList(market, area, industry, name);
        }
        public IList<Advert> AdvertList(string market, string industry, string name)
        {
            return new WebSite.DAL.PublicHandler().AdvertList(market, industry, name);
        }
        public object DefaultShopImg(int ShopID)
        {
            return new WebSite.DAL.PublicHandler().DefaultShopImg(ShopID);
        }
        public object DefaultAdvertImg(int AdvertID)
        {
            return new WebSite.DAL.PublicHandler().DefaultAdvertImg(AdvertID);
        }
        public IList<ShopImg> GetShopImg(int ShopID)
        {
            return new WebSite.DAL.PublicHandler().GetShopImg(ShopID);
        }
        public IList<AdvertImg> GetAdvertImg(int AdvertID)
        {
            return new WebSite.DAL.PublicHandler().GetAdvertImg(AdvertID);
        }
        public System.Data.DataSet GetShopDs(string ID)
        {
            return new WebSite.DAL.PublicHandler().GetShopDs(ID);
        }
        public System.Data.DataSet GetAdvertDs(string ID)
        {
            return new WebSite.DAL.PublicHandler().GetAdvertDs(ID);
        }
        public System.Data.DataSet GetMemberDs(int ID)
        {
            return new WebSite.DAL.PublicHandler().GetMemberDs(ID);
        }
        public int UpdateShopCTR(Shop shop)
        {
            return new WebSite.DAL.PublicHandler().UpdateShopCTR(shop);
        }
        public int UpdateAdvertCTR(Advert advert)
        {
            return new WebSite.DAL.PublicHandler().UpdateAdvertCTR(advert);
        }

        public int InsertSLTradingWaterData(SLTradingWaterInfo sltradingwaterInfo)
        {
            return new WebSite.DAL.PublicHandler().InsertSLTradingWaterData(sltradingwaterInfo);
        }
    }
}
