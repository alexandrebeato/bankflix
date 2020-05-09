// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'login.controller.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$LoginController on _LoginControllerBase, Store {
  final _$modelAtom = Atom(name: '_LoginControllerBase.model');

  @override
  ClienteLogin get model {
    _$modelAtom.context.enforceReadPolicy(_$modelAtom);
    _$modelAtom.reportObserved();
    return super.model;
  }

  @override
  set model(ClienteLogin value) {
    _$modelAtom.context.conditionallyRunInAction(() {
      super.model = value;
      _$modelAtom.reportChanged();
    }, _$modelAtom, name: '${_$modelAtom.name}_set');
  }

  final _$erroResponseAtom = Atom(name: '_LoginControllerBase.erroResponse');

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

  final _$entrarAsyncAction = AsyncAction('entrar');

  @override
  Future<bool> entrar(ClienteController clienteController) {
    return _$entrarAsyncAction.run(() => super.entrar(clienteController));
  }

  final _$_LoginControllerBaseActionController =
      ActionController(name: '_LoginControllerBase');

  @override
  dynamic definirCpf(String cpf) {
    final _$actionInfo = _$_LoginControllerBaseActionController.startAction();
    try {
      return super.definirCpf(cpf);
    } finally {
      _$_LoginControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic definirSenha(String senha) {
    final _$actionInfo = _$_LoginControllerBaseActionController.startAction();
    try {
      return super.definirSenha(senha);
    } finally {
      _$_LoginControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic limparModel() {
    final _$actionInfo = _$_LoginControllerBaseActionController.startAction();
    try {
      return super.limparModel();
    } finally {
      _$_LoginControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    final string =
        'model: ${model.toString()},erroResponse: ${erroResponse.toString()}';
    return '{$string}';
  }
}
