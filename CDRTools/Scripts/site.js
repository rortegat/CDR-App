$(document).ready(function() {
    $('#ocultar').click(function () {
        document.getElementById("sidebar-wrapper").style.display = 'none';
        document.getElementById("wrapper").style.padding = "0";
        document.getElementById("bdy").style.padding = "0";
        document.getElementById("mostrar").style.display = 'block';
    });

    $('#mostrar').click(function () {
        document.getElementById("mostrar").style.display = 'none';
        document.getElementById("wrapper").style.padding = "0 0 0 250px";
        document.getElementById("bdy").style.padding = "0 0 0 250px";
        document.getElementById("sidebar-wrapper").style.display = 'block';
    });
});
