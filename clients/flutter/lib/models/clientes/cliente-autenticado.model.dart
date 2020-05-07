import 'package:bankflix/models/clientes/cliente.model.dart';

class ClienteAutenticado {
  String token;
  Cliente cliente;

  ClienteAutenticado({this.token, this.cliente});

  ClienteAutenticado.fromJson(Map<String, dynamic> json) {
    token = json['token'];
    cliente =
        json['cliente'] != null ? new Cliente.fromJson(json['cliente']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['token'] = this.token;
    if (this.cliente != null) {
      data['cliente'] = this.cliente.toJson();
    }
    return data;
  }
}
