import { Component, OnInit } from '@angular/core';
import { ContasService } from '../../../services/contas.service';
import { Conta } from 'src/app/models/clientes/conta';

@Component({
    selector: 'app-movimentacoes',
    templateUrl: '../pages/movimentacoes.component.html',
    styleUrls: ['../styles/movimentacoes.component.scss']
})
export class MovimentacoesComponent implements OnInit {

    minhaConta: Conta;
    obtendoMinhaConta = true;

    constructor(
        private contasService: ContasService
    ) { }

    ngOnInit(): void {
        this.obterDadosMinhaConta();
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
}
