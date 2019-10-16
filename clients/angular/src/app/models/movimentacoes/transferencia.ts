export class Transferencia {
    public id: string;
    public contaOrigem: Conta;
    public contaDestino: Conta;
    public valorEmReais: number;
    public motivoRecusa: string;
    public dataHoraCriacao: string;
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
