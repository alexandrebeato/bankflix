import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../../services/clientes.service';
import { Cliente } from 'src/app/models/clientes/cliente';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-clientes-pendentes',
    templateUrl: '../pages/clientes-pendentes.component.html',
    styleUrls: ['../styles/clientes-pendentes.component.scss']
})
export class ClientesPendentesComponent implements OnInit {

    carregandoClientesPendentes = true;
    executandoAcao = false;
    clientesPendentes: Cliente[] = [];

    constructor(
        private clientesService: ClientesService,
        private snackBar: MatSnackBar
    ) { }

    ngOnInit(): void {
        this.obterClientesPendentes();
    }

    obterClientesPendentes(): void {
        this.carregandoClientesPendentes = true;

        this.clientesService.obterClientesPendentes().subscribe(
            clientesRetorno => {
                this.clientesPendentes = clientesRetorno;
                this.carregandoClientesPendentes = false;
            }
        );
    }

    aprovarCliente(id: string): void {
        this.executandoAcao = true;

        this.clientesService.aprovarCliente(id).subscribe(
            () => {
                this.clientesPendentes.splice(this.clientesPendentes.findIndex(c => c.id === id), 1);
                this.snackBar.open('Cliente aprovado com sucesso', 'Ok');
                this.executandoAcao = false;
            },
            erroResponse => {
                this.executandoAcao = false;
                this.exibirErros(erroResponse);
            }
        );
    }

    recusarCliente(id: string): void {
        this.executandoAcao = true;

        this.clientesService.recusarCliente(id).subscribe(
            () => {
                this.clientesPendentes.splice(this.clientesPendentes.findIndex(c => c.id === id), 1);
                this.snackBar.open('Cliente recusado com sucesso', 'Ok');
                this.executandoAcao = false;
            },
            erroResponse => {
                this.executandoAcao = false;
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
