import 'package:flutter/material.dart';

void main() => runApp(BankflixApp());

class BankflixApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Bankflix',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: Scaffold(
        body: Center(
          child: Text("Bankflix"),
        ),
      ),
    );
  }
}
