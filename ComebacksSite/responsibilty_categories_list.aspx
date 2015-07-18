<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="responsibilty_categories_list.aspx.cs" Inherits="ComebacksSite.responsibilty_categories_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="background-color: white !important" class="jumbotron">

        <h2>Responsibility Categories List</h2>

        <form id="form_default" runat="server">
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

            <div class="panel panel-default">
                <div class="panel-body">
                    
                    <div id="custom-search-input">
                        <div class="input-group col-md-12">
                            <input id="txtSearch" runat="server" type="text" class="form-control input-lg" placeholder="Buscar" />
                            <span class="input-group-btn">
                            <button id="cmdSearch" onserverclick="cmdSearch_ServerClick" runat="server" class="btn btn-info btn-lg" type="button">
                                <i class="glyphicon glyphicon-search"></i>
                            </button>
                            </span>
                        </div>
                    </div>

                </div>
            </div>

            <div class="panel panel-default">

                <div class="panel-body">

                    <asp:LinkButton ID="lbNewRecord" OnClick="lbNewRecord_Click" CausesValidation="false" runat="server" CssClass="btn btn-success"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>&nbsp;New Record</asp:LinkButton>

                    <div class="table-responsive">
                        <asp:GridView ID="gvRecords" Width="100%" runat="server" DataKeyNames="ProblemResponsibilityCategory_ID" CssClass="table table-striped table-bordered table-condensed" EmptyDataText="There are no comebacks." OnRowCommand="gvRecords_RowCommand" OnRowDeleting="gvRecords_RowDeleting1" AutoGenerateColumns="False">
                        <Columns>
                        <asp:ButtonField CommandName="Open" Text="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i> Open" ControlStyle-CssClass="btn btn-info" >
<ControlStyle CssClass="btn btn-info"></ControlStyle>
                            </asp:ButtonField>
                        <asp:ButtonField CommandName="Delete" Text="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i> Delete" ControlStyle-CssClass="btn btn-danger" >
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
                            </asp:ButtonField>
                            <asp:BoundField DataField="ProblemResponsibilityCategory_Description" HeaderText="Category Description" />
                            <asp:BoundField DataField="IsActive" HeaderText="Active" />
                        </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </form>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
