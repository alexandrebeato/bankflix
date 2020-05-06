import 'package:bankflix/pages/dashboard.page.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class LoginPage extends StatelessWidget {
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
                  hasFloatingPlaceholder: true,
                ),
              ),
              SizedBox(
                height: 10,
              ),
              TextFormField(
                keyboardType: TextInputType.text,
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
                  hasFloatingPlaceholder: true,
                ),
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
}
