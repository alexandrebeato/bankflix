import 'package:bankflix/controllers/cadastrar-cliente.controller.dart';
import 'package:bankflix/pages/dashboard.page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_masked_text/flutter_masked_text.dart';
import 'package:provider/provider.dart';

class CadastroPage extends StatelessWidget {
  final _scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  Widget build(BuildContext context) {
    var cadastrarClienteController =
        Provider.of<CadastrarClienteController>(context);

    cadastrarClienteController.limparModel();

    return Scaffold(
      key: _scaffoldKey,
      backgroundColor: Theme.of(context).primaryColor,
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.transparent,
      ),
      body: Container(
        width: double.infinity,
        padding: EdgeInsets.only(left: 30, right: 30, top: 10),
        child: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: <Widget>[
              Text(
                "Solicite",
                style: TextStyle(
                  fontSize: 35,
                  color: Theme.of(context).accentColor,
                  fontWeight: FontWeight.w500,
                ),
              ),
              Text(
                "uma conta",
                style: TextStyle(
                  fontSize: 40,
                  color: Theme.of(context).accentColor,
                  fontWeight: FontWeight.w500,
                ),
              ),
              SizedBox(
                height: 10,
              ),
              defaultTextField(
                context,
                "Nome completo",
                TextInputType.text,
                onChanged: cadastrarClienteController.definirNomeCompleto,
              ),
              SizedBox(
                height: 10,
              ),
              defaultTextField(
                context,
                "CPF",
                TextInputType.number,
                onChanged: cadastrarClienteController.definirCpf,
                mask: "000.000.000-00",
              ),
              SizedBox(
                height: 10,
              ),
              defaultTextField(
                context,
                "E-mail",
                TextInputType.emailAddress,
                onChanged: cadastrarClienteController.definirEmail,
              ),
              SizedBox(
                height: 10,
              ),
              defaultTextField(
                context,
                "Telefone",
                TextInputType.number,
                onChanged: cadastrarClienteController.definirTelefone,
                mask: "(00) 00000-0000",
              ),
              SizedBox(
                height: 10,
              ),
              defaultTextField(
                context,
                "Data de nascimento",
                TextInputType.number,
                onChanged: cadastrarClienteController.definirDataNascimento,
                mask: "00/00/0000",
              ),
              SizedBox(
                height: 10,
              ),
              defaultTextField(
                context,
                "Senha",
                TextInputType.text,
                obscureText: true,
                onChanged: cadastrarClienteController.definirSenha,
              ),
              SizedBox(
                height: 20,
              ),
              GestureDetector(
                onTap: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => DashboardPage(),
                    ),
                  );
                },
                child: GestureDetector(
                  onTap: () {
                    cadastrar(cadastrarClienteController, context);
                  },
                  child: Container(
                    width: double.infinity,
                    alignment: Alignment(0, 0),
                    decoration: BoxDecoration(
                      color: Color(0xFF4A1942),
                      borderRadius: BorderRadius.circular(15),
                    ),
                    height: 60,
                    child: Text(
                      "Entrar",
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.w500,
                        color: Theme.of(context).accentColor,
                      ),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget defaultTextField(
    BuildContext context,
    String text,
    TextInputType textInputType, {
    bool obscureText = false,
    Function onChanged,
    String mask,
  }) {
    return TextFormField(
      keyboardType: textInputType,
      textCapitalization: textInputType == TextInputType.emailAddress
          ? TextCapitalization.none
          : TextCapitalization.words,
      obscureText: obscureText,
      controller: mask == null ? null : MaskedTextController(mask: mask),
      style: TextStyle(
        color: Theme.of(context).accentColor,
        fontSize: 20,
      ),
      decoration: InputDecoration(
        labelText: text,
        labelStyle: TextStyle(
          color: Theme.of(context).accentColor,
        ),
        hasFloatingPlaceholder: true,
      ),
      onChanged: onChanged,
      textInputAction: TextInputAction.done,
    );
  }

  cadastrar(CadastrarClienteController cadastrarClienteController,
      BuildContext context) async {
    var response = await cadastrarClienteController.cadastrar();

    if (response) {
      exibirSnackBar(
        'Sua conta foi solicitada. Quando for aprovada poderá acessá-la normalmente.',
      );

      Future.delayed(const Duration(milliseconds: 4000), () {
        Navigator.pop(context);
      });
    } else {
      if (cadastrarClienteController.erroResponse != null) {
        cadastrarClienteController.erroResponse.errors
            .forEach((erro) => exibirSnackBar(erro));
      } else {
        exibirSnackBar('Erro desconhecido');
      }
    }
  }

  exibirSnackBar(String mensagem) {
    final snackBar = SnackBar(
      content: Text(mensagem),
      duration: Duration(milliseconds: 4000),
    );
    _scaffoldKey.currentState.showSnackBar(snackBar);
  }
}
