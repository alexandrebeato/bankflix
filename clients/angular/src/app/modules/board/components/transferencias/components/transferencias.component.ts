import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TransferenciasService } from '../../../services/transferencias.service';
import { Transferencia } from 'src/app/models/movimentacoes/transferencia';
import { SituacaoTransferencia } from 'src/app/models/movimentacoes/enums/situacao-transferencia';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-transferencias',
    templateUrl: '../pages/transferencias.component.html',
    styleUrls: ['../styles/transferencias.component.scss']
})
export class TransferenciasComponent implements OnInit {

    minhasTransferenciasRealizadas: Transferencia[] = [];
    minhasTransferenciasRecebidas: Transferencia[] = [];
    obtendoMinhasTransferenciasRealizadas = true;
    obtendoMinhasTransferenciasRecebidas = true;
    solicitandoTransferencia = false;
    formTransferencia: FormGroup;

    constructor(
        private transferenciasService: TransferenciasService,
        private snackBar: MatSnackBar,
        private formBuilder: FormBuilder
    ) {
        this.formTransferencia = this.obterFormularioTransferencia();
    }

    ngOnInit(): void {
        this.obterTransferencias();
    }

    obterTransferencias(): void {
        this.obterTransferenciasRealizadas();
        this.obterTransferenciasRecebidas();
    }

    obterTransferenciasRealizadas(): void {
        this.obtendoMinhasTransferenciasRealizadas = true;

        this.transferenciasService.obterMinhasTransferenciasRealizadas().subscribe(
            transferenciasRetorno => {
                this.minhasTransferenciasRealizadas = transferenciasRetorno;
                this.obtendoMinhasTransferenciasRealizadas = false;
            }
        );
    }

    obterTransferenciasRecebidas(): void {
        this.obtendoMinhasTransferenciasRecebidas = true;

        this.transferenciasService.obterMinhasTransferenciasRecebidas().subscribe(
            transferenciasRetorno => {
                this.minhasTransferenciasRecebidas = transferenciasRetorno;
                this.obtendoMinhasTransferenciasRecebidas = false;
            }
        );
    }

    obterFormatacaoSituacao(situacao: SituacaoTransferencia): { texto: string, cor: string } {
        switch (situacao) {
            case (SituacaoTransferencia.Pendente): {
                return { texto: 'Pendente', cor: 'text-info' };
            }
            case (SituacaoTransferencia.Efetuada): {
                return { texto: 'Efetuada', cor: 'text-success' };
            }
            case (SituacaoTransferencia.Recusada): {
                return { texto: 'Recusada', cor: 'text-danger' };
            }
        }
    }

    solicitarTransferencia(): void {
        this.solicitandoTransferencia = true;
        const numeroContaDestino = this.formTransferencia.controls.numeroContaDestino.value;
        const digitoVerificadorContaDestino = this.formTransferencia.controls.digitoVerificadorContaDestino.value;
        const valor = +(this.formTransferencia.controls.valor.value.toString().replace(',', '.'));
        this.transferenciasService.solicitarTransferencia(numeroContaDestino, digitoVerificadorContaDestino, valor).subscribe(
            () => {
                this.snackBar.open('Transferência enviada.', 'Ok');
                this.solicitandoTransferencia = false;
                this.formTransferencia.reset();
                this.obterTransferenciasRealizadas();
            },
            erroResponse => {
                this.solicitandoTransferencia = false;
                this.exibirErros(erroResponse);
            }
        );
    }

    exibirErros(erroResponse: HttpErrorResponse): void {
        erroResponse.error.errors.forEach(erro => {
            this.snackBar.open(erro, 'Ok');
        });
    }

    obterFormularioTransferencia(): FormGroup {
        return this.formBuilder.group({
            numeroContaDestino: ['', Validators.required],
            digitoVerificadorContaDestino: ['', Validators.required],
            valor: [0, [Validators.required, Validators.min(1)]]
        });
    }
}
