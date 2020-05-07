import 'package:flutter/material.dart';

class DashboardPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.transparent,
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
                    Text(
                      "R\$ 1998,09",
                      style: TextStyle(
                        fontSize: 30,
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                      ),
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
                                    "assets/images/transfer-money.png"),
                                operacaoItemCard(
                                    context,
                                    "Depósitos",
                                    "Depositar dinheiro na sua conta",
                                    "assets/images/deposit.png"),
                                operacaoItemCard(
                                    context,
                                    "Suporte",
                                    "Precisa de ajuda? Atendimento 24 horas.",
                                    "assets/images/support.png"),
                              ],
                            ),
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
      BuildContext context, String titulo, String descricao, String imagem) {
    return Container(
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
    );
  }
}
