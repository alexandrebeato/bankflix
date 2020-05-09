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

  final _$erroResponseAtom =
      Atom(name: '_CadastrarClienteControllerBase.erroResponse');

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

  final _$cadastrarAsyncAction = AsyncAction('cadastrar');

  @override
  Future<bool> cadastrar() {
    return _$cadastrarAsyncAction.run(() => super.cadastrar());
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
  dynamic definirCpf(String cpf) {
    final _$actionInfo =
        _$_CadastrarClienteControllerBaseActionController.startAction();
    try {
      return super.definirCpf(cpf);
    } finally {
      _$_CadastrarClienteControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic definirEmail(String email) {
    final _$actionInfo =
        _$_CadastrarClienteControllerBaseActionController.startAction();
    try {
      return super.definirEmail(email);
    } finally {
      _$_CadastrarClienteControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic definirTelefone(String telefone) {
    final _$actionInfo =
        _$_CadastrarClienteControllerBaseActionController.startAction();
    try {
      return super.definirTelefone(telefone);
    } finally {
      _$_CadastrarClienteControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic definirDataNascimento(String dataNascimento) {
    final _$actionInfo =
        _$_CadastrarClienteControllerBaseActionController.startAction();
    try {
      return super.definirDataNascimento(dataNascimento);
    } finally {
      _$_CadastrarClienteControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic definirSenha(String senha) {
    final _$actionInfo =
        _$_CadastrarClienteControllerBaseActionController.startAction();
    try {
      return super.definirSenha(senha);
    } finally {
      _$_CadastrarClienteControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    final string =
        'model: ${model.toString()},erroResponse: ${erroResponse.toString()}';
    return '{$string}';
  }
}
