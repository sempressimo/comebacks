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

        <div class="panel">
            <div class="panel-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-3">
                            <input id="txtFrom" runat="server" type="text" class="form-control input-lg" placeholder="Fecha desde..." />
                        </div>
                        <div class="col-lg-3">
                            <input id="txtTo" runat="server" type="text" class="form-control input-lg" placeholder="Fecha hasta..." />
                        </div>
                        <div class="col-lg-6">
                            <button id="cmdSearch" onserverclick="cmdSearch_ServerClick" runat="server" class="btn btn-info btn-lg" type="button">
                                <i class="glyphicon glyphicon-search"></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <form runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel">
                            <div class="panel-body">
                                <asp:label id="ltPieChartByTech" runat="server"></asp:label>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <asp:label id="ltPieChartModel" runat="server"></asp:label>
                    </div>
                </div>
                <div class="row">
                    <asp:label id="ltChart" runat="server"></asp:label>
                </div>
            </div>

        </form>

        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">

    


</asp:Content>
