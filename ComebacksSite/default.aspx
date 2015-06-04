<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ComebacksSite._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="background-color: white !important" class="jumbotron">
        <h2>Comeback List</h2>

        <form id="form_default" runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gvRecords" Width="100%" runat="server" CssClass="table table-striped table-bordered table-condensed" EmptyDataText="There are no comebacks." OnRowCommand="gvRecords_RowCommand">
                        <Columns>
                        <asp:ButtonField Text="Open" ControlStyle-CssClass="btn btn-info" />
                        </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </form>

    </div>
</asp:Content>
