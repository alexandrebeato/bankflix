import 'package:bankflix/enums/situacao-transferencia.enum.dart';
import 'package:flutter/material.dart';

class SituacaoTransferenciaIconeWidget extends StatelessWidget {
  final SituacaoTransferencia situacaoTransferencia;

  const SituacaoTransferenciaIconeWidget(
      {@required this.situacaoTransferencia});

  @override
  Widget build(BuildContext context) {
    switch (situacaoTransferencia) {
      case SituacaoTransferencia.Efetuada:
        return Icon(
          Icons.check_circle,
          color: Color(0xFF27AE60),
        );
      case SituacaoTransferencia.Recusada:
        return Icon(
          Icons.block,
          color: Color(0xFFC0392B),
        );
      case SituacaoTransferencia.Pendente:
        return Icon(
          Icons.access_time,
          color: Color(0xFF2980B9),
        );
      default:
        return null;
    }
  }
}
