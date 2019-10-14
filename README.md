<p align="center">
  <img alt="trivelum logo" src="logo.png" />
</p>

## Informações importantes
- Todos os valores internamente são tratados como centavos convertidos para R$ apenas na exibição ao cliente
- Os eventos orquestrados por filas terão um delay de 30 segundos apenas para percepção do uso da fila.
- O contexto de AGÊNCIA não possui CQRS para demonstrar que pode-se manter diferentes padrões conforme a necessidade.

## Fluxo
- Ao iniciar a aplicação pela primeira vez será cadastrado uma agência com um usuário administrador
- Ao criar sua conta o cliente ficará com o status pendente até que o usuário administrador aprove seu cadastro.
- Ao aprovar ou recusar, será disparado um evento de envio de e-mail (apenas simulando, não envia realmente) notificando o cliente.
- Ao aprovar, será criada uma conta bancária automaticamente vinculada ao cliente com saldo zerado.
- O cliente poderá realizar depositos online (simulado, pode-se colocar o valor que quiser) que ao cadastrado ficará como pendente, sendo adicionado na fila para ser efetuado.
- O cliente poderá realizar uma transferência para outras contas que ao solicitar a transferência ela ficará como pendente, sendo adicionada na fila para ser efetuada ou cancelada.
- Quando o depósito ou transferência forem efetuados/recusados (cancelado) será disparado um evento de envio de e-mail (apenas simulando, não envia realmente) notificando os clientes.
- Quando o depósito ou transferência forem efetuados com sucesso, será registrada a movimentação.-
