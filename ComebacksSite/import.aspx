<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="import.aspx.cs" Inherits="ComebacksSite.import" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="background-color: white !important" class="jumbotron">

    <h2>Import Comebacks</h2>
                                        
    <form role="form" runat="server">
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <div class="form-group">
            <label>Choose File:</label>
            <input id="txtDescription" runat="server" type="text" class="form-control" placeholder="Enter description...">
        </div>
        <div class="form-group">
            <div class="checkbox">
                <label>
                    <input id="cbIsActive" type="checkbox" runat="server" checked="checked">
                    <span class="text">Active</span>
                </label>
            </div>
        </div>
        <div class="btn-group pull-right">
            <asp:LinkButton ID="lbSubmit" OnClick="lbSubmit_Click" CssClass="btn btn-primary btn-lg" runat="server">Submit</asp:LinkButton>
            <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" CssClass="btn btn-default btn-lg" runat="server">Cancel</asp:LinkButton>
        </div>

        <br/>
         
    </form>

</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
