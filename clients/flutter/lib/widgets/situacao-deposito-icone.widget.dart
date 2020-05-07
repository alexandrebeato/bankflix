import 'package:bankflix/enums/situacao-deposito.enum.dart';
import 'package:flutter/material.dart';

class SituacaoDepositoIconeWidget extends StatelessWidget {
  final SituacaoDeposito situacaoDeposito;

  const SituacaoDepositoIconeWidget({@required this.situacaoDeposito});

  @override
  Widget build(BuildContext context) {
    switch (situacaoDeposito) {
      case SituacaoDeposito.Efetuado:
        return Icon(
          Icons.check_circle,
          color: Color(0xFF27AE60),
        );
      case SituacaoDeposito.Cancelado:
        return Icon(
          Icons.block,
          color: Color(0xFFC0392B),
        );
      case SituacaoDeposito.Pendente:
        return Icon(
          Icons.access_time,
          color: Color(0xFF2980B9),
        );
      default:
        return null;
    }
  }
}
