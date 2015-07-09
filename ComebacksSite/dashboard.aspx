<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ComebacksSite.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <script src="Scripts/jquery-2.1.4.js"></script>
        <script src="Scripts/Highcharts-4.0.1/js/highcharts.js"></script>
    <script src="Scripts/Highcharts-4.0.1/js/modules/exporting.js"></script>
    <script src="Scripts/Highcharts-4.0.1/js/themes/grid-light.js"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

        <div style="background-color: white !important" class="jumbotron">

        <h2>Dashboard</h2>

        <form runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:label id="ltChart" runat="server"></asp:label>
                    </div>
                    <div class="col-lg-6">
                        <asp:label id="ltPieChart" runat="server"></asp:label>
                    </div>
                </div>
                <div class="row">
                
                </div>
            </div>

        </form>

        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">

    


</asp:Content>
