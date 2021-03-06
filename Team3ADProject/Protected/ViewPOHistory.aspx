﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewPOHistory.aspx.cs" Inherits="Team3ADProject.Protected.ViewPOHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Purchase Order History</h1>
    


    <table>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Supplier"></asp:Label> </td>
            <td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="PO Number"></asp:Label> </td>
            <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="Q" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter number"
    ValidationExpression="(^([0-9]*\d*\d{1}?\d*)$)" Display="Dynamic" ForeColor ="Red"></asp:RegularExpressionValidator> </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="PO Status"></asp:Label> </td>
            <td><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList> </td>
        </tr>
    </table>


    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="Button1_Click" />

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="supplier_name" HeaderText="Supplier Name">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="purchase_order_number" HeaderText="Purchase Number">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="purchase_order_date" HeaderText="Purchase Date" DataFormatString="{0:dd-MM-yyyy}">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="employee_name" HeaderText="Po Placed By">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="purchase_order_status" HeaderText="Purchase Order Status">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="po_total_item_count" HeaderText="Number of PO Items ">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="PO Pending Items">
                    <ItemTemplate>
                        <asp:Label ID="pendingcount" runat="server" Text="Label"></asp:Label>
                        <asp:HiddenField ID="HiddenField1" runat="server" value ='<%# Eval("purchase_order_number") %>'/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="viewpo" runat="server" CssClass="btn btn-info" Text="View PO" OnClick="viewpo_Click"/>
                        <asp:HiddenField ID="HiddenFieldPO" runat="server" Value ='<%# Eval("purchase_order_number") %>' />
                        <asp:HiddenField ID="HiddenFieldstatus" runat="server" Value='<%# Eval("purchase_order_status") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
