
function cadastrarProduto() {
    debugger
    var msg = "";
    var alertaMsg = document.getElementById("alertaMsg");
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
    var imagem = $("#imagem").val();
    if (imagem == "") {
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
            Imagem: imagem
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