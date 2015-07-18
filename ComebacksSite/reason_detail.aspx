<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reason_detail.aspx.cs" Inherits="ComebacksSite.reason_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

    <div style="background-color: white !important" class="jumbotron">

        <h2>Comeback Reason Details</h2>

        <form runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

            <div class="form-group">
                <label>Reason Description</label>
                <input runat="server" type="text" class="form-control" id="txtReasonDescription" placeholder="Reason description...">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Responsible Category</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="cmbResponsible" />
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
