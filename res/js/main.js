$(document).ready(function () {
    get(null); //getAll

    $('#searchBtn').click(function () {
        const search = $('#searchInp').val();
        if (search.trim() === '') {
            alert('El campo de búsqueda no puede estar vacío');
            return;
        }
        get(search);

    });

    $('#addCustomerForm').on("submit", function (event) {
        event.preventDefault();
        post($('#customerID').val(), $('#nombreInp').val(), $('#primerAppInp').val(), $('#segundoAppInp').val(), $('#identificacionInp').val(), $('#telefonoInp').val(),
            $('#direccionInp').val(), $('#customerID').val() === '0' ? 0 : 1);
        
        
    });

    $('#newBtn').click(function () {
        //$("#addEditCustomerModal").modal('show');
        $('#customerID').val('0');
        $('#nombreInp').val('');
        $('#primerAppInp').val('');
        $('#segundoAppInp').val('');
        $('#identificacionInp').val('');
        $('#telefonoInp').val('');
        $('#direccionInp').val('');
        
    });
    
})

const remove = (pa) => {
    if (confirm("Está seguro que desea eliminar la fila seleccionada?")) {
        const id = pa.id.split('_')[1];
        post(id, null, null, null, null, null, null, 2);

    }

}

const edit = (pa) => {
    //fill inputs
    //console.log(pa.parentNode);
    const temp = pa.parentNode.childNodes;

    const nombre = temp[1].childNodes[0].nodeValue;
    const primerAp = temp[2].childNodes[0].nodeValue;
    const segundoAp = temp[3].childNodes.length ? temp[3].childNodes[0].nodeValue : null;
    const identificacion = temp[4].childNodes[0].nodeValue;
    const telefono = temp[5].childNodes[0].nodeValue;
    const direccion = temp[6].childNodes.length ? temp[6].childNodes[0].nodeValue :null;
    const id = temp[7].childNodes[0].nodeValue;

    $('#customerID').val(id);
    $('#nombreInp').val(nombre);
    $('#primerAppInp').val(primerAp);
    $('#segundoAppInp').val(segundoAp);
    $('#identificacionInp').val(identificacion);
    $('#telefonoInp').val(telefono);
    $('#direccionInp').val(direccion);

    //console.log(nombre);
    $("#addEditCustomerModal").modal('show');

}