
$("#buttonGerarChaveConsulta").click(function () {

    if (confirm("Este processo pode demorar, por favor, não feche o navegador !!"))
    {
        $(".messagem-aviso").show();
        $.ajax(
            {
                type: "POST",
                url: "/Rodovia/GerarStringComparacao",
                cache: false,
                data: {
                    variavel: ''
                },
                success: function (retorno) {
                    window.location.href = "/Rodovia/ListarRodoviasTarifa"; 
                }
            });

    }
});


