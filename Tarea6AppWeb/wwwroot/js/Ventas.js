class Ventas {

    constructor() {
    }


    ListaCliente() {

        var html = "<option values=0>Seleccione una opcion</option>";
        $.get("../../clientes/ListaCliente", (data) => {
            data.forEach((valor) => {
                html += `<option value=${valor.idCliente}>${valor.nombre}</option>`


            })


            $("#Clientes").html(html)
        })

    }

    unCliente(id) {

        $.get("../../clientes/unCliente?id=" + id, (cliente) => {

            $("#nombreCliente").val(cliente.nombre)
            $("#correoCliente").val(cliente.email)
            $("#telefonoCliente").val(cliente.telefono)

        })

    }

    nuevoCliente() {

        $("#nombreCliente").prop("disabled", false)
        $("#correoCliente").prop("disabled", false)
        $("#telefonoCliente").prop("disabled", false)
        $("#Clientes").prop("disabled", true)
        $("#nuevoCliente").val(1)
        $("#cancelar").css("display", "block")
    }


    limpiarCampos() {

        $("#nombreCliente").prop("disabled", true)
        $("#correoCliente").prop("disabled", true)
        $("#telefonoCliente").prop("disabled", true)
        $("#Clientes").prop("disabled", false)
        $("#nuevoCliente").val(0)
        $("#cancelar").css("display", "none")
    }


    listaProductos() {

        var html = "";
        $.get("../../celulares/listaCelulares", (listacelulares) => {
            console.log(listacelulares)

            $.each(listacelulares, (index, producto) => {
                console.log(producto)

                html += `<tr>
                <td>${index + 1}</td>
                <td>${producto.marca} </td>
                <td>${producto.modelo} </td>
                <td>${producto.precio} </td>  
                `
            })
            $("#cuerpoproducto").html(html)
        })
    }
}
               