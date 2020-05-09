import 'package:bankflix/controllers/cliente.controller.dart';
import 'package:bankflix/models/clientes/cliente-login.model.dart';
import 'package:bankflix/models/erro-response.model.dart';
import 'package:bankflix/repository/cliente.repository.dart';
import 'package:bankflix/utils/string.utils.dart';
import 'package:dio/dio.dart';
import 'package:mobx/mobx.dart';
part 'login.controller.g.dart';

class LoginController = _LoginControllerBase with _$LoginController;

abstract class _LoginControllerBase with Store {
  @observable
  var model = ClienteLogin();

  @observable
  ErroResponse erroResponse;

  @action
  definirCpf(String cpf) {
    model.cpf = cpf.replaceAll(".", "").replaceAll("-", "");
    model = model;
  }

  @action
  definirSenha(String senha) {
    model.senha = senha;
    model = model;
  }

  @action
  limparModel() => model = ClienteLogin();

  bool validar() {
    if (StringUtils.isNullOrEmpty(model.cpf) ||
        StringUtils.isNullOrEmpty(model.senha))
      return false;
    else
      return true;
  }

  @action
  Future<bool> entrar(ClienteController clienteController) async {
    erroResponse = null;

    if (!validar()) {
      erroResponse = ErroResponse();
      erroResponse.errors = ['Todos os campos são obrigatórios.'];
      return false;
    }

    try {
      var clienteRepository = new ClienteRepository();
      var clienteAutenticado = await clienteRepository.entrar(model);
      await clienteController.definirCliente(clienteAutenticado.cliente);
      await clienteController.definirToken(clienteAutenticado.token);
      return true;
    } catch (ex) {
      if (ex is DioError) {
        if (ex.response?.data != null) {
          erroResponse = ErroResponse.fromJson(ex.response.data);
          return false;
        }
        return false;
      }
      return false;
    }
  }
}
