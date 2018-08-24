<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>
  <title>SB Admin - Start Bootstrap Template</title>
  <!-- Bootstrap core CSS-->
  <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
  <!-- Custom fonts for this template-->
  <link href="assets/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
  <!-- Custom styles for this template-->
  <link href="assets/css/sb-admin.css" rel="stylesheet"/>
  <!--  Own styles for the page   -->
  <link href="assets/css/userStyles.css" rel="stylesheet"/>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Login</div>
      <div class="card-body">
          <div class="form-group">
            <label for="txtLoginUsername">Username</label>
            <asp:TextBox class="form-control" id="txtLoginUsername" type="text"  placeholder="Username" runat="server"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="txtLoginPassword">Password</label>
            <asp:TextBox class="form-control" id="txtLoginPassword" type="password" placeholder="Password" runat="server"></asp:TextBox>
          </div>
          <asp:Button ID="btnLogin" type="Submit" class="btn btn-primary btn-block" href="index.aspx" Text="Login" Onclick="btnLogin_Click" runat="server"/>
        <div class="container register">
            <div class="text-center">
                <a class="nav-link d-block small mt-3" data-toggle="modal" data-target="#registerModal" data-backdrop="static" data-keyboard="false" style="color: #007bff;" >Register
                    <i class="fas fa-arrow-circle-down"></i> 
                </a>
            </div>
        </div>
      </div>
    </div>
  </div>
        <div class="container">
            <!-- Logout Modal-->
    <div class="modal fade" id="registerModal" tabindex="-1" role="dialog" aria-labelledby="registerModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title center" id="registerModalLabel">Register New User</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="form-group">
                <asp:TextBox type="text" class="form-control" id="txtRegisterName" placeholder="Nombre" runat="server"></asp:TextBox> 
            </div>
            <div class="form-group">
                <asp:TextBox type="text" class="form-control" id="txtRegisterLastName" placeholder="Primer apellido" runat="server"></asp:TextBox> 
            </div>
            <div class="form-group">
                <asp:TextBox type="text" class="form-control" id="txtRegisterSecondSurname" placeholder="Segundo apellido" runat="server"></asp:TextBox> 
            </div>
             <div class="form-group">
                <asp:TextBox type="number" class="form-control" id="txtRegisterCedula" placeholder="Cedula" runat="server"></asp:TextBox> 
            </div>
            <div class="form-group">
                <asp:TextBox type="email" class="form-control" id="txtRegisterEmail" placeholder="Correo" runat="server"></asp:TextBox> 
            </div>
            <div class="form-group">
                <asp:TextBox type="text" class="form-control" id="txtRegisterUsername" placeholder="Usuario" runat="server"></asp:TextBox> 
            </div>
            <div class="form-group">
                <asp:TextBox type="password" class="form-control" id="txtRegisterPassword" placeholder="Password" runat="server"></asp:TextBox> 
            </div>
          </div>
          <div class="modal-footer">
            <asp:Button ID="btnRegisterCancel" class="btn btn-secondary"  OnClick="btnRegisterCancel_Click"  Text="Cancel"  runat="server"/>
            <asp:Button ID="btnRegisterNewUser" class="btn btn-primary" Text="Register" OnClick="btnRegisterNewUser_Click" runat="server" />
          </div>
        </div>
      </div>
    </div>
        </div>
    </form>
  <!-- Bootstrap core JavaScript-->
  <script src="assets/vendor/jquery/jquery.min.js"></script>
  <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- Core plugin JavaScript-->
  <script src="assets/vendor/jquery-easing/jquery.easing.min.js"></script>

    <script defer src="https://use.fontawesome.com/releases/v5.0.10/js/all.js" integrity="sha384-slN8GvtUJGnv6ca26v8EzVaR9DC58QEwsIk9q1QXdCU8Yu8ck/tL/5szYlBbqmS+" crossorigin="anonymous"></script>
</body>
</html>
