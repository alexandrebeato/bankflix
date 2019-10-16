import { Component, OnInit } from '@angular/core';
import { DepositosService } from '../../../services/depositos.service';
import { Deposito } from 'src/app/models/movimentacoes/deposito';
import { SituacaoDeposito } from 'src/app/models/movimentacoes/enums/situacao-deposito';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-depositos',
    templateUrl: '../pages/depositos.component.html',
    styleUrls: ['../styles/depositos.component.scss']
})
export class DepositosComponent implements OnInit {

    meusDepositos: Deposito[] = [];
    obtendoDepositos = true;
    valorSolicitarDeposito = '';
    solicitandoDeposito = false;

    constructor(
        private depositosService: DepositosService,
        private snackBar: MatSnackBar
    ) { }

    ngOnInit(): void {
        this.obterMeusDepositos();
    }

    obterMeusDepositos(): void {
        this.obtendoDepositos = true;

        this.depositosService.obterMeusDepositos().subscribe(
            depositosRetorno => {
                this.meusDepositos = depositosRetorno;
                this.obtendoDepositos = false;
            }
        );
    }

    obterFormatacaoSituacao(situacao: SituacaoDeposito): { texto: string, cor: string } {
        switch (situacao) {
            case (SituacaoDeposito.Pendente): {
                return { texto: 'Pendente', cor: 'text-info' };
            }
            case (SituacaoDeposito.Efetuado): {
                return { texto: 'Efetuado', cor: 'text-success' };
            }
            case (SituacaoDeposito.Cancelado): {
                return { texto: 'Cancelado', cor: 'text-danger' };
            }
        }
    }

    solicitarDeposito() {
        if (+this.valorSolicitarDeposito <= 0) {
            return;
        }

        this.solicitandoDeposito = true;
        this.depositosService.solicitarDeposito(+(this.valorSolicitarDeposito.toString().replace(',', '.'))).subscribe(
            () => {
                this.snackBar.open(`Depósito de ${this.valorSolicitarDeposito} reais solicitado.`, 'Ok');
                this.solicitandoDeposito = false;
                this.valorSolicitarDeposito = '';
                this.obterMeusDepositos();
            },
            erroResponse => {
                this.solicitandoDeposito = false;
                this.exibirErros(erroResponse);
            }
        );
    }

    exibirErros(erroResponse: HttpErrorResponse): void {
        erroResponse.error.errors.forEach(erro => {
            this.snackBar.open(erro, 'Ok');
        });
    }
}
