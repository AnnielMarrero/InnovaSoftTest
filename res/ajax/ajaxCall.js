const get = (name) => {
    $.ajax({
        url: 'Default.aspx/Rutina_FTN_CLIENTES_PRUEBA_LISTA_CLIENTES',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify({ nombre: name }),
        dataType: 'json',
        success: function (result, status, xhr) {
            showTable(result.d);
        },
        error: function (result, status, errorThrown) {
            alert('Error al listar los clientes');
        }
    })
}


const showTable = (data) => {
    const customerRef = $('#bodyTable');
    customerRef.empty();
    for (let i = 0; i < data.length; i++) {
        customerRef.append(`<tr id=tr_${data[i].ID}><td style="cursor: pointer" onclick="edit(this)">Sel.</td><td>${data[i].Nombre}</td><td>${data[i].PrimerAp}</td><td>${data[i].SegundoAp}</td><td>${data[i].Identificacion}</td><td style="display: none;">${data[i].Telefono}</td><td style="display: none;">${data[i].Direccion}</td><td style="display: none;">${data[i].ID}</td><td id="td_${data[i].ID}" style="cursor: pointer" onclick="remove(this)" >Eliminar</td></tr>`);
    }
}

const post = (id, nombre, primerAp, segundoApp, identificacion, telefono, direccion, opType) => {
    $.ajax({
        url: 'Default.aspx/Rutina_STPR_CLIENTES_PRUEBA_MANTENIMIENTO',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify({
            id: id, nombre: nombre, primerAp: primerAp, segundoApp: segundoApp,
            identificacion: identificacion, telefono: telefono, direccion: direccion, opType: opType
        }),
        dataType: 'json',
        success: function (result, status, xhr) {
            handleResponse(result.d, opType, id);
        },
        error: function (result, status, errorThrown) {
            alert('Error al procesar la petición, intente de nuevo');
        }
    })
}

const handleResponse = (data, opType, id) => {
    if (data.Success) {
        $("#addEditCustomerModal").modal('hide');
        if (opType === 2) {
            //remove row
            $(`#tr_${id}`).remove();
        } else {
            get(null);
        }
    } else if (data.Message.includes('Violation of UNIQUE KEY constraint')) {
        data.Message = data.Message.split('.')[0] + ". Existe un cliente con esa identificación";
    }
    //console.log(data.Message);
    alert(data.Message);
}