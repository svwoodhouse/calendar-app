<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CalendarView.aspx.cs" Inherits="CalendarView" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script src="js/daypilot/daypilot-all.min.js" type="text/javascript"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DayPilot Pro Calendar Tutorial</title>
</head>
<body style="height: 626px">
        <form id="form1" runat="server">
            <div id="dp"></div>

            <daypilot:daypilotcalendar 
     id="DayPilotCalendar1" 
     runat="server" 
     DataStartField="StartTime" 
     DataEndField="EndTime"
     DataTextField="Name"
     DataValueField="EventID" 
     Days="7" 
     OnEventMove="DayPilotCalendar1_EventMove" 
     EventMoveHandling="CallBack" CssClass="auto-style1" style="left: 0px; top: 0px; width: 100%" HeightSpec="Full"
     >
    </daypilot:daypilotcalendar>

        </form>
</body>
</html>


