import 'package:bankflix/dependency-injector.dart';
import 'package:bankflix/pages/initial.page.dart';
import 'package:bankflix/themes/light.theme.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() => runApp(BankflixApp());

class BankflixApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: DependencyInjector.obterDependencias(),
      child: MaterialApp(
        title: 'Bankflix',
        debugShowCheckedModeBanner: false,
        theme: lightTheme(),
        home: InitialPage(),
      ),
    );
  }
}
