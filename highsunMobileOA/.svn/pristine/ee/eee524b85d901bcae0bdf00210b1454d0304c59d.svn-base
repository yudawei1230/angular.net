using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

/// <summary>
///JsonHelper 的摘要说明
/// </summary>
public class JsonHelperNew
{
    public JsonHelperNew()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static string DataTableToJSON(DataTable dt, string dtName)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);

        using (JsonWriter jw = new JsonTextWriter(sw))
        {
            JsonSerializer ser = new JsonSerializer();
            jw.WriteStartObject();
            jw.WritePropertyName(dtName);
            jw.WriteStartArray();
            foreach (DataRow dr in dt.Rows)
            {
                jw.WriteStartObject();

                foreach (DataColumn dc in dt.Columns)
                {
                    jw.WritePropertyName(dc.ColumnName);
                    ser.Serialize(jw, dr[dc].ToString());
                }

                jw.WriteEndObject();
            }
            jw.WriteEndArray();
            jw.WriteEndObject();

            sw.Close();
            jw.Close();

        }

        return sb.ToString();
    }


    public static string Dtb2Json(DataSet ds)
    {

//        {                                                      
//    "total":239,                                                      
//    "rows":
//    [                                                          
//        {"code":"001","name":"Name 1","addr":"Address 11","col4":"col4 data"},         
//        {"code":"002","name":"Name 2","addr":"Address 13","col4":"col4 data"}  
//    ]                                                          
//}                                                           


        JavaScriptSerializer jss = new JavaScriptSerializer();
        System.Collections.ArrayList dic = new System.Collections.ArrayList();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                drow.Add(dc.ColumnName, dr[dc.ColumnName]);
            } 
            dic.Add(drow);
        }
        //序列化  
        
        string json= jss.Serialize(dic);
    
    
     

        return json.ToString() ;


    }


}
