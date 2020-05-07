import 'package:bankflix/pages/depositos.page.dart';
import 'package:bankflix/pages/transferencias.page.dart';
import 'package:flutter/material.dart';

class DashboardPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        title: Text("Olá, Alexandre"),
        elevation: 0,
        actions: <Widget>[
          IconButton(
            icon: Icon(Icons.exit_to_app),
            onPressed: () {},
          )
        ],
      ),
      backgroundColor: Theme.of(context).primaryColor,
      body: Container(
        child: Container(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: <Widget>[
              Container(
                alignment: Alignment(0, 0),
                height: 150,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Text(
                      "Saldo atual",
                      style: TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.w400,
                        color: Theme.of(context).accentColor,
                      ),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                        Text(
                          "R\$ 1998,09",
                          style: TextStyle(
                            fontSize: 30,
                            fontWeight: FontWeight.bold,
                            color: Colors.white,
                          ),
                        ),
                        IconButton(
                          onPressed: () {},
                          icon: Icon(Icons.remove_red_eye),
                          color: Theme.of(context).accentColor,
                        )
                      ],
                    ),
                  ],
                ),
              ),
              Expanded(
                child: Container(
                  margin: EdgeInsets.symmetric(horizontal: 15),
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(40),
                        topRight: Radius.circular(40)),
                  ),
                  child: SingleChildScrollView(
                    child: Container(
                      padding: EdgeInsets.all(20),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: <Widget>[
                          Text(
                            "Operações",
                            style: Theme.of(context).textTheme.title,
                          ),
                          SizedBox(
                            height: 20,
                          ),
                          Container(
                            height: 230,
                            child: ListView(
                              scrollDirection: Axis.horizontal,
                              children: <Widget>[
                                operacaoItemCard(
                                    context,
                                    "Transferências",
                                    "Transferir dinheiro para outras contas",
                                    "assets/images/transfer-money.png",
                                    paginaParaAbrir: TransferenciasPage()),
                                operacaoItemCard(
                                    context,
                                    "Depósitos",
                                    "Depositar dinheiro na sua conta",
                                    "assets/images/deposit.png",
                                    paginaParaAbrir: DepositosPage()),
                                operacaoItemCard(
                                    context,
                                    "Suporte",
                                    "Precisa de ajuda? Atendimento 24 horas.",
                                    "assets/images/support.png"),
                              ],
                            ),
                          ),
                          SizedBox(
                            height: 20,
                          ),
                          Text(
                            "Dados da conta",
                            style: Theme.of(context).textTheme.title,
                          ),
                          SizedBox(
                            height: 10,
                          ),
                          ListTile(
                            title: Text("Número"),
                            trailing: Text("0000000001-7"),
                          ),
                          ListTile(
                            title: Text("CPF"),
                            trailing: Text("719.585.510-40"),
                          ),
                          ListTile(
                            title: Text("Agência"),
                            trailing: Text("333"),
                          ),
                          ListTile(
                            title: Text("Agência"),
                            trailing: Text("0001"),
                          ),
                        ],
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

  Widget operacaoItemCard(
      BuildContext context, String titulo, String descricao, String imagem,
      {Widget paginaParaAbrir}) {
    return GestureDetector(
      onTap: () {
        if (paginaParaAbrir != null) {
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => paginaParaAbrir,
            ),
          );
        }
      },
      child: Container(
        width: 180,
        padding: EdgeInsets.all(5),
        margin: EdgeInsets.symmetric(horizontal: 7),
        decoration: BoxDecoration(
          color: Theme.of(context).primaryColor,
          borderRadius: BorderRadius.circular(15),
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Image.asset(
              imagem,
              width: 60,
            ),
            SizedBox(
              height: 25,
            ),
            Text(
              titulo,
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.w500,
                color: Theme.of(context).accentColor,
              ),
            ),
            SizedBox(
              height: 7,
            ),
            Text(
              descricao,
              style: TextStyle(
                fontSize: 15,
                fontWeight: FontWeight.w400,
                color: Theme.of(context).accentColor,
              ),
              textAlign: TextAlign.center,
            ),
          ],
        ),
      ),
    );
  }
}
