﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemPage.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.ItemPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center" style="margin-top:2%">
    <img class="card-img-top" src="<%= item.UrlImage %>" onerror="this.src='Images/default.png'" alt="<%= item.Name %>" style="max-width: 200px; max-height: 200px; margin: 0 auto; display: block; object-fit: contain;">

        <div class="card-body">
            <h5 class="card-title"><%= item.Name %></h5>
            <p class="card-text"><%= item.Description %></p>
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item">Precio: <%= string.Format("{0:0.00}", item.Price) %></li>
            <li class="list-group-item"><%= item.TradeDesciption.TradeDescription %></li>
            <li class="list-group-item"><%= item.CategoryDescription.CategoryDescription %></li>
        </ul>
        <div class="card-body">
            <%--<asp:CheckBox CssClass="heart-checkbox" AutoPostBack="true" Text="Add Favorites" ID="cbxAddFavorites" OnCheckedChanged="cbxAddFavorites_CheckedChanged" runat="server" />--%>
            <asp:ImageButton ID="ImageButton" ImageUrl="~/Images/heartEmpty.png" runat="server" OnClick="ImageButton_Click" Height="20px" Width="20px" />
        </div>
    </div>

</asp:Content>
