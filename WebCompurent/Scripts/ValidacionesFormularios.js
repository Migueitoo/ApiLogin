// VALIDACIÓN PARA EL FORM DE CREAR USUARIO
function ValidarCreacion(event) {
    debugger;
    var numIdentificacion = document.getElementById("NumIdentificacion").value;
    var contrasena = document.getElementById("Contrasena").value;
    var nombre = document.getElementById("Nombre").value;
    var correo = document.getElementById("Correo").value;
    var direccion = document.getElementById("Direccion").value;
    var ciudad = document.getElementById("Ciudad").value;
    var telefono = document.getElementById("Telefono").value;

    //Validación campo número de identificación
    if (numIdentificacion == "") {
        alert("Debe completar campo 'Número de identificación'");
        return false;
    }
    else if (numIdentificacion.length > 15) {
        alert("El 'Número de identificación' no debe ser mayor a 15 caracteres.");
        event.preventDefault();
        return false;
    }
    //Validación contraseña
    if (contrasena == "") {
        alert("Debe ingresar la contraseña");
        event.preventDefault();
        return false;
    }
    else if (contrasena.length > 20) {
        alert("La contraseña no debe ser mayor a 20 caracteres");
        event.preventDefault();
        return false;
    }
    //Validación nombre
    if (nombre == "") {
        alert("Debe completar campo 'Nombre'");
        event.preventDefault();
        return false;
    }
    else if (nombre.length > 50) {
        alert("El nombre no debe ser mayor a 50 caracteres");
        event.preventDefault();
        return false;
    }
    //Validación correo 
    if (correo == "") {
        alert("Debe completar campo 'Correo'");
        event.preventDefault();
        return false;
    }
    else if (correo.length > 50 || correo.indexOf("@") == -1) {
        alert("Por favor ingrese una dirección de correo electrónico válida (hasta 50 caracteres y que contenga '@').");
        event.preventDefault();
        return false;
    }
    //Validación dirección
    if (direccion == "") {
        alert("Debe completar campo 'Dirección'");
        event.preventDefault();
        return false;
    }
    if (direccion.length > 300) {
        alert("La dirección no debe ser mayor a 300 caracteres");
        event.preventDefault();
        return false;
    }
    //Validación ciudad
    if (ciudad.length > 20) {
        alert("La ciudad no debe ser mayor a 20 caracteres.");
        event.preventDefault();
        return false;
    }
    //Validación teléfono
    if (telefono.length > 20) {
        alert("El teléfono no debe ser mayor a 20 caracteres.");
        event.preventDefault();
        return false;
    }
    return true;
}
//VALIDACIÓN PARA FORM DEL LOGIN
function ValidarLogin(event) {
    debugger;
    var usuario = document.getElementById("Usuario").value;
    var contrasena = document.getElementById("Contrasena").value;

    //Validación campo número de identificación
    if (usuario == "") {
        alert("Debe completar campo 'Usuario'");
        event.preventDefault();
        return false;
    }
    if (contrasena == "") {
        alert("Debe ingresar la contraseña");
        event.preventDefault();
        return false;
    }
    return true;
}