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
	public partial class Market
	{
		/// <summary>
		/// 
		/// </summary>
		private int iD; 
		/// <summary>
		/// 
		/// </summary>
		private string name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string address = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private int area;
		/// <summary>
		/// 
		/// </summary>
		private string img = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string detail = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private bool isDel;
		/// <summary>
		/// 
		/// </summary>
		private int isSort;

		
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public Market() { }
		
		
	
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
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Address
		{
			get { return this.address; }
			set { this.address = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public int Area
		{
			get { return this.area; }
			set { this.area = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Img
		{
			get { return this.img; }
			set { this.img = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Detail
		{
			get { return this.detail; }
			set { this.detail = value; }
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
		
	}
}
