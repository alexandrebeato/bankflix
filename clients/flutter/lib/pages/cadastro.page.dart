import 'package:bankflix/pages/dashboard.page.dart';
import 'package:flutter/material.dart';

class CadastroPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
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
              defaultTextField(context, "Nome completo", TextInputType.text),
              SizedBox(
                height: 10,
              ),
              defaultTextField(context, "CPF", TextInputType.number),
              SizedBox(
                height: 10,
              ),
              defaultTextField(context, "E-mail", TextInputType.emailAddress),
              SizedBox(
                height: 10,
              ),
              defaultTextField(context, "Telefone", TextInputType.phone),
              SizedBox(
                height: 10,
              ),
              defaultTextField(
                  context, "Data de nascimento", TextInputType.number),
              SizedBox(
                height: 10,
              ),
              defaultTextField(context, "Senha", TextInputType.text,
                  obscureText: true),
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

  Widget defaultTextField(
      BuildContext context, String text, TextInputType textInputType,
      {bool obscureText = false}) {
    return TextFormField(
      keyboardType: textInputType,
      textCapitalization: TextCapitalization.words,
      obscureText: obscureText,
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
    );
  }
}
