
const inputFile = document.querySelector("#picture__input");
const pictureImage = document.querySelector(".picture__image");
const pictureImageTxt = "Choose an image";
pictureImage.innerHTML = pictureImageTxt;

inputFile.addEventListener("change", function (e) {
    const inputTarget = e.target;
    const file = inputTarget.files[0];

    if (file) {
        const reader = new FileReader();

        reader.addEventListener("load", function (e) {
            const readerTarget = e.target;

            const img = document.createElement("img");
            img.src = readerTarget.result;
            img.classList.add("picture__img");

            pictureImage.innerHTML = "";
            pictureImage.appendChild(img);
        });

        reader.readAsDataURL(file);
    } else {
        pictureImage.innerHTML = pictureImageTxt;
    }
});

function cadastraCategoria() {
    var alertaMsgModal = document.getElementById("alertaMsgModal");
    var msg = "";
    var codigo = document.getElementById("codigo").value;
    if (codigo == "") {
        msg = "Codigo nao pode ficar vazio <br>";
    }
    var descricao = document.getElementById("descricaoCategoria").value;
    if (descricao == "") {
        msg = "Descriçao nao pode ficar vazio <br>";
    }
    if (msg != "") {
        alertaMsgModal.style.display = "block";
        alertaMsgModal.classList.add("alert-warning");
        alertaMsgModal.innerHTML = msg;
        return false;
    }

    var categoria = {
        codigo: codigo,
        descricao: descricao
    };

    $.ajax({
        type: "POST",
        url: '/Produto/CadastraCategoria',
        data: JSON.parse(JSON.stringify(categoria, (key, value) =>
            typeof value === 'bigint'
                ? value.toString()
                : value)
        ),
        dataType: "json",
        success: function (t, e, i) {
            if (t.statusCode == 200) {
                alertaMsgModal.style.display = "block";
                alertaMsgModal.classList.remove("alert-warning");
                alertaMsgModal.classList.add("alert-success");
                alertaMsgModal.innerHTML = "Categoria cadastrada com sucesso!";
                MontaCategoria(t);
            } else {
                alertaMsgModal.style.display = "block";
                alertaMsgModal.classList.add("alert-danger");
                alertaMsgModal.innerHTML = "Categoria não cadastrada com sucesso!";
            }

            setTimeout(function () {
                alertaMsgModal.style.display = "none";
            }, 2500);
        },
        error: function (t, e, i) {
        }
    });
}
function MontaCategoria(categoria) {
    var form_select = document.getElementById("categoriaId");

    let option = document.createElement("option");
    option.value = categoria.categoriaId;
    option.innerHTML = categoria.descricao;

    form_select.appendChild(option);
}

function buscaCategoria() {
    fetch("https://localhost:5001/Categoria")
        .then(resposta => resposta.json())
        .then(data => {
            data.forEach(function (categoria, i) {

                MontaCategoria(categoria)

            })
        });
}
buscaCategoria()
