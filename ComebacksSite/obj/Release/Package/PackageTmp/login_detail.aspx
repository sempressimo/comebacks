<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login_detail.aspx.cs" Inherits="ComebacksSite.login_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div>

    <form runat="server">

        <div style="background-color: white !important" class="jumbotron">

            <h2>Login Account Details</h2>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

            <div class="input-group">
                <span class="input-group-addon">Username</span>
                <input runat="server" id="txtUsername" type="text" class="form-control"
                    placeholder="Name for login.." />
            </div>
        
            <br />

            <div class="input-group">
                <span class="input-group-addon">Password</span>
                <input runat="server" id="txtPassword" type="text" class="form-control"
                    placeholder="Secret password.." />
            </div>
        
            <br />

            <div class="input-group">
               <span class="input-group-addon">
                  <input type="checkbox" runat="server"/>
               </span>
               <input id="cbIsActive" type="text" class="form-control" disabled="disabled" placeholder="Is Active"/>
            </div>
        
            <br />

            <div class="btn-group pull-right">
                <asp:LinkButton ID="lbSubmit" OnClick="lbSubmit_Click" CssClass="btn btn-primary btn-lg" runat="server">Submit</asp:LinkButton>
                <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" CssClass="btn btn-default btn-lg" runat="server">Cancel</asp:LinkButton>
            </div>

            <br/>

        </div>

    </form>

</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
