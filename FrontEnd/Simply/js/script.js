async function cadastradoContato(objetoContato){
    console.log(objetoContato);

    let resposta = await fetch("http://localhost:3000/contatos",{
        method: "POST",
        body: JSON.stringify(objetoContato),
        headers: {
            "Content-Type" : "application/json; charset=UTF-8"
        }
    });
}


function validarFormulario() {
    let Nome = document.getElementById("Nome").value.trim(); //pega o valor do campo com id nome
    let Sobrenome = document.getElementById("Sobrenome").value.trim(); //o trim retira os espaços das extremidades das palavras
    // let Email = document.getElementById("Email").value.trim();
    // let DDI = document.getElementById("DDI").value.trim();
    // let DDD = document.getElementById("DDD").value.trim();
    // let Numero = document.getElementById("Numero").value.trim();
    // let CEP = document.getElementById("CEP").value.trim();
    // let Rua = document.getElementById("Rua").value.trim();
    // let NumeroCasa = document.getElementById("NumeroCasa").value.trim();
    // let Apto = document.getElementById("Apto").value.trim();
    // let Bairro = document.getElementById("Bairro").value.trim();
    // let Cidade = document.getElementById("Cidade").value.trim();
    // let Estado = document.getElementById("Estado").value.trim();
    // let Anotacoes = document.getElementById("Anotacoes").value.trim();

    let quantidadeErros = 0;


    //Valida o preenchimento do campo nome
    if (Nome.length == 0) {
        formError("Nome");
        quantidadeErros++;
    } else {
        reinicaBorda("Nome");
    }


    //Valida o preenchimento do campo sobrenome
    if (Sobrenome.length == 0) {
        formError("Sobrenome");
        quantidadeErros++;

    } else {
        reinicaBorda("Sobrenome");
    }

    let objetoContato = {
        nome : Nome,
        sobrenome : Sobrenome
    };

    let cadastrado = cadastradoContato(objetoContato);



//     //Valida o preenchimento do campo email
//     if (Email.length == 0) {
//         formError("Email");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Email");
//     }


//     //Valida o preenchimento do campo DDI
//     if (DDI.length == 0) {
//         formError("DDI");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("DDI");
//     }


//     //Valida o preenchimento do campo DDD
//     if (DDD.length == 0) {
//         formError("DDD");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("DDD");
//     }


//     //Valida o preenchimento do campo Numero
//     if (Numero.length == 0) {
//         formError("Numero");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Numero");
//     }


//     //Valida o preenchimento do campo CEP
//     if (CEP.length == 0) {
//         formError("CEP");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("CEP");
//     }


//     //Valida o preenchimento do campo Rua
//     if (Rua.length == 0) {
//         formError("Rua");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Rua");
//     }


//     //Valida o preenchimento do campo NumeroCasa
//     if (NumeroCasa.length == 0) {
//         formError("NumeroCasa");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("NumeroCasa");
//     }


//     //Valida o preenchimento do campo Apto
//     if (Apto.length == 0) {
//         formError("Apto");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Apto");
//     }


//     //Valida o preenchimento do campo Bairro
//     if (Bairro.length == 0) {
//         formError("Bairro");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Bairro");
//     }


//     //Valida o preenchimento do campo Cidade
//     if (Cidade.length == 0) {
//         formError("Cidade");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Cidade");
//     }


//     //Valida o preenchimento do campo Estado
//     if (Estado.length == 0) {
//         formError("Estado");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Estado");
//     }


//     //Valida o preenchimento do campo Anotacoes
//     if (Anotacoes.length == 0) {
//         formError("Anotacoes");
//         quantidadeErros++;
//     } else {
//         reinicaBorda("Anotacoes");
//     }

    if (quantidadeErros != 0) {
        alert("Existem " + quantidadeErros + "campo(s) obrigatórios não prenchido(s).");
        quantidadeErros = 0;
    }

}
//função que pinta a borda do campo que falta preencher
function formError(fildId) {
    document.getElementById(fildId).style.border = "2px solid red";
}

//função que volta as bordas
function reinicaBorda(fildId) {
    document.getElementById(fildId).style.border = "none";
    // console.log(`Nome: ${Nome} | Sobrenome: ${Sobrenome} | Email: ${Email}`); //literal templante: é a crase 
}//fim da função


async function buscarEndereco(cep) {
    if (cep.trim().length < 8) {
        alert("Cep invãlido. O CEP deve conter 8 digitos!");
    }

    try {
        aguardandoCampos();

        let retorno = await fetch(`http://viacep.com.br/ws/${cep}/json/`)
        let dados = await retorno.json();
        console.log(dados);

        document.getElementById("Rua").value = dados.logradouro;
        document.getElementById("Bairro").value = dados.bairro;
        document.getElementById("Cidade").value = dados.localidade;
        document.getElementById("Estado").value = dados.estado;
    } catch  {
        alert("Erro ao procurar endereço")
    }
}

function aguardandoCampos(){
    document.getElementById("Rua").value = "Aguardando...";
    document.getElementById("Bairro").value = "Aguardando...";
    document.getElementById("Cidade").value = "Aguardando...";
    document.getElementById("Estado").value = "Aguardando...";
}