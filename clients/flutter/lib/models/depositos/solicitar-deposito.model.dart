class SolicitarDeposito {
  double valor;

  SolicitarDeposito({this.valor});

  SolicitarDeposito.fromJson(Map<String, dynamic> json) {
    valor = json['valor'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['valor'] = this.valor;
    return data;
  }
}
