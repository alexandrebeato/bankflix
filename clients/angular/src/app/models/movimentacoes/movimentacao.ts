import { TipoVinculado } from './enums/tipo-vinculado';
import { TipoMovimentacao } from './enums/tipo-movimentacao';

export class Movimentacao {
    public id: string;
    public conta: Conta;
    public tipo: TipoMovimentacao;
    public vinculo: Vinculo;
    public valorEmReais: number;
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

export class Vinculo {
    public vinculadoId: string;
    public tipo: TipoVinculado;
}
