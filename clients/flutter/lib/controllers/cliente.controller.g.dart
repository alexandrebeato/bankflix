// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cliente.controller.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$ClienteController on _ClienteController, Store {
  final _$clienteAtom = Atom(name: '_ClienteController.cliente');

  @override
  Cliente get cliente {
    _$clienteAtom.context.enforceReadPolicy(_$clienteAtom);
    _$clienteAtom.reportObserved();
    return super.cliente;
  }

  @override
  set cliente(Cliente value) {
    _$clienteAtom.context.conditionallyRunInAction(() {
      super.cliente = value;
      _$clienteAtom.reportChanged();
    }, _$clienteAtom, name: '${_$clienteAtom.name}_set');
  }

  final _$tokenAtom = Atom(name: '_ClienteController.token');

  @override
  String get token {
    _$tokenAtom.context.enforceReadPolicy(_$tokenAtom);
    _$tokenAtom.reportObserved();
    return super.token;
  }

  @override
  set token(String value) {
    _$tokenAtom.context.conditionallyRunInAction(() {
      super.token = value;
      _$tokenAtom.reportChanged();
    }, _$tokenAtom, name: '${_$tokenAtom.name}_set');
  }

  final _$carregarClienteAutenticadoAsyncAction =
      AsyncAction('carregarClienteAutenticado');

  @override
  Future carregarClienteAutenticado() {
    return _$carregarClienteAutenticadoAsyncAction
        .run(() => super.carregarClienteAutenticado());
  }

  final _$definirClienteAsyncAction = AsyncAction('definirCliente');

  @override
  Future definirCliente(Cliente cliente) {
    return _$definirClienteAsyncAction.run(() => super.definirCliente(cliente));
  }

  final _$definirTokenAsyncAction = AsyncAction('definirToken');

  @override
  Future definirToken(String token) {
    return _$definirTokenAsyncAction.run(() => super.definirToken(token));
  }

  final _$sairAsyncAction = AsyncAction('sair');

  @override
  Future sair() {
    return _$sairAsyncAction.run(() => super.sair());
  }

  @override
  String toString() {
    final string = 'cliente: ${cliente.toString()},token: ${token.toString()}';
    return '{$string}';
  }
}
