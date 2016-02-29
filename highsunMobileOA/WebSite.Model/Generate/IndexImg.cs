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
	public partial class IndexImg
	{
		/// <summary>
		/// 规划业态
		/// </summary>
		private int iD; 
		/// <summary>
		/// 
		/// </summary>
		private string img = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string link = String.Empty;
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
		public IndexImg() { }
		
		
	
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
		public string Img
		{
			get { return this.img; }
			set { this.img = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Link
		{
			get { return this.link; }
			set { this.link = value; }
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
