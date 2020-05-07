class Cliente {
  String id;
  String nomeCompleto;
  String cpf;
  DateTime dataNascimento;
  String email;
  String telefone;
  String senha;
  int situacao;
  DateTime dataHoraCriacao;

  Cliente(
      {this.id,
      this.nomeCompleto,
      this.cpf,
      this.dataNascimento,
      this.email,
      this.telefone,
      this.senha,
      this.situacao,
      this.dataHoraCriacao});

  Cliente.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    nomeCompleto = json['nomeCompleto'];
    cpf = json['cpf'];
    dataNascimento = json['dataNascimento'];
    email = json['email'];
    telefone = json['telefone'];
    senha = json['senha'];
    situacao = json['situacao'];
    dataHoraCriacao = json['dataHoraCriacao'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['nomeCompleto'] = this.nomeCompleto;
    data['cpf'] = this.cpf;
    data['dataNascimento'] = this.dataNascimento;
    data['email'] = this.email;
    data['telefone'] = this.telefone;
    data['senha'] = this.senha;
    data['situacao'] = this.situacao;
    data['dataHoraCriacao'] = this.dataHoraCriacao;
    return data;
  }
}
