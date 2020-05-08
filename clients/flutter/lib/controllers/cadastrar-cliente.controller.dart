import 'package:bankflix/utils/string-extensions.utils.dart';
import 'package:bankflix/models/clientes/cadastrar-cliente.model.dart';
import 'package:bankflix/models/erro-response.model.dart';
import 'package:bankflix/repository/cliente.repository.dart';
import 'package:dio/dio.dart';
import 'package:mobx/mobx.dart';
import 'package:intl/intl.dart';

part 'cadastrar-cliente.controller.g.dart';

class CadastrarClienteController = _CadastrarClienteControllerBase
    with _$CadastrarClienteController;

abstract class _CadastrarClienteControllerBase with Store {
  @observable
  var model = CadastrarCliente();

  @observable
  ErroResponse erroResponse;

  @action
  definirNomeCompleto(String nomeCompleto) {
    model.nomeCompleto = nomeCompleto;
    model = model;
  }

  @action
  definirCpf(String cpf) {
    model.cpf = cpf.replaceAll(".", "").replaceAll("-", "");
    model = model;
  }

  @action
  definirEmail(String email) {
    model.email = email;
    model = model;
  }

  @action
  definirTelefone(String telefone) {
    model.telefone = telefone
        .replaceAll("(", "")
        .replaceAll(")", "")
        .replaceAll(" ", "")
        .replaceAll("-", "");
    model = model;
  }

  @action
  definirDataNascimento(String dataNascimento) {
    if (dataNascimento == null || dataNascimento.isEmpty) return;

    var formatter = new DateFormat('dd/MM/yyyy');
    model.dataNascimento = formatter.parse(dataNascimento).toIso8601String();
    model = model;
  }

  @action
  definirSenha(String senha) {
    model.senha = senha;
    model = model;
  }

  bool validar() {
    if (model.nomeCompleto.isNullOrEmpty() ||
        model.cpf.isNullOrEmpty() ||
        model.email.isNullOrEmpty() ||
        model.telefone.isNullOrEmpty() ||
        model.dataNascimento.isNullOrEmpty() ||
        model.senha.isNullOrEmpty())
      return false;
    else
      return true;
  }

  @action
  Future<bool> cadastrar() async {
    erroResponse = null;

    if (!validar()) {
      erroResponse = ErroResponse();
      erroResponse.errors = ['Todos os campos são obrigatórios.'];
      return false;
    }

    try {
      var clienteRepository = new ClienteRepository();
      await clienteRepository.cadastrar(model);
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
