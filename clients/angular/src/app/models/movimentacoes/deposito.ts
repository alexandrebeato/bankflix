import { SituacaoDeposito } from './enums/situacao-deposito';

export class Deposito {
    id: string;
    conta: Conta;
    valorEmReais: number;
    situacao: SituacaoDeposito;
    motivoCancelamento: string;
    dataHoraCriacao: string;
}

export class Conta {
    public id: string;
    public numero: string;
    public digitoVerificador: string;
    public cliente: Cliente;
}

export class Cliente {
    public id: string;
    public nomeCompleto: string;
    public cpf: string;
}
