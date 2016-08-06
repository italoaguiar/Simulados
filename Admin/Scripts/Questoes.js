$(document).ready(function () {
    loadsubcat($("#categoria").val());
});

$("#categoria").change(function () {
    loadsubcat($(this).val());
});
function loadsubcat(id) {
    $.getJSON("Subcategorias/?categoria=" + id)
    .done(function (json) {
        $("#subcategoria").empty();
        for (i = 0; i < json.length; i++) {
            $('#subcategoria').append($('<option>', {
                value: json[i].Id,
                text: json[i].Nome
            }));
        }
    })
    .fail(function (jqxhr, textStatus, error) {
        alert('Não foi possível carregar a página corretamente. Tente Novamente.');
    });
}
$("#uploadAltImage").change(function () {
    var data = new FormData();
    var files = $("#uploadAltImage").get(0).files;
    if (files.length > 0) {
        data.append("imagem", files[0]);
    }
    $.ajax({
        url: "UploadImage",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            $("#imageName").val(JSON.stringify(response));
        },
        error: function (er) {
            alert(er);
        }

    });
});
$("#uploadImage").change(function () {
    var data = new FormData();
    var files = $("#uploadImage").get(0).files;
    if (files.length > 0) {
        data.append("imagem", files[0]);
    }
    $.ajax({
        url: "UploadImage",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            $("#imagem").val(JSON.stringify(response));
        },
        error: function (er) {
            alert(er);
        }

    });
});
$("#subAlt").click(function () {
    alt = $("#alternativa").val();
    img = $("#imageName").val();
    $.ajax({
        url: "AddAlternativa",
        type: "GET",
        processData: false,
        contentType: false,
        data: $.param({alternativa : alt, imagem:img}),
        success: function (id) {
            $("#alt-group").append(
                '<div class="input-group" id="a'+id+'">'+
                        '<input type="text" class="form-control" disabled="disabled" value="' + alt + '" aria-describedby="basic-addon2">' +
                        '<input type="hidden" name="alternativa" value="' + id + '">' +
                        '<span class="input-group-btn" id="basic-addon2">' +
                            '<button class="btn btn-default" onclick="$(\'#a' + id +'\').remove()" type="button">X</button>' +
                        '</span>'+
                    '</div>'
                );
            $('#correta').append($('<option>', {
                value: id,
                text: alt
            }));
        },
        error: function (er) {
            alert(er);
        }

    });
});
