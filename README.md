<p align="center">
  <img alt="trivelum logo" src="logo.png" />
</p>

## Sobre
O projeto **Bankflix** simula um banco digital, contendo a área do cliente e administrativa, permitindo depósitos e transferências entre contas do mesmo banco..

## Dê uma estrela! :star:
Se você gostou do projeto ou se ele te ajudou, por favor dê uma estrela ;)

## Atenção
Este não é um projeto para ser utilizado em produção. Ele é apenas uma demonstração do uso das tecnologias e da arquitetura em que foi construído. **Existem ajustes e melhorias a serem feitos**.

## Dados para acesso da agência

**CNPJ:** 03569262000160

**Senha** 123456

## Informações importantes
- Todos os valores internamente são tratados como centavos convertidos para R$ apenas na exibição ao cliente
- Os eventos orquestrados por filas terão um delay de 30 segundos apenas para percepção do uso da fila.
- O contexto de AGÊNCIA não possui CQRS para demonstrar que pode-se manter diferentes padrões conforme a necessidade.
- É possível acompanhar o ACK manual com sistema de filas re-inserindo a transação na fila caso haja alguma falha.
- Os containeres **não** estão utilizando volumes, portanto ao matá-los irá causar a perda dos dados.

## Fluxo
- Ao iniciar a aplicação pela primeira vez será cadastrado uma agência com um usuário administrador
- Ao criar sua conta o cliente ficará com o status pendente até que o usuário administrador aprove seu cadastro.
- Ao aprovar ou recusar, será disparado um evento de envio de e-mail (apenas simulando, não envia realmente) notificando o cliente.
- Ao aprovar, será criada uma conta bancária automaticamente vinculada ao cliente com saldo zerado.
- O cliente poderá realizar depositos online (simulado, pode-se colocar o valor que quiser) que ao cadastrado ficará como pendente, sendo adicionado na fila para ser efetuado.
- O cliente poderá realizar uma transferência para outras contas que ao solicitar a transferência ela ficará como pendente, sendo adicionada na fila para ser efetuada ou cancelada.
- Quando o depósito ou transferência forem efetuados/recusados (cancelado) será disparado um evento de envio de e-mail (apenas simulando, não envia realmente) notificando os clientes.
- Quando o depósito ou transferência forem efetuados com sucesso, será registrada a movimentação.-

## Autor 👦

* **Alexandre Beato** - *Desenvolvedor* - [GitHub](https://github.com/alexandrebeato)

## License 📃

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details