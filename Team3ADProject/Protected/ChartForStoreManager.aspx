<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChartForStoreManager.aspx.cs" Inherits="Team3ADProject.Protected.ChartForStoreManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:DropDownList ID="ChartSelect" runat="server">
	</asp:DropDownList>
	<asp:Panel ID="Panel1" runat="server">
		From<asp:TextBox ID="From" textmode="Date" runat="server" AutoPostBack="True" OnTextChanged ="ChangeROGraph"></asp:TextBox>
		To<asp:TextBox ID="To" textmode="Date" runat="server" AutoPostBack="True" OnTextChanged ="ChangeROGraph"></asp:TextBox>
		<asp:Label ID="ErrorMSg" runat="server" Text="Label"></asp:Label>
		<br />
		<asp:CheckBoxList ID="Departments" runat="server" AutoPostBack="True" OnTextChanged ="ChangeROGraph"></asp:CheckBoxList>
		<asp:Chart ID="getROBasedDepartmentAndTime" runat="server" Width="1072px">
			<Series>
				<asp:Series Name="Series1"></asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartArea1"></asp:ChartArea>
			</ChartAreas>
		</asp:Chart>
	</asp:Panel>
</asp:Content>
