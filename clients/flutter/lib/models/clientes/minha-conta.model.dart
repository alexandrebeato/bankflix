class MinhaConta {
  String id;
  String clienteId;
  String numero;
  String digitoVerificador;
  num saldoDisponivel;
  String dataHoraCriacao;
  num saldoDisponivelEmReais;

  MinhaConta(
      {this.id,
      this.clienteId,
      this.numero,
      this.digitoVerificador,
      this.saldoDisponivel,
      this.dataHoraCriacao,
      this.saldoDisponivelEmReais});

  MinhaConta.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    clienteId = json['clienteId'];
    numero = json['numero'];
    digitoVerificador = json['digitoVerificador'];
    saldoDisponivel = json['saldoDisponivel'];
    dataHoraCriacao = json['dataHoraCriacao'];
    saldoDisponivelEmReais = json['saldoDisponivelEmReais'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['clienteId'] = this.clienteId;
    data['numero'] = this.numero;
    data['digitoVerificador'] = this.digitoVerificador;
    data['saldoDisponivel'] = this.saldoDisponivel;
    data['dataHoraCriacao'] = this.dataHoraCriacao;
    data['saldoDisponivelEmReais'] = this.saldoDisponivelEmReais;
    return data;
  }
}
