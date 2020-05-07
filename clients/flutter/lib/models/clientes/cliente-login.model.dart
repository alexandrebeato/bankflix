class ClienteLogin {
  String cpf;
  String senha;

  ClienteLogin({this.cpf, this.senha});

  ClienteLogin.fromJson(Map<String, dynamic> json) {
    cpf = json['cpf'];
    senha = json['senha'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['cpf'] = this.cpf;
    data['senha'] = this.senha;
    return data;
  }
}
