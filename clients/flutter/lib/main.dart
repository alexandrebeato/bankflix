import 'package:bankflix/pages/home.page.dart';
import 'package:bankflix/themes/light.theme.dart';
import 'package:flutter/material.dart';

void main() => runApp(BankflixApp());

class BankflixApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Bankflix',
      debugShowCheckedModeBanner: false,
      theme: lightTheme(),
      home: HomePage(),
    );
  }
}
