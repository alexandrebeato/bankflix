// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cadastrar-cliente.controller.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$CadastrarClienteController on _CadastrarClienteControllerBase, Store {
  final _$modelAtom = Atom(name: '_CadastrarClienteControllerBase.model');

  @override
  CadastrarCliente get model {
    _$modelAtom.context.enforceReadPolicy(_$modelAtom);
    _$modelAtom.reportObserved();
    return super.model;
  }

  @override
  set model(CadastrarCliente value) {
    _$modelAtom.context.conditionallyRunInAction(() {
      super.model = value;
      _$modelAtom.reportChanged();
    }, _$modelAtom, name: '${_$modelAtom.name}_set');
  }

  final _$_CadastrarClienteControllerBaseActionController =
      ActionController(name: '_CadastrarClienteControllerBase');

  @override
  dynamic definirNomeCompleto(String nomeCompleto) {
    final _$actionInfo =
        _$_CadastrarClienteControllerBaseActionController.startAction();
    try {
      return super.definirNomeCompleto(nomeCompleto);
    } finally {
      _$_CadastrarClienteControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    final string = 'model: ${model.toString()}';
    return '{$string}';
  }
}
