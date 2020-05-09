// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dashboard.controller.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$DashboardController on _DashboardControllerBase, Store {
  Computed<String> _$numeroContaComDigitoComputed;

  @override
  String get numeroContaComDigito => (_$numeroContaComDigitoComputed ??=
          Computed<String>(() => super.numeroContaComDigito))
      .value;

  final _$saldoAtom = Atom(name: '_DashboardControllerBase.saldo');

  @override
  double get saldo {
    _$saldoAtom.context.enforceReadPolicy(_$saldoAtom);
    _$saldoAtom.reportObserved();
    return super.saldo;
  }

  @override
  set saldo(double value) {
    _$saldoAtom.context.conditionallyRunInAction(() {
      super.saldo = value;
      _$saldoAtom.reportChanged();
    }, _$saldoAtom, name: '${_$saldoAtom.name}_set');
  }

  final _$numeroContaAtom = Atom(name: '_DashboardControllerBase.numeroConta');

  @override
  String get numeroConta {
    _$numeroContaAtom.context.enforceReadPolicy(_$numeroContaAtom);
    _$numeroContaAtom.reportObserved();
    return super.numeroConta;
  }

  @override
  set numeroConta(String value) {
    _$numeroContaAtom.context.conditionallyRunInAction(() {
      super.numeroConta = value;
      _$numeroContaAtom.reportChanged();
    }, _$numeroContaAtom, name: '${_$numeroContaAtom.name}_set');
  }

  final _$digitoAtom = Atom(name: '_DashboardControllerBase.digito');

  @override
  String get digito {
    _$digitoAtom.context.enforceReadPolicy(_$digitoAtom);
    _$digitoAtom.reportObserved();
    return super.digito;
  }

  @override
  set digito(String value) {
    _$digitoAtom.context.conditionallyRunInAction(() {
      super.digito = value;
      _$digitoAtom.reportChanged();
    }, _$digitoAtom, name: '${_$digitoAtom.name}_set');
  }

  final _$obterMinhaContaAsyncAction = AsyncAction('obterMinhaConta');

  @override
  Future obterMinhaConta() {
    return _$obterMinhaContaAsyncAction.run(() => super.obterMinhaConta());
  }

  @override
  String toString() {
    final string =
        'saldo: ${saldo.toString()},numeroConta: ${numeroConta.toString()},digito: ${digito.toString()},numeroContaComDigito: ${numeroContaComDigito.toString()}';
    return '{$string}';
  }
}
