﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ComebacksSite._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="background-color: white !important" class="jumbotron">
        <h2>Comeback List</h2>

        <form id="form_default" runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

            <div class="panel panel-default">
                <div class="panel-body">
                    <a href="default.aspx?mode=pending">Pending Check <span class="badge">
                        <asp:Label ID="lblPending" runat="server" Text="Label"></asp:Label></span></a>
                    &nbsp;|&nbsp;
                    <a href="default.aspx?mode=new">New <span class="badge ">
                        <asp:Label ID="lblNew" runat="server" Text="0"></asp:Label></span></a>
                    &nbsp;|&nbsp;
                    <a href="default.aspx?mode=parts">Parts Input <span class="badge ">
                        <asp:Label ID="lblParts" runat="server" Text="0"></asp:Label></span></a>

                    <a href="default.aspx?mode=parts" class="pull-right">Closed <span class="badge ">
                        <asp:Label ID="Label1" runat="server" Text="0"></asp:Label></span></a>
                    <br/><br/>

                    <div class="table-responsive">
                        <asp:GridView ID="gvRecords" DataKeyNames="Comeback_ID" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="bs-pagination" Width="100%" runat="server" CssClass="table table-striped table-bordered table-condensed" EmptyDataText="There are no comebacks." OnRowCommand="gvRecords_RowCommand" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnPageIndexChanging="gvRecords_PageIndexChanging">
                        <Columns>
                        <asp:ButtonField Text="Open" CommandName="Open" ControlStyle-CssClass="btn btn-info" >
                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                            </asp:ButtonField>
                            <asp:BoundField DataField="RO_Number" HeaderText="RO #" />
                            <asp:BoundField DataField="OpenDate" DataFormatString="{0:d}" HeaderText="Open Date" />
                            <asp:BoundField DataField="CloseDate" DataFormatString="{0:d}" HeaderText="Closed Date" />
                            <asp:BoundField DataField="VIN" HeaderText="Serial #" />
                            <asp:BoundField DataField="Model" HeaderText="Car Model" />
                        </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </form>

    </div>
</asp:Content>
