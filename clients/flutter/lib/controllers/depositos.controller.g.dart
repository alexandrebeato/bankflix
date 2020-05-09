// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'depositos.controller.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$DepositosController on _DepositosControllerBase, Store {
  final _$depositosAtom = Atom(name: '_DepositosControllerBase.depositos');

  @override
  ObservableList<Deposito> get depositos {
    _$depositosAtom.context.enforceReadPolicy(_$depositosAtom);
    _$depositosAtom.reportObserved();
    return super.depositos;
  }

  @override
  set depositos(ObservableList<Deposito> value) {
    _$depositosAtom.context.conditionallyRunInAction(() {
      super.depositos = value;
      _$depositosAtom.reportChanged();
    }, _$depositosAtom, name: '${_$depositosAtom.name}_set');
  }

  final _$valorDepositoAtom =
      Atom(name: '_DepositosControllerBase.valorDeposito');

  @override
  double get valorDeposito {
    _$valorDepositoAtom.context.enforceReadPolicy(_$valorDepositoAtom);
    _$valorDepositoAtom.reportObserved();
    return super.valorDeposito;
  }

  @override
  set valorDeposito(double value) {
    _$valorDepositoAtom.context.conditionallyRunInAction(() {
      super.valorDeposito = value;
      _$valorDepositoAtom.reportChanged();
    }, _$valorDepositoAtom, name: '${_$valorDepositoAtom.name}_set');
  }

  final _$erroResponseAtom =
      Atom(name: '_DepositosControllerBase.erroResponse');

  @override
  ErroResponse get erroResponse {
    _$erroResponseAtom.context.enforceReadPolicy(_$erroResponseAtom);
    _$erroResponseAtom.reportObserved();
    return super.erroResponse;
  }

  @override
  set erroResponse(ErroResponse value) {
    _$erroResponseAtom.context.conditionallyRunInAction(() {
      super.erroResponse = value;
      _$erroResponseAtom.reportChanged();
    }, _$erroResponseAtom, name: '${_$erroResponseAtom.name}_set');
  }

  final _$obterMeusDepositosAsyncAction = AsyncAction('obterMeusDepositos');

  @override
  Future<dynamic> obterMeusDepositos() {
    return _$obterMeusDepositosAsyncAction
        .run(() => super.obterMeusDepositos());
  }

  final _$solicitarDepositoAsyncAction = AsyncAction('solicitarDeposito');

  @override
  Future<bool> solicitarDeposito() {
    return _$solicitarDepositoAsyncAction.run(() => super.solicitarDeposito());
  }

  final _$_DepositosControllerBaseActionController =
      ActionController(name: '_DepositosControllerBase');

  @override
  dynamic definirValorDeposito(String valorDeposito) {
    final _$actionInfo =
        _$_DepositosControllerBaseActionController.startAction();
    try {
      return super.definirValorDeposito(valorDeposito);
    } finally {
      _$_DepositosControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    final string =
        'depositos: ${depositos.toString()},valorDeposito: ${valorDeposito.toString()},erroResponse: ${erroResponse.toString()}';
    return '{$string}';
  }
}
