class SolicitarDeposito {
  String id;
  String clienteId;
  double valor;
  int valorEmCentavos;

  SolicitarDeposito(
      {this.id, this.clienteId, this.valor, this.valorEmCentavos});

  SolicitarDeposito.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    clienteId = json['clienteId'];
    valor = json['valor'];
    valorEmCentavos = json['valorEmCentavos'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['clienteId'] = this.clienteId;
    data['valor'] = this.valor;
    data['valorEmCentavos'] = this.valorEmCentavos;
    return data;
  }
}
