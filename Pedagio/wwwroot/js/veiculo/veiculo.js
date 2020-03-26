// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#teste").click(function () {

    var placa = $("#Placa").val();

    var myJSON = { "placa": "" + placa + "" };
    var myString = JSON.stringify(myJSON);

    console.log(myString);

    $.ajax({
        type: "POST",
        url: "/Veiculo/Consulta",
        data: myString,
        contentType: 'application/json',
        dataType: 'json',          
        success: function (data) {
            console.log(data);
        }, //End of AJAX Success function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });  

});


$(".cancelar-veiculo").click(function () {
    location.href = "\Consulta";
});


$(".cancelar-tipo-veiculo").click(function () {
    location.href = "\ConsultaTipoVeiculo";
});

$(".cancelar-operacao-veiculo").click(function () {
    location.href = "\ConsultaOperacaoVeiculo";
});