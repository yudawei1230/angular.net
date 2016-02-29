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
	public partial class OldProduct_Img
	{
		/// <summary>
		/// 
		/// </summary>
		private int iD; 
		/// <summary>
		/// 
		/// </summary>
		private int productID;
		/// <summary>
		/// 
		/// </summary>
		private int number;
		/// <summary>
		/// 
		/// </summary>
		private string url = String.Empty;

		
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public OldProduct_Img() { }
		
		
	
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
		/// 
		/// </summary>
		[Column]
		public int ProductID
		{
			get { return this.productID; }
			set { this.productID = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public int Number
		{
			get { return this.number; }
			set { this.number = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Url
		{
			get { return this.url; }
			set { this.url = value; }
		}		
		
	}
}
