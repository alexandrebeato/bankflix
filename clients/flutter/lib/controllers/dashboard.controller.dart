import 'package:bankflix/repository/cliente.repository.dart';
import 'package:mobx/mobx.dart';
part 'dashboard.controller.g.dart';

class DashboardController = _DashboardControllerBase with _$DashboardController;

abstract class _DashboardControllerBase with Store {
  @observable
  double saldo = 0;

  @observable
  String numeroConta = "";

  @observable
  String digito = "";

  @computed
  String get numeroContaComDigito => "$numeroConta-$digito";

  @action
  obterMinhaConta() async {
    var clienteRepository = ClienteRepository();
    var minhaConta = await clienteRepository.obterMinhaConta();
    saldo = minhaConta.saldoDisponivelEmReais.toDouble();
    numeroConta = minhaConta.numero;
    digito = minhaConta.digitoVerificador;
  }
}
