﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClerkInventory.aspx.cs" Inherits="Team3ADProject.Protected.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlSuppliers" runat="server" Width="208px">
                    </asp:DropDownList>
                    &emsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="352px"></asp:TextBox>
                    &emsp;
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Search" />
                    &emsp;
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="View PO Staging" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Include obsolete items" />
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>


    <div>
        <asp:GridView ID="gvInventoryList" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Inventory.item_number" HeaderText="Item no." />
                <asp:BoundField DataField="Inventory.description" HeaderText="Item" />
                <asp:BoundField DataField="Inventory.category" HeaderText="Category" />
                <asp:BoundField DataField="Inventory.reorder_level" HeaderText="Reorder Level" />
                <asp:BoundField DataField="Inventory.reorder_quantity" HeaderText="Reorder Qty" />
                <asp:BoundField DataField="Inventory.current_quantity" HeaderText="Current Qty" />
                <asp:BoundField HeaderText="Ordered Qty" DataField="OrderedQty" />
                <asp:BoundField HeaderText="Pending Approval Qty" DataField="PendingApprovalQty" />
                <asp:BoundField DataField="PendingAdjustmentQty" HeaderText="Pending Adjustment Qty" />
                <asp:BoundField DataField="Inventory.unit_of_measurement" HeaderText="Unit of Measure" />
                <asp:BoundField DataField="Inventory.item_status" HeaderText="Status" />
                <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CommandName="" Text="Add to Cart" />
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("Inventory.item_number") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button2" runat="server" CausesValidation="false" CommandName="" Text="View Details"/>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Inventory.item_number") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    
</asp:Content>



