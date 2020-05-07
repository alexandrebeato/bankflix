import 'dart:io';
import 'package:dio/dio.dart';
import '../settings.dart';

abstract class Repository {
  Options obterHeadersAutenticacao() {
    return Options(
        headers: {HttpHeaders.authorizationHeader: "Bearer ${Settings.token}"});
  }
}
