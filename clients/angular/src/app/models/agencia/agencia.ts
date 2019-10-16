import { DadosBancarios } from './dados-bancarios';

export class Agencia {
    public id: string;
    public razaoSocial: string;
    public nomeFantasia: string;
    public cnpj: string;
    public dadosBancarios: DadosBancarios;
}
