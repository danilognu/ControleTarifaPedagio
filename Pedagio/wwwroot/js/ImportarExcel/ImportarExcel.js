

$("#buttonUploadArquivo").click(function () {

    alert("Arquivo será importado, por favor, não feche o navegador!!");

    $(".messagem-aviso").show();

    $("#fromUploadArquivo").submit();
});


function GerarDesvio(id) {
    $(".messagem-aviso").show();
    location.href = "/Comparacao/GerarContabilizacao?id=" + id;
}