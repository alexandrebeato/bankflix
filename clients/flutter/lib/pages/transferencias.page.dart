import 'package:bankflix/enums/situacao-transferencia.enum.dart';
import 'package:bankflix/widgets/situacao-transferencia-icone.widget.dart';
import 'package:flutter/material.dart';

class TransferenciasPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Theme.of(context).primaryColor,
        title: Text("Transferências"),
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
              Row(
                children: <Widget>[
                  Expanded(
                    child: TextFormField(
                      keyboardType: TextInputType.number,
                      decoration: InputDecoration(
                        border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(10),
                        ),
                        labelText: "Dígito",
                      ),
                    ),
                  ),
                  SizedBox(
                    width: 10,
                  ),
                  Container(
                    width: 100,
                    child: TextFormField(
                      keyboardType: TextInputType.number,
                      decoration: InputDecoration(
                        border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(10),
                        ),
                        labelText: "Dígito",
                      ),
                    ),
                  ),
                ],
              ),
              SizedBox(
                height: 10,
              ),
              TextFormField(
                keyboardType: TextInputType.number,
                decoration: InputDecoration(
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10),
                  ),
                  labelText: "Valor para transferir (R\$)",
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
                  "Transferir",
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
                "Transferências recebidas",
                style: Theme.of(context).textTheme.title,
              ),
              depositoCard(context, SituacaoTransferencia.Pendente,
                  "Bianca Rigotto", "150,00", "09/03"),
              depositoCard(context, SituacaoTransferencia.Recusada,
                  "Matheus Beato", "150,00", "08/03"),
              depositoCard(context, SituacaoTransferencia.Efetuada,
                  "Fabiana Beato", "150,00", "07/03"),
              depositoCard(context, SituacaoTransferencia.Efetuada,
                  "Márcio Beato", "150,00", "06/03"),
              SizedBox(
                height: 20,
              ),
              Text(
                "Transferências recebidas",
                style: Theme.of(context).textTheme.title,
              ),
              depositoCard(context, SituacaoTransferencia.Efetuada,
                  "Trendway Tecnologia", "150,00", "09/03"),
              depositoCard(context, SituacaoTransferencia.Efetuada,
                  "Trendway Tecnologia", "150,00", "09/02"),
              depositoCard(context, SituacaoTransferencia.Efetuada,
                  "Trendway Tecnologia", "150,00", "09/01"),
            ],
          ),
        ),
      ),
    );
  }

  Widget depositoCard(
      BuildContext context,
      SituacaoTransferencia situacaoTransferencia,
      String nome,
      String valor,
      String dataHora) {
    return ListTile(
      leading: SituacaoTransferenciaIconeWidget(
        situacaoTransferencia: situacaoTransferencia,
      ),
      title: Text(nome),
      subtitle: Text("R\$ $valor"),
      trailing: Text(dataHora),
    );
  }
}
