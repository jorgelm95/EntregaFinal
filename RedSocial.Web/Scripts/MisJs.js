
$(document).ready(function () {

    $('#botonIngresar').on('click', function () {

        var usuario = $("#NombreUsuarioPopup").val();
        var contra = $("#contrasenaPopup").val();

        $.post('../Usuario/Login', {
            usuario: usuario,clave: contra}, function (data) {
        
            if (data.estado !='invalido') {
                window.location.href = data.url;
               

                
          } else {
                $('#diverror').removeClass('invisible');
                $('#errorlogin').removeClass('invisible');
                $('#errorlogin').addClass('alert');
                $('#errorlogin').addClass('alert-danger');
                $('mesnajeAdvertencia').text(data.mensaje);
            }
          
        });
      
    });

});


$(document).ready(function () {

    $('#busqueda').on('focus', function(){
    
        var palabraClave = $("busqueda").val();

        $.post('../Usuario/BuscarAmigos', { nombre: palabraClave }, function (data) {

            if (data.estado == "OK")
            {
                $('#lista').append('<table id="miTaba">');
                $('miTabla').append('<caption>Lista de amigos</caoption>');
                $("#miTabla").append("<thead>");
                $("#miTabla").append("<tr>");
                $("#miTabla").append("<th>Foto</th>");
                $("#miTabla").append("<th>Nombre</th>");
                $("#miTabla").append("</tr>");
                $("#miTabla").append("<thead>");

                $('miTabla').append("<tbody>");
                $.each(data.numeroFilas, function (i,fila) {
                    $("#miTabla").append("<tr>");
                    $("#lista_alumnos").append("<td>" + fila.Foto + "</td>");
                    $("#lista_alumnos").append("<td>" + fila.Nombre + "</td>");
                    $("#miTabla").append("</tr>");
                });
                $('miTabla').append("</tbody>");
                $('#lista').append('</table>');

            } else {

                $('#lista').append('<p> no se encontraron amigos </p>');

            }

        });    
    });

});




