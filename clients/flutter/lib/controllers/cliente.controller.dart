import 'package:bankflix/models/clientes/cliente.model.dart';
import 'package:mobx/mobx.dart';
part 'cliente.controller.g.dart';

class ClienteController = _ClienteController with _$ClienteController;

abstract class _ClienteController with Store {
  _ClienteController() {
    cliente = null;
    carregarClienteAutenticado();
  }

  @observable
  var cliente = Cliente();

  @action
  carregarClienteAutenticado() {}

  @action
  sair() {
    cliente = null;
  }
}
