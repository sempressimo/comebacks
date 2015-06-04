<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="sub_reasons_list.aspx.cs" Inherits="ComebacksSite.sub_reasons_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

<form runat="server" class="form-horizontal" role="form">

    <div class="jumbotron">

        <h2>Sub Reasons List</h2>

        <div id="custom-search-input">
            <div class="input-group col-md-12">
                <input type="text" class="form-control input-lg" placeholder="Buscar" />
                <span class="input-group-btn">
                <button class="btn btn-info btn-lg" type="button">
                    <i class="glyphicon glyphicon-search"></i>
                </button>
                </span>
            </div>
        </div>

        <p/>

        <div class="panel panel-default">

            <div class="panel-body">

                <asp:LinkButton ID="lbNewRecord" OnClick="lbNewRecord_Click" CausesValidation="false" runat="server" CssClass="btn btn-success"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>&nbsp;New Record</asp:LinkButton>

                <div class="table-responsive">
                    <asp:GridView ID="gvRecords" Width="100%" runat="server" DataKeyNames="Username" CssClass="table table-striped table-bordered table-condensed" EmptyDataText="There are no comebacks." OnRowCommand="gvRecords_RowCommand" OnRowDeleting="gvRecords_RowDeleting">
                    <Columns>
                    <asp:ButtonField CommandName="Open" Text="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i> Open" ControlStyle-CssClass="btn btn-info" />
                    <asp:ButtonField CommandName="Delete" Text="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i> Delete" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                    </asp:GridView>
                </div>

            </div>

        </div>

    </div>

</form>
   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
