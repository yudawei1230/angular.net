using System;
using System.Collections.Generic;
using System.Text;
using WebSite.DbProxy;

namespace WebSite.Models
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public partial class Advert
	{
		/// <summary>
		/// 
		/// </summary>
		private int iD; 
		/// <summary>
		/// 商场
		/// </summary>
		private int marketID;
		/// <summary>
		/// 发布形式
		/// </summary>
		private int mediaSourceID;
		/// <summary>
		/// 广告名称
		/// </summary>
		private string name = String.Empty;
		/// <summary>
		/// 广告形式:户内或户外
		/// </summary>
		private bool releaseForm;
		/// <summary>
		/// 尺寸
		/// </summary>
		private string size = String.Empty;
		/// <summary>
		/// 租金
		/// </summary>
		private decimal rent;
		/// <summary>
		/// 
		/// </summary>
		private bool showRent;
		/// <summary>
		/// 位置描述
		/// </summary>
		private string position = String.Empty;
		/// <summary>
		/// 现投放广告商
		/// </summary>
		private string advertisers = String.Empty;
		/// <summary>
		/// 投放广告商显示或隐藏
		/// </summary>
		private bool showSer;
		/// <summary>
		/// 广告编号
		/// </summary>
		private string advertNo = String.Empty;
		/// <summary>
		/// 平面图
		/// </summary>
		private string plane = String.Empty;
		/// <summary>
		/// 经纪人
		/// </summary>
		private int brokerID;
		/// <summary>
		/// 
		/// </summary>
		private bool isDel;
		/// <summary>
		/// 
		/// </summary>
		private int isSort;
		/// <summary>
		/// 
		/// </summary>
		private DateTime addDate;
		/// <summary>
		/// 
		/// </summary>
		private int cTR;

		
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public Advert() { }
		
		
	
		/// <summary>
		/// Get/Set
		/// </summary>
		[Column]
		public int ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}
		 
		
		/// <summary>
		/// 商场
		/// </summary>
		[Column]
		public int MarketID
		{
			get { return this.marketID; }
			set { this.marketID = value; }
		}		
		
		/// <summary>
		/// 发布形式
		/// </summary>
		[Column]
		public int MediaSourceID
		{
			get { return this.mediaSourceID; }
			set { this.mediaSourceID = value; }
		}		
		
		/// <summary>
		/// 广告名称
		/// </summary>
		[Column]
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}		
		
		/// <summary>
		/// 广告形式:户内或户外
		/// </summary>
		[Column]
		public bool ReleaseForm
		{
			get { return this.releaseForm; }
			set { this.releaseForm = value; }
		}		
		
		/// <summary>
		/// 尺寸
		/// </summary>
		[Column]
		public string Size
		{
			get { return this.size; }
			set { this.size = value; }
		}		
		
		/// <summary>
		/// 租金
		/// </summary>
		[Column]
		public decimal Rent
		{
			get { return this.rent; }
			set { this.rent = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public bool ShowRent
		{
			get { return this.showRent; }
			set { this.showRent = value; }
		}		
		
		/// <summary>
		/// 位置描述
		/// </summary>
		[Column]
		public string Position
		{
			get { return this.position; }
			set { this.position = value; }
		}		
		
		/// <summary>
		/// 现投放广告商
		/// </summary>
		[Column]
		public string Advertisers
		{
			get { return this.advertisers; }
			set { this.advertisers = value; }
		}		
		
		/// <summary>
		/// 投放广告商显示或隐藏
		/// </summary>
		[Column]
		public bool ShowSer
		{
			get { return this.showSer; }
			set { this.showSer = value; }
		}		
		
		/// <summary>
		/// 广告编号
		/// </summary>
		[Column]
		public string AdvertNo
		{
			get { return this.advertNo; }
			set { this.advertNo = value; }
		}		
		
		/// <summary>
		/// 平面图
		/// </summary>
		[Column]
		public string Plane
		{
			get { return this.plane; }
			set { this.plane = value; }
		}		
		
		/// <summary>
		/// 经纪人
		/// </summary>
		[Column]
		public int BrokerID
		{
			get { return this.brokerID; }
			set { this.brokerID = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public bool IsDel
		{
			get { return this.isDel; }
			set { this.isDel = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public int IsSort
		{
			get { return this.isSort; }
			set { this.isSort = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public DateTime AddDate
		{
			get { return this.addDate; }
			set { this.addDate = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public int CTR
		{
			get { return this.cTR; }
			set { this.cTR = value; }
		}		
		
	}
}
