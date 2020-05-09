import 'package:bankflix/models/depositos/deposito.model.dart';
import 'package:bankflix/models/depositos/solicitar-deposito.model.dart';
import 'package:bankflix/models/erro-response.model.dart';
import 'package:bankflix/repository/deposito.repository.dart';
import 'package:dio/dio.dart';
import 'package:mobx/mobx.dart';
part 'depositos.controller.g.dart';

class DepositosController = _DepositosControllerBase with _$DepositosController;

abstract class _DepositosControllerBase with Store {
  @observable
  var depositos = ObservableList<Deposito>();

  @observable
  double valorDeposito;

  @observable
  ErroResponse erroResponse;

  @action
  Future obterMeusDepositos() async {
    var depositoRepository = DepositoRepository();
    var depositos = await depositoRepository.obterMeusDepositos();
    this.depositos = depositos.asObservable();
  }

  @action
  definirValorDeposito(String valorDeposito) {
    if (valorDeposito.contains(",")) {
      valorDeposito = valorDeposito.replaceAll(",", ".");
    }

    this.valorDeposito = double.parse(valorDeposito);
  }

  @action
  Future<bool> solicitarDeposito() async {
    try {
      var depositoRepository = DepositoRepository();
      await depositoRepository
          .solicitarDeposito(SolicitarDeposito(valor: this.valorDeposito));
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
