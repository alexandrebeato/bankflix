class SolicitarTransferencia {
  String clienteOrigemId;
  String numeroContaDestino;
  String digitoVerificadorContaDestino;
  double valor;
  int valorEmCentavos;

  SolicitarTransferencia(
      {this.clienteOrigemId,
      this.numeroContaDestino,
      this.digitoVerificadorContaDestino,
      this.valor,
      this.valorEmCentavos});

  SolicitarTransferencia.fromJson(Map<String, dynamic> json) {
    clienteOrigemId = json['clienteOrigemId'];
    numeroContaDestino = json['numeroContaDestino'];
    digitoVerificadorContaDestino = json['digitoVerificadorContaDestino'];
    valor = json['valor'];
    valorEmCentavos = json['valorEmCentavos'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['clienteOrigemId'] = this.clienteOrigemId;
    data['numeroContaDestino'] = this.numeroContaDestino;
    data['digitoVerificadorContaDestino'] = this.digitoVerificadorContaDestino;
    data['valor'] = this.valor;
    data['valorEmCentavos'] = this.valorEmCentavos;
    return data;
  }
}
