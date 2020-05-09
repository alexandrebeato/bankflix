import 'dart:convert';

import 'package:bankflix/models/clientes/cliente.model.dart';
import 'package:bankflix/settings.dart';
import 'package:mobx/mobx.dart';
import 'package:shared_preferences/shared_preferences.dart';
part 'cliente.controller.g.dart';

class ClienteController = _ClienteController with _$ClienteController;

abstract class _ClienteController with Store {
  _ClienteController() {
    cliente = null;
    token = null;
    carregarClienteAutenticado();
  }

  @observable
  Cliente cliente;

  @observable
  String token;

  @action
  carregarClienteAutenticado() async {
    var _sharedPreferences = await SharedPreferences.getInstance();
    var clienteData = _sharedPreferences.getString('cliente');
    var tokenData = _sharedPreferences.getString('token');

    if (clienteData != null && tokenData != null) {
      var cliente = Cliente.fromJson(jsonDecode(clienteData));
      this.cliente = cliente;
      this.token = tokenData;
      Settings.cliente = cliente;
      Settings.token = tokenData;
    }
  }

  @action
  definirCliente(Cliente cliente) async {
    this.cliente = cliente;
    Settings.cliente = cliente;
    var _sharedPreferences = await SharedPreferences.getInstance();
    await _sharedPreferences.setString('cliente', jsonEncode(cliente));
  }

  @action
  definirToken(String token) async {
    this.token = token;
    Settings.token = token;
    var _sharedPreferences = await SharedPreferences.getInstance();
    await _sharedPreferences.setString('token', token);
  }

  @action
  sair() async {
    cliente = null;
    token = null;
    Settings.cliente = null;
    Settings.token = null;
    var _sharedPreferences = await SharedPreferences.getInstance();
    await _sharedPreferences.setString('cliente', null);
    await _sharedPreferences.setString('token', null);
  }
}
