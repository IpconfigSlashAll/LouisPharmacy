<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Project.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Home
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="demo" class="carousel slide" data-bs-ride="carousel">

  <!-- Indicators/dots -->
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#demo" data-bs-slide-to="0" class="active"></button>
    <button type="button" data-bs-target="#demo" data-bs-slide-to="1"></button>
    <button type="button" data-bs-target="#demo" data-bs-slide-to="2"></button>
  </div>

  <!-- The slideshow/carousel -->
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="/images/louisplaceholder.png" alt="Louis' Pharmacy" class="d-block mx-auto p-2" style="width: 400px; height: auto; border-radius: 10px; box-shadow: 2px 2px 10px rgba(0,0,0,0.2);">
        <div class="carousel-caption text-light">
            <h3 style="color:black">Welcome to Louis' Pharmacy!</h3> 
            <p style="color:black"><b>Pay the bills, get the pills.</b></p>
        </div>
    </div>
    <div class="carousel-item">
  <img src="/images/Jameson.jpg" alt="item 2" class="d-block mx-auto" style="max-width: 500px; height: auto; border-radius: 10px; box-shadow: 2px 2px 10px rgba(0,0,0,0.2);">
        
        <!-- Contact Information and DCS Section under Item 2 -->
        <div class="container text-center mt-3">
            <h3>Contact Information</h3>
            <p><strong>Name:</strong> Dr. Jameson McFarlane</p>
            <p><strong>Email:</strong> jameson.Mcfarlane@example.com</p>
            <p><strong>Phone:</strong> (610) 987-6543</p>
            <p><strong>Address:</strong> 158 Tech Lane, Lancaster, PA 17602</p>

            <h3>Doctor of Computer Science (DCS)</h3>
            <p><strong>University:</strong> MIT</p>
            <p><strong>Year Completed:</strong> 2010</p>
            <p><strong>Specialty:</strong> Making Student Think???</p>
            <p><strong>Research Focus:</strong> See how they think</p>

            <br />
            <br />
        </div>
    </div>
    <div class="carousel-item">
<img src="/images/CNSA.jpg" alt="item 3" class="d-block mx-auto" style="width: 800px; height: auto; border-radius: 10px; box-shadow: 2px 2px 10px rgba(0,0,0,0.2);">
    </div>
  </div>

  <!-- Left and right controls/icons -->
  <button class="carousel-control-prev" type="button" data-bs-target="#demo" data-bs-slide="prev">
    <span class="carousel-control-prev-icon"></span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#demo" data-bs-slide="next">
    <span class="carousel-control-next-icon"></span>
  </button>
</div>
</asp:Content>
