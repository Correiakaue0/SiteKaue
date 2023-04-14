
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


function cadastrarProduto() {
    debugger
    var msg = "";
    var alertaMsg = document.getElementById("alertaMsg");
    var textoImagem = document.getElementById("picture__input_text").value;

    var nome = $("#nomeProduto").val();
    if (nome == "") {
        msg += "Nome nao pode ser vazio! <br>";
    }
    var descricao = $("#descricao").val();
    if (descricao == "") {
        msg += "Descrição nao pode ser vazio! <br>";
    }
    var valor = $("#valor").val();
    if (valor == "") {
        msg += "Valor nao pode ser vazio! <br>";
    }
    var imagem = $("#picture__input").val();
    if (imagem != "" && textoImagem == "") {
        textoImagem = imagem;
        if (textoImagem == "") {
            msg += "Imagem nao pode ser vazio! <br>";
        } 
    }
    if (imagem == "" && textoImagem == "") {
        msg += "Imagem nao pode ser vazio! <br>";
    }


    if (msg != "") {
        alertaMsg.style.display = "block";
        alertaMsg.classList.add("alert-warning");
        alertaMsg.innerHTML = msg;
        return false;
    }

    var produto = {
        produto: {
            Nome: nome,
            Descricao: descricao,
            Valor: valor,
            Imagem: textoImagem
        }
    };

    $.ajax({
        type: "POST",
        url: '/Produto/CadastrarProduto',
        data: JSON.parse(JSON.stringify(produto, (key, value) =>
            typeof value === 'bigint'
                ? value.toString()
                : value)
        ) ,
        dataType: "json",
        success: function (t, e, i) {
            if (t.statusCode == 200) {
                alertaMsg.style.display = "block";
                alertaMsg.classList.remove("alert-warning");
                alertaMsg.classList.add("alert-success");
                alertaMsg.innerHTML = "Produto inserido com sucesso!";
            } else {
                alertaMsg.style.display = "block";
                alertaMsg.classList.add("alert-danger");
                alertaMsg.innerHTML = "Produto não inserido com sucesso!";
            }

            setTimeout(function () {
                alertaMsg.style.display = "none";
            }, 2500);
        },
        error: function (t, e, i) {
        }
    });
}