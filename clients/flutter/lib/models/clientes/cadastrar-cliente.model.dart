class CadastrarCliente {
  String nomeCompleto;
  String cpf;
  DateTime dataNascimento;
  String email;
  String telefone;
  String senha;

  CadastrarCliente(
      {this.nomeCompleto,
      this.cpf,
      this.dataNascimento,
      this.email,
      this.telefone,
      this.senha});

  CadastrarCliente.fromJson(Map<String, dynamic> json) {
    nomeCompleto = json['nomeCompleto'];
    cpf = json['cpf'];
    dataNascimento = json['dataNascimento'];
    email = json['email'];
    telefone = json['telefone'];
    senha = json['senha'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['nomeCompleto'] = this.nomeCompleto;
    data['cpf'] = this.cpf;
    data['dataNascimento'] = this.dataNascimento;
    data['email'] = this.email;
    data['telefone'] = this.telefone;
    data['senha'] = this.senha;
    return data;
  }
}
