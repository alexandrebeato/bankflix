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

  final _$_ClienteControllerActionController =
      ActionController(name: '_ClienteController');

  @override
  dynamic carregarClienteAutenticado() {
    final _$actionInfo = _$_ClienteControllerActionController.startAction();
    try {
      return super.carregarClienteAutenticado();
    } finally {
      _$_ClienteControllerActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic sair() {
    final _$actionInfo = _$_ClienteControllerActionController.startAction();
    try {
      return super.sair();
    } finally {
      _$_ClienteControllerActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    final string = 'cliente: ${cliente.toString()}';
    return '{$string}';
  }
}
