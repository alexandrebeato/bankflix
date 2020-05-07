class Transferencia {
  String id;
  Conta contaOrigem;
  Conta contaDestino;
  int valor;
  int situacao;
  String motivoRecusa;
  DateTime dataHoraCriacao;
  double valorEmReais;

  Transferencia(
      {this.id,
      this.contaOrigem,
      this.contaDestino,
      this.valor,
      this.situacao,
      this.motivoRecusa,
      this.dataHoraCriacao,
      this.valorEmReais});

  Transferencia.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    contaOrigem = json['contaOrigem'] != null
        ? new Conta.fromJson(json['contaOrigem'])
        : null;
    contaDestino = json['contaDestino'] != null
        ? new Conta.fromJson(json['contaDestino'])
        : null;
    valor = json['valor'];
    situacao = json['situacao'];
    motivoRecusa = json['motivoRecusa'];
    dataHoraCriacao = json['dataHoraCriacao'];
    valorEmReais = json['valorEmReais'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    if (this.contaOrigem != null) {
      data['contaOrigem'] = this.contaOrigem.toJson();
    }
    if (this.contaDestino != null) {
      data['contaDestino'] = this.contaDestino.toJson();
    }
    data['valor'] = this.valor;
    data['situacao'] = this.situacao;
    data['motivoRecusa'] = this.motivoRecusa;
    data['dataHoraCriacao'] = this.dataHoraCriacao;
    data['valorEmReais'] = this.valorEmReais;
    return data;
  }
}

class Conta {
  String id;
  String numero;
  String digitoVerificador;
  Cliente cliente;

  Conta({this.id, this.numero, this.digitoVerificador, this.cliente});

  Conta.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    numero = json['numero'];
    digitoVerificador = json['digitoVerificador'];
    cliente =
        json['cliente'] != null ? new Cliente.fromJson(json['cliente']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['numero'] = this.numero;
    data['digitoVerificador'] = this.digitoVerificador;
    if (this.cliente != null) {
      data['cliente'] = this.cliente.toJson();
    }
    return data;
  }
}

class Cliente {
  String id;
  String nomeCompleto;
  String cpf;

  Cliente({this.id, this.nomeCompleto, this.cpf});

  Cliente.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    nomeCompleto = json['nomeCompleto'];
    cpf = json['cpf'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['nomeCompleto'] = this.nomeCompleto;
    data['cpf'] = this.cpf;
    return data;
  }
}
