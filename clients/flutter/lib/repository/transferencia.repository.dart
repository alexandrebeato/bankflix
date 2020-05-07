import 'package:bankflix/models/transferencias/solicitar-transferencia.model.dart';
import 'package:bankflix/models/transferencias/transferencia.model.dart';
import 'package:bankflix/repository/repository.dart';
import 'package:bankflix/settings.dart';
import 'package:dio/dio.dart';

class TransferenciaRepository extends Repository {
  Future<SolicitarTransferencia> solicitarTransferencia(
      SolicitarTransferencia solicitarTransferencia) async {
    var url = "${Settings.apiUrl}transferencias/solicitar";
    var response = await Dio().post(url,
        data: solicitarTransferencia, options: obterHeadersAutenticacao());
    return SolicitarTransferencia.fromJson(response.data);
  }

  Future<List<Transferencia>> obterMinhasRealizadas() async {
    var url = "${Settings.apiUrl}transferencias/minhas-realizadas";
    var response = await Dio().get(url, options: obterHeadersAutenticacao());
    return (response.data as List)
        .map((transferencia) => Transferencia.fromJson(transferencia))
        .toList();
  }

  Future<List<Transferencia>> obterMinhasRecebidas() async {
    var url = "${Settings.apiUrl}transferencias/minhas-recebidas";
    var response = await Dio().get(url, options: obterHeadersAutenticacao());
    return (response.data as List)
        .map((transferencia) => Transferencia.fromJson(transferencia))
        .toList();
  }
}
