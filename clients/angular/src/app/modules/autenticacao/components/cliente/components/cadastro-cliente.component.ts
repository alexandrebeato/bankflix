import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-cadastro-cliente',
    templateUrl: '../pages/cadastro-cliente.component.html'
})
export class CadastroClienteComponent implements OnInit {

    esconderSenha = true;
    esconderConfirmacaoSenha = true;

    constructor() { }

    ngOnInit(): void { }
}
