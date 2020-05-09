import 'package:bankflix/controllers/cliente.controller.dart';
import 'package:bankflix/controllers/login.controller.dart';
import 'package:bankflix/pages/dashboard.page.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_masked_text/flutter_masked_text.dart';
import 'package:provider/provider.dart';

class LoginPage extends StatelessWidget {
  final _scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  Widget build(BuildContext context) {
    var loginController = Provider.of<LoginController>(context);
    var clienteController = Provider.of<ClienteController>(context);
    loginController.limparModel();

    return Scaffold(
      key: _scaffoldKey,
      backgroundColor: Theme.of(context).primaryColor,
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.transparent,
      ),
      body: Container(
        width: double.infinity,
        padding: EdgeInsets.all(30),
        child: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: <Widget>[
              SizedBox(
                height: 30,
              ),
              Text(
                "Bem vindo",
                style: TextStyle(
                  fontSize: 40,
                  color: Theme.of(context).accentColor,
                  fontWeight: FontWeight.w500,
                ),
              ),
              Text(
                "de volta",
                style: TextStyle(
                  fontSize: 35,
                  color: Theme.of(context).accentColor,
                  fontWeight: FontWeight.w500,
                ),
              ),
              SizedBox(
                height: 70,
              ),
              TextFormField(
                controller: MaskedTextController(mask: "000.000.000-00"),
                onChanged: loginController.definirCpf,
                keyboardType: TextInputType.number,
                style: TextStyle(
                  color: Theme.of(context).accentColor,
                  fontSize: 20,
                ),
                decoration: InputDecoration(
                  labelText: "CPF",
                  labelStyle: TextStyle(
                    color: Theme.of(context).accentColor,
                  ),
                ),
              ),
              SizedBox(
                height: 10,
              ),
              TextFormField(
                keyboardType: TextInputType.text,
                onChanged: loginController.definirSenha,
                obscureText: true,
                style: TextStyle(
                  color: Theme.of(context).accentColor,
                  fontSize: 20,
                ),
                decoration: InputDecoration(
                  labelText: "Senha",
                  labelStyle: TextStyle(
                    color: Theme.of(context).accentColor,
                  ),
                ),
              ),
              SizedBox(
                height: 20,
              ),
              GestureDetector(
                onTap: () {
                  entrar(loginController, clienteController, context);
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
            ],
          ),
        ),
      ),
    );
  }

  entrar(
    LoginController loginController,
    ClienteController clienteController,
    BuildContext context,
  ) async {
    var response = await loginController.entrar(clienteController);

    if (response) {
      Navigator.pop(context);
    } else {
      if (loginController.erroResponse != null) {
        loginController.erroResponse.errors
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
