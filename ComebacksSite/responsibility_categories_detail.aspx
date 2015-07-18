<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="responsibility_categories_detail.aspx.cs" Inherits="ComebacksSite.responsibility_categories_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

    <div style="background-color: white !important" class="jumbotron">

        <h2>Responsibility Categories Details</h2>

        <form runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

            <div class="form-group">
                <label>Category Description</label>
                <input runat="server" type="text" class="form-control" id="txtDescription" placeholder="Category description...">
            </div>
            <div class="checkbox">
            <label>
                <input runat="server" id="cbIsActive" type="checkbox" checked="checked"> Active
            </label>
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
