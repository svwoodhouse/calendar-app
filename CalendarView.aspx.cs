using DayPilot.Utils;
using DayPilot.Web.Ui;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CalendarView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime baseDate = DateTime.Today;
        var today = baseDate;
        var weekStart = baseDate.AddDays((int)baseDate.DayOfWeek -2);

        if (!IsPostBack)
        {
            DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(weekStart);
            DayPilotCalendar1.DataSource = dbGetEvents(DayPilotCalendar1.StartDate, DayPilotCalendar1.Days);
            DataBind();
        }
    }

    protected void DayPilotCalendar1_EventMove(object sender, DayPilot.Web.Ui.Events.EventMoveEventArgs e)
    {
        dbUpdateEvent(e.Value, e.NewStart, e.NewEnd);
        DayPilotCalendar1.DataSource = dbGetEvents(DayPilotCalendar1.StartDate, DayPilotCalendar1.Days);
        DayPilotCalendar1.DataBind();
        DayPilotCalendar1.Update();
    }

    private DataTable dbGetEvents(DateTime start, int days)
    {
        string conStr = null;
        conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\i861570\\Documents\\Visual Studio 2017\\WebSites\\TimeSheet\\App_Data\\Database.mdf;Integrated Security = True;";
        SqlDataAdapter da = new SqlDataAdapter(@"SELECT [EventID], [StartTime], [EndTime], [Name] FROM [dbo].[Events], [dbo].[Table] WHERE [dbo].[Events].[EmployeeID] = [dbo].[Table].[EmployeeID] AND NOT (([EndTime] <= @start) OR ([StartTime] >= @end))", conStr);
        da.SelectCommand.Parameters.AddWithValue("start", start);
        da.SelectCommand.Parameters.AddWithValue("end", start.AddDays(days));
        DataTable datTable = new DataTable();
        da.Fill(datTable);
        return datTable;
    }

    private void dbUpdateEvent(string id, DateTime start, DateTime end)
    {
        string connStr = null;
        connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\i861570\\Documents\\Visual Studio 2017\\WebSites\\TimeSheet\\App_Data\\Database.mdf;Integrated Security = True;";
        using (SqlConnection con = new SqlConnection(connStr))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Events] SET [StartTime] = @start, [EndTime] = @end WHERE [EventID] = @id", con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("start", start);
            cmd.Parameters.AddWithValue("end", end);
            cmd.ExecuteNonQuery();
        }
    }

    protected void DayPilotCalendar1_Command(object sender, DayPilot.Web.Ui.Events.CommandEventArgs e)
    {
        switch (e.Command)
        {
            case "navigate":
                DateTime start = (DateTime)e.Data["start"];
                DayPilotCalendar1.StartDate = start;
                DayPilotCalendar1.DataSource = dbGetEvents(DayPilotCalendar1.StartDate, DayPilotCalendar1.Days);
                DayPilotCalendar1.DataBind();
                DayPilotCalendar1.Update(DayPilot.Web.Ui.Enums.CallBackUpdateType.Full);
                break;
        }
    }
}