<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="comeback_detail.aspx.cs" Inherits="ComebacksSite.comeback_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

<div style="background-color: white !important" class="jumbotron">

    <h2>Comeback Reason List</h2>

    <br/>

    <form id="form_default" runat="server">

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <div class="container-fluid">

            <div class="row">
        
                <div class="col-lg-8">
                    
                        <div class="list-group">

                            <a href="#" class="list-group-item active">
                            RO Information
                            </a>
                            <br/>
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-lg-6">
                                        
                                        <div class="form-group">
                                        <label for="exampleInputEmail1">RO Number</label>
                                        <input id="txtRONumber" runat="server" type="text" disabled="disabled" class="form-control">
                                        </div>
                                        <div class="form-group">
                                        <label>Serial</label>
                                        <input id="txtSerial" runat="server" type="text" disabled="disabled" class="form-control">
                                        </div>
                                        <div class="form-group">
                                        <label>Car Model</label>
                                        <input id="txtModel" runat="server" type="text" disabled="disabled" class="form-control">
                                        </div>
                                        <div class="form-group">
                                        <label>Open Date</label>
                                        <input id="txtOpenDate" runat="server" type="text" disabled="disabled" class="form-control">
                                        </div>
                                        <div class="form-group">
                                        <label>Closed Date</labe>
                                        <input id="txtClosedDate" runat="server" type="text" disabled="disabled" class="form-control">
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                                                            
                                        <div class="form-group">
                                        <label>Technitian Notes</label>
                                        <textarea id="txtNotes" runat="server" rows="3" placeholder="Comeback explanation..." class="form-control" required="required"></textarea>
                                        </div>

                                        <div class="form-group">
                                        <label  >Set Status</label>
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="cmbStatus" >
                                            <asp:ListItem Value="1">Is Comeback</asp:ListItem>
                                            <asp:ListItem Value="2">Not Comeback</asp:ListItem>
                                            <asp:ListItem Value="3">Needs Parts Specialist Input</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group">
                                        <label  >Parts Specialist Notes</label>
                                        <textarea rows="3" placeholder="Comeback explanation..." class="form-control" required="required"></textarea>
                                        </div>

                                        <div class="form-group">
                                            <asp:LinkButton ID="lbSave" runat="server" CssClass="btn btn-success" OnClick="lbSave_Click">Save</asp:LinkButton>
                                            <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn btn-default" OnClick="LinkButton1_Click">Cancel</asp:LinkButton>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                </div>
                
                <div class="col-lg-4">
                        
                        <div class="list-group">
                            <a href="#" class="list-group-item active">
                            Customer Details
                            </a>
                            
                            <br/>
                            <div class="form-group">
                            <label>Customer Name</label>
                            <input id="txtCustomerName" runat="server" type="text" class="form-control" disabled="disabled">
                            </div>
                            <div class="form-group">
                            <label>Main Phone</label>
                            <input id="txtMainPhone" runat="server" type="text" class="form-control" disabled="disabled">
                            </div>
                            <div class="form-group">
                            <label>Work Phone</label>
                            <input id="txtWorkPhone" runat="server" type="text" class="form-control"  disabled="disabled">
                            </div>
                            </div>
                        </div>
            
                </div>

            </div>

        </div>

    </form>

</div> <!-- jumbotron -->

    </label>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
