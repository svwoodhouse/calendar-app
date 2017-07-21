using Microsoft.Office.Interop.Access.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataGrid dataGridView1 = new DataGrid();
    string connStr = null;
    SqlCommand com;

    protected void Page_Load(object sender, EventArgs e)
    {
        Import_To_Grid(@"C:\Users\i861570\Documents\Visual Studio 2017\WebSites\TimeSheet\Dave's Sheet.xlsx", ".xlsx", "No");
    }

    private void Import_To_Grid(string FilePath, string Extension, string isHDR)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                         .ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                          .ConnectionString;
                break;
        }
        conStr = String.Format(conStr, FilePath, isHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;

        //Get the name of First Sheet
        connExcel.Open();
        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        //Read Data from First Sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();

        //Bind Data to GridView
        GridView1.Caption = Path.GetFileName(FilePath);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Rows[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
        GridView1.Rows[0].Style.Add(HtmlTextWriterStyle.BorderStyle ,"Solid");
        GridView1.Rows[0].Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFCC66");
        //int count = 12;
/*
        connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\i861570\\Documents\\Visual Studio 2017\\WebSites\\TimeSheet\\App_Data\\Database.mdf;Integrated Security = True;";

        foreach (GridViewRow g1 in GridView1.Rows)
        {
            SqlConnection con = new SqlConnection(connStr);

            com = new SqlCommand(@"INSERT INTO [dbo].[Table](EmployeeID,Name, Hours, PhoneNumber, Role) VALUES ('" + count + "','" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "')", con);
            count += 1;
            con.Open();

            com.ExecuteNonQuery();

            con.Close();
        }
        */
}

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
        string FileName = GridView1.Caption;
        string Extension = Path.GetExtension(FileName);
        string FilePath = Server.MapPath(FolderPath + FileName);

        Import_To_Grid(FilePath, Extension, "No");
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void Import_To_Event_Database()
    {
        DateTime baseDate = DateTime.Today;
        var today = baseDate;
        var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);

        DataTable eventDT = new DataTable();
        DataRow dr;
        eventDT.Columns.Add("EventID", typeof(int));
        eventDT.Columns.Add("StartTime", typeof(DateTime));
        eventDT.Columns.Add("EndTime", typeof(DateTime));
        eventDT.Columns.Add("EmployeeID", typeof(int));

        
    }
}