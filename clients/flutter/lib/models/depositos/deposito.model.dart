import 'package:bankflix/enums/situacao-deposito.enum.dart';

class Deposito {
  String id;
  Conta conta;
  num valor;
  int situacao;
  String motivoCancelamento;
  String dataHoraCriacao;
  num valorEmReais;

  Deposito(
      {this.id,
      this.conta,
      this.valor,
      this.situacao,
      this.motivoCancelamento,
      this.dataHoraCriacao,
      this.valorEmReais});

  Deposito.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    conta = json['conta'] != null ? new Conta.fromJson(json['conta']) : null;
    valor = json['valor'];
    situacao = json['situacao'];
    motivoCancelamento = json['motivoCancelamento'];
    dataHoraCriacao = json['dataHoraCriacao'];
    valorEmReais = json['valorEmReais'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    if (this.conta != null) {
      data['conta'] = this.conta.toJson();
    }
    data['valor'] = this.valor;
    data['situacao'] = this.situacao;
    data['motivoCancelamento'] = this.motivoCancelamento;
    data['dataHoraCriacao'] = this.dataHoraCriacao;
    data['valorEmReais'] = this.valorEmReais;
    return data;
  }

  SituacaoDeposito obterSituacaoDeposito() {
    switch (this.situacao) {
      case 1:
        return SituacaoDeposito.Pendente;
      case 2:
        return SituacaoDeposito.Efetuado;
      case 3:
        return SituacaoDeposito.Cancelado;
      default:
        throw ("Nenhuma opção encontrada.");
    }
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
