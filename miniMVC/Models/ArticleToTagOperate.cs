﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class ArticleToTagOperate
    {
        public void insert(ArticleToTagModel data)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "insert into ArticleToTag (Article_Id,Tag_Id) Values(@aArticle_Id,@aTag_Id)";
            SqlCommand cmd = new SqlCommand(sqlStr, con);

            
            cmd.Parameters.AddWithValue("@aArticle_Id", data.Article_Id);
            cmd.Parameters.AddWithValue("@Tag_Id", data.Tag_Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public List<ArticleToTagModel> select(int wh,int id)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "";
            if (wh == 0)
            {
                sqlStr = "select * from Board where Article_Id=1";
            }
            if (wh == 1)
            {
                sqlStr = "select * from Board where Tag_Id=1";
            }

            SqlCommand cmd = new SqlCommand(sqlStr, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ArticleToTagModel> Li = new List<ArticleToTagModel>();
            while (reader.Read())
            {
                int aAId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Article_Id")));
                int aTId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Tag_Id")));

                Li.Add(new ArticleToTagModel { Article_Id = aAId, Tag_Id = aTId });
            }

            con.Close();

            return Li;
        }
    }
}