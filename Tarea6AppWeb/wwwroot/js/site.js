
$().ready(

    () => {
        ventas()
    }
);

var ventas = () => {
    var leerCliente = new Ventas()
    leerCliente.ListaCliente()
}

 var unCliente = () => {
     var id = $("#Clientes").val()   
     var uncliente = new Ventas()
     uncliente.unCliente(id)

}

var nuevoCliente = () => {
    var nuevoCliente = new Ventas()
    nuevoCliente.nuevoCliente()
}

var limpiarcajas = () => {
    var limpiarcajas = new Ventas()
    limpiarcajas.limpiarCampos()
}

var listaProductos = () => { 
    var listaProductos = new Ventas()
    listaProductos.listaProductos()
}
