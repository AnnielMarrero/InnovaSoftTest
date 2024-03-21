<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InnovaSoftTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link href="/res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body id="mainContent">
    <form id="form1" runat="server">
        <div>
            <div class="contenedor">

                <button id="newBtn" class="paddBtn" type="button" data-bs-toggle="modal" data-bs-target="#addEditCustomerModal">Nuevo</button>
                <button id="searchBtn" class="paddBtn" type="button" style="margin-left: 15px;">Buscar</button>
            </div>
            <br />
            <div class="contenedor">
                <span style="margin-right: 15px;">Buscar por nombre completo</span>
                <input type="text" id="searchInp" size="40" />
            </div>
            <br />
            <table id="customersTable">
                <thead>
                    <tr>
                        <th>Sel.</th>
                        <th>Nombre</th>
                        <th>Primer Apellido</th>
                        <th>Segundo Apellido</th>
                        <th>Identificación</th>
                        <th style="display: none;">Telefono</th>
                        <th style="display: none;">Direccion</th>
                        <th style="display: none;">Id</th>
                        <th>Eliminar</th>
                    </tr>
                </thead>
                <tbody id="bodyTable">
                </tbody>

            </table>

        </div>
    </form>


    <!-- Modal -->
    <div class="modal fade" id="addEditCustomerModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <%--<div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>--%>
                <div class="modal-body">
                    <form id="addCustomerForm" method="post">
                        <br />
                        <div class="contenedor" style="margin-right: 20px;">
                            <button class="paddBtn" type="button" data-bs-dismiss="modal">Cancelar</button>
                            <input class="paddBtn" type="submit" style="margin-left: 15px;" value="Guardar" />
                        </div>
                        <br />
                        <input id="customerID" type="hidden" value="0"/>
                        <div class="row">
                            <div class="col-4">Nombre</div>
                            <div class="col-8">
                                <input id="nombreInp" size="30" required maxlength="20" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">Primer Apellido</div>
                            <div class="col-8">
                                <input id="primerAppInp" size="30" required maxlength="20" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">Segundo Apellido</div>
                            <div class="col-8">
                                <input id="segundoAppInp" size="30" maxlength="20" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">Identificación</div>
                            <div class="col-8">
                                <input id="identificacionInp" size="30" required type="number" maxlength="10" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">Telefono</div>
                            <div class="col-8">
                                <input id="telefonoInp" size="30" required maxlength="10" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">Dirección</div>
                            <div class="col-8">
                                <textarea id="direccionInp" cols="28" rows="3" maxlength="50"></textarea>
                            </div>
                        </div>

                    </form>

                </div>

            </div>
        </div>
    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="/res/ajax/ajaxCall.js"></script>
    <script src="/res/js/main.js"></script>
</body>
</html>
