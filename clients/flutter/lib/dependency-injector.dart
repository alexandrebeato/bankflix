import 'package:bankflix/controllers/cadastrar-cliente.controller.dart';
import 'package:bankflix/controllers/cliente.controller.dart';
import 'package:provider/provider.dart';
import 'package:provider/single_child_widget.dart';

class DependencyInjector {
  static List<SingleChildWidget> obterDependencias() {
    return <SingleChildWidget>[
      Provider<ClienteController>(create: (_) => ClienteController()),
      Provider<CadastrarClienteController>(
          create: (_) => CadastrarClienteController()),
    ];
  }
}
