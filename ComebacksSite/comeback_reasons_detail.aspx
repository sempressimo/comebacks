<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="comeback_reasons_detail.aspx.cs" Inherits="ComebacksSite.comeback_reasons_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

<div>

    <form runat="server">

        <div class="jumbotron">

            <p>Comeback Reason Details</p>

            <div class="input-group">
                <span class="input-group-addon">Reason</span>
                <input id="txtReason" type="text" class="form-control"
                    placeholder="Enter reason for comeback.." />
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
                <asp:LinkButton ID="lbSubmit" CssClass="btn btn-primary btn-lg" runat="server">Submit</asp:LinkButton>
                <asp:LinkButton ID="lbCancel" CssClass="btn btn-default btn-lg" runat="server">Cancel</asp:LinkButton>
            </div>

            <br/>

        </div>

    </form>

</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
