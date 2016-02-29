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
	public partial class Member
	{
		/// <summary>
		/// 规划业态
		/// </summary>
		private int iD; 
		/// <summary>
		/// 
		/// </summary>
		private int marketID;
		/// <summary>
		/// 
		/// </summary>
		private string name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string phone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string photo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string pwd = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private bool isDel;

		
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public Member() { }
		
		
	
		/// <summary>
		/// 规划业态Get/Set
		/// </summary>
		[Column]
		public int ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}
		 
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public int MarketID
		{
			get { return this.marketID; }
			set { this.marketID = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Phone
		{
			get { return this.phone; }
			set { this.phone = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Photo
		{
			get { return this.photo; }
			set { this.photo = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Pwd
		{
			get { return this.pwd; }
			set { this.pwd = value; }
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
		
	}
}
