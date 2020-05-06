import 'package:bankflix/pages/cadastro.page.dart';
import 'package:bankflix/pages/login.page.dart';
import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Theme.of(context).primaryColor,
      body: Center(
        child: Column(
          children: <Widget>[
            Expanded(
              child: Container(
                width: double.infinity,
                alignment: Alignment(0, 0),
                child: Image.asset(
                  "assets/images/logo.png",
                  height: 60,
                ),
              ),
            ),
            Container(
              height: 200,
              padding: EdgeInsets.only(left: 30, right: 30),
              child: Column(
                children: <Widget>[
                  roundedButton(
                    context,
                    "Já sou cliente",
                    Color(0xFF4A1942),
                    LoginPage(),
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  roundedButton(
                    context,
                    "Quero ser cliente",
                    Color(0xFF4A1942),
                    CadastroPage(),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget roundedButton(
      BuildContext context, String text, Color backgroundColor, Widget page) {
    return GestureDetector(
      onTap: () {
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => page,
          ),
        );
      },
      child: Container(
        width: double.infinity,
        alignment: Alignment(0, 0),
        decoration: BoxDecoration(
          color: backgroundColor,
          borderRadius: BorderRadius.circular(15),
        ),
        height: 60,
        child: Text(
          text,
          style: TextStyle(
            fontSize: 20,
            fontWeight: FontWeight.w500,
            color: Theme.of(context).accentColor,
          ),
        ),
      ),
    );
  }
}
