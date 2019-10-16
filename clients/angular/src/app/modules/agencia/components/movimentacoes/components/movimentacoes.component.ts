import { Component, OnInit } from '@angular/core';
import { MovimentacoesService } from '../../../services/movimentacoes.service';
import { Movimentacao } from 'src/app/models/movimentacoes/movimentacao';
import { TipoMovimentacao } from 'src/app/models/movimentacoes/enums/tipo-movimentacao';
import { TipoVinculado } from 'src/app/models/movimentacoes/enums/tipo-vinculado';

@Component({
    selector: 'app-movimentacoes',
    templateUrl: '../pages/movimentacoes.component.html'
})
export class MovimentacoesComponent implements OnInit {

    dataInicial = '';
    dataFinal = '';
    obtendoMovimentacoes = false;
    jaPesquisado = false;
    movimentacoes: Movimentacao[] = [];

    constructor(
        private movimentacoesService: MovimentacoesService
    ) { }

    ngOnInit(): void { }

    obterPorPeriodo(): void {
        if (!this.dataInicial || !this.dataFinal) {
            return;
        }

        this.obtendoMovimentacoes = true;
        this.jaPesquisado = true;

        this.movimentacoesService
            .obterPorPeriodo(this.dataInicial.split('/').reverse().join('-'), this.dataFinal.split('/').reverse().join('-')).subscribe(
                movimentacoesRetorno => {
                    this.movimentacoes = movimentacoesRetorno;
                    this.obtendoMovimentacoes = false;
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
