import { SituacaoCliente } from './enums/situacao-cliente';

export class Cliente {
    public id: string;
    public nomeCompleto: string;
    public cpf: string;
    public dataNascimento: string;
    public email: string;
    public telefone: string;
    public situacao: SituacaoCliente;
    public dataHoraCriacao: string;
    public senha: string;
}
