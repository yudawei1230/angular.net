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
	public partial class Complaint
	{
		/// <summary>
		/// 
		/// </summary>
		private int iD; 
		/// <summary>
		/// 
		/// </summary>
		private string category = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string ask = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private DateTime askTime;
		/// <summary>
		/// 
		/// </summary>
		private string realName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string phone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string img0 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string img1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string img2 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private string askDetail = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private DateTime answerTime;
		/// <summary>
		/// 
		/// </summary>
		private string answerDetail = String.Empty;
		/// <summary>
		/// 
		/// </summary>
		private bool isExamine;
		/// <summary>
		/// 
		/// </summary>
		private bool isDel;

		
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public Complaint() { }
		
		
	
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
		public string Category
		{
			get { return this.category; }
			set { this.category = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Ask
		{
			get { return this.ask; }
			set { this.ask = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public DateTime AskTime
		{
			get { return this.askTime; }
			set { this.askTime = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string RealName
		{
			get { return this.realName; }
			set { this.realName = value; }
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
		public string Img0
		{
			get { return this.img0; }
			set { this.img0 = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Img1
		{
			get { return this.img1; }
			set { this.img1 = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string Img2
		{
			get { return this.img2; }
			set { this.img2 = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string AskDetail
		{
			get { return this.askDetail; }
			set { this.askDetail = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public DateTime AnswerTime
		{
			get { return this.answerTime; }
			set { this.answerTime = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public string AnswerDetail
		{
			get { return this.answerDetail; }
			set { this.answerDetail = value; }
		}		
		
		/// <summary>
		/// 
		/// </summary>
		[Column]
		public bool IsExamine
		{
			get { return this.isExamine; }
			set { this.isExamine = value; }
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