import 'package:bankflix/enums/situacao-deposito.enum.dart';
import 'package:bankflix/widgets/situacao-deposito-icone.widget.dart';
import 'package:flutter/material.dart';

class DepositosPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
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
                keyboardType: TextInputType.number,
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
              Container(
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
              SizedBox(
                height: 20,
              ),
              Text(
                "Histórico",
                style: Theme.of(context).textTheme.title,
              ),
              depositoCard(context, SituacaoDeposito.Pendente,
                  "Alexandre Beato", "150,00", "09/03"),
              depositoCard(context, SituacaoDeposito.Cancelado,
                  "Alexandre Beato", "150,00", "08/03"),
              depositoCard(context, SituacaoDeposito.Efetuado,
                  "Alexandre Beato", "150,00", "07/03"),
              depositoCard(context, SituacaoDeposito.Efetuado,
                  "Alexandre Beato", "150,00", "06/03"),
            ],
          ),
        ),
      ),
    );
  }

  Widget depositoCard(BuildContext context, SituacaoDeposito situacaoDeposito,
      String nome, String valor, String dataHora) {
    return ListTile(
      leading: SituacaoDepositoIconeWidget(
        situacaoDeposito: situacaoDeposito,
      ),
      title: Text(nome),
      subtitle: Text("R\$ $valor"),
      trailing: Text(dataHora),
    );
  }
}
