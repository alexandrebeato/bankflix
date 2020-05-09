import 'package:bankflix/controllers/depositos.controller.dart';
import 'package:bankflix/enums/situacao-deposito.enum.dart';
import 'package:bankflix/widgets/situacao-deposito-icone.widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

class DepositosPage extends StatelessWidget {
  final _scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  Widget build(BuildContext context) {
    final depositosController = Provider.of<DepositosController>(context);
    depositosController.obterMeusDepositos();

    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        title: Text("Depósitos"),
        elevation: 0,
      ),
      body: Container(
        padding: EdgeInsets.all(20),
        child: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: <Widget>[
              SizedBox(
                height: 10,
              ),
              TextFormField(
                keyboardType: TextInputType.numberWithOptions(
                  decimal: true,
                ),
                onChanged: depositosController.definirValorDeposito,
                decoration: InputDecoration(
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10),
                  ),
                  labelText: "Valor para depositar (R\$)",
                ),
              ),
              SizedBox(
                height: 10,
              ),
              GestureDetector(
                onTap: () async {
                  solicitarDeposito(depositosController);
                },
                child: Container(
                  height: 50,
                  alignment: Alignment(0, 0),
                  decoration: BoxDecoration(
                      color: Theme.of(context).primaryColor,
                      borderRadius: BorderRadius.circular(10)),
                  child: Text(
                    "Depositar",
                    style: TextStyle(
                      fontSize: 15,
                      color: Theme.of(context).accentColor,
                    ),
                  ),
                ),
              ),
              SizedBox(
                height: 20,
              ),
              Text(
                "Histórico",
                style: Theme.of(context).textTheme.headline6,
              ),
              Observer(
                builder: (_) {
                  return Container(
                    height: 400,
                    child: ListView.builder(
                        itemCount: depositosController.depositos.length,
                        itemBuilder: (BuildContext context, int index) {
                          var deposito = depositosController.depositos[index];
                          return depositoCard(
                            context,
                            deposito.obterSituacaoDeposito(),
                            deposito.conta.cliente.nomeCompleto,
                            deposito.valorEmReais.toDouble(),
                            deposito.dataHoraCriacao,
                          );
                        }),
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget depositoCard(BuildContext context, SituacaoDeposito situacaoDeposito,
      String nome, double valor, String dataHora) {
    var dataHoraFormatoCorreto = DateTime.parse(dataHora);

    return ListTile(
      leading: SituacaoDepositoIconeWidget(
        situacaoDeposito: situacaoDeposito,
      ),
      title: Text(nome),
      subtitle: Text("R\$ ${formatarValor(valor)}"),
      trailing:
          Text("${dataHoraFormatoCorreto.day}/${dataHoraFormatoCorreto.month}"),
    );
  }

  String formatarValor(double valor) {
    if (valor == null) return "0,00";

    var numberFormat = NumberFormat('#0.00', 'pt_BR');
    return numberFormat.format(valor);
  }

  exibirSnackBar(String mensagem) {
    final snackBar = SnackBar(
      content: Text(mensagem),
      duration: Duration(milliseconds: 4000),
    );
    _scaffoldKey.currentState.showSnackBar(snackBar);
  }

  Future solicitarDeposito(DepositosController depositosController) async {
    var response = await depositosController.solicitarDeposito();

    if (response) {
      depositosController.obterMeusDepositos();
      exibirSnackBar("Depósito solicitado.");
    } else {
      if (depositosController.erroResponse != null) {
        depositosController.erroResponse.errors
            .forEach((erro) => exibirSnackBar(erro));
      } else {
        exibirSnackBar('Erro desconhecido');
      }
    }
  }
}
