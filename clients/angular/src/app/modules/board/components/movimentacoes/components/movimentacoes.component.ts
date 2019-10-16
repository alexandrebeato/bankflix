import { Component, OnInit } from '@angular/core';
import { ContasService } from '../../../services/contas.service';
import { Conta } from 'src/app/models/clientes/conta';
import { Movimentacao } from 'src/app/models/movimentacoes/movimentacao';
import { MovimentacoesService } from '../../../services/movimentacoes.service';
import { TipoMovimentacao } from 'src/app/models/movimentacoes/enums/tipo-movimentacao';
import { TipoVinculado } from 'src/app/models/movimentacoes/enums/tipo-vinculado';

@Component({
    selector: 'app-movimentacoes',
    templateUrl: '../pages/movimentacoes.component.html',
    styleUrls: ['../styles/movimentacoes.component.scss']
})
export class MovimentacoesComponent implements OnInit {

    minhaConta: Conta;
    obtendoMinhaConta = true;
    minhasMovimentacoes: Movimentacao[] = [];
    obtendoMinhasMovimentacoes = true;

    constructor(
        private contasService: ContasService,
        private movimentacoesService: MovimentacoesService
    ) { }

    ngOnInit(): void {
        this.obterDadosMinhaConta();
        this.obterMinhasMovimentacoes();
    }

    obterDadosMinhaConta(): void {
        this.obtendoMinhaConta = true;

        this.contasService.obterMinhaConta().subscribe(
            contaRetorno => {
                this.minhaConta = contaRetorno;
                this.obtendoMinhaConta = false;
            }
        );
    }

    obterMinhasMovimentacoes(): void {
        this.obtendoMinhasMovimentacoes = true;
        this.movimentacoesService.obterMinhasMovimentacoes().subscribe(
            movimentacoesRetorno => {
                this.minhasMovimentacoes = movimentacoesRetorno;
                this.obtendoMinhasMovimentacoes = false;
            }
        );
    }

    obterFormatacaoTipo(tipo: TipoMovimentacao): { texto: string, cor: string, operacao: string } {
        switch (tipo) {
            case TipoMovimentacao.Entrada: {
                return { texto: 'Entrada', cor: 'text-success', operacao: '+' };
            }
            case TipoMovimentacao.Saida: {
                return { texto: 'Saída', cor: 'text-danger', operacao: '-' };
            }
        }
    }

    obterTipoVinculoTexto(tipo: TipoVinculado): string {
        switch (tipo) {
            case TipoVinculado.Deposito: {
                return 'Depósito';
            }
            case TipoVinculado.Transferencia: {
                return 'Transferência';
            }
        }
    }
}
