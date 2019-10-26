<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="practice.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Assignment 1</h2>
    <h3>Vandan Patel : 991502034</h3>
    <h3>Vivek Gupta : </h3>
    <h3>Instructor Syed </h3>
    <asp:Button ID="myBtn" runat="server" Text="Let's Begin" 
      OnClientClick="window.open('WebForm1.aspx', 'WebForm1');" />
    
</asp:Content>
