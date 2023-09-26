using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{

    public partial class ExpenseCollection_Base
    {
        public DataTable GetExpensFianceGroup(int jfCaseTypeID)
        {
            string whereSql = "";
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            //if (string.IsNullOrWhiteSpace(orderBySql))
            //{
            //    orderBySql = "Order By SortOrder ";
            //}
            //else
            //{
            //    orderBySql = "Order By " + orderBySql;

            //}
            if (jfCaseTypeID != 0)
            {
                sqlParameter.Add(new SqlParameter("@JFCaseTypeID", System.Data.SqlDbType.Int) { Value = jfCaseTypeID });
                whereSql = " AND JFCaseTypeID=@JFCaseTypeID ";
            }          

            string sql = "SELECT Expense.ExpenseID,Expense.ExpenseName,ISNULL([ExpenseMapFinance].JFCaseTypeID,0)AS JFCaseTypeID " +
                " , ISNULL([Expense].IsOther,0) AS IsOther, ISNULL([ExpenseMapFinance].SortOrder,0) AS SortOrder FROM Expense LEFT OUTER JOIN[dbo].[ExpenseMapFinance] ON Expense.ExpenseID =[ExpenseMapFinance].ExpenseID " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetExpensJFCaseGroup(int jfCaseTypeID)
        {
            string whereSql = "";
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            if (jfCaseTypeID != 0)
            {
                sqlParameter.Add(new SqlParameter("@JFCaseTypeID", System.Data.SqlDbType.Int) { Value = jfCaseTypeID });
                whereSql = " AND JFCaseTypeID=@JFCaseTypeID ";
            }

            string sql = "SELECT Expense.ExpenseID,Expense.ExpenseName,ISNULL([ExpenseMapJFCase].JFCaseTypeID,0)AS JFCaseTypeID " +
                " , ISNULL([Expense].IsOther,0) AS IsOther, ISNULL([ExpenseMapJFCase].SortOrder,0) AS SortOrder FROM Expense LEFT OUTER JOIN[dbo].[ExpenseMapJFCase] ON Expense.ExpenseID =[ExpenseMapJFCase].ExpenseID " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        } 
      

    }
}

