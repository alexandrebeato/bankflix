import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../../services/clientes.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';
import { Cliente } from 'src/app/models/clientes/cliente';
import { LocalStorageUtils } from 'src/app/utils/storage/local-storage-utils';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-cadastro-cliente',
    templateUrl: '../pages/cadastro-cliente.component.html'
})
export class CadastroClienteComponent {

    esconderSenhaCadastro = true;
    esconderConfirmacaoSenhaCadastro = true;
    esconderSenhaLogin = true;
    formCadastro: FormGroup;
    cadastrandoCliente = false;
    formLogin: FormGroup;
    logando = false;

    constructor(
        private clientesService: ClientesService,
        private formBuilder: FormBuilder,
        private router: Router,
        private snackBar: MatSnackBar
    ) {
        this.formCadastro = this.obterFormularioCadastro();
        this.formLogin = this.obterFormularioLogin();
    }

    cadastrar(): void {
        this.cadastrandoCliente = true;
        const cliente: Cliente = this.formCadastro.value;
        cliente.dataNascimento = cliente.dataNascimento.split('/').reverse().join('-');

        this.clientesService.cadastrar(cliente).subscribe(
            cadastroResponse => {
                LocalStorageUtils.definirClienteToken(cadastroResponse.token);
                LocalStorageUtils.definirCliente(cadastroResponse.cliente);
                this.cadastrandoCliente = false;
                this.router.navigate(['board']);
            },
            erroResponse => {
                this.cadastrandoCliente = false;
                this.exibirErros(erroResponse);
                console.log(erroResponse);
            }
        );
    }

    login(): void {
        this.logando = true;

        this.clientesService.login(this.formLogin.value).subscribe(
            loginResponse => {
                LocalStorageUtils.definirClienteToken(loginResponse.token);
                LocalStorageUtils.definirCliente(loginResponse.cliente);
                this.router.navigate(['board']);
                this.logando = false;
            },
            erroResponse => {
                this.logando = false;
                this.exibirErros(erroResponse);
                console.log(erroResponse);
            }
        );
    }

    obterFormularioCadastro(): FormGroup {
        let senha = new FormControl('', Validators.required);
        let confirmacaoSenha = new FormControl('', CustomValidators.equalTo(senha));

        return this.formBuilder.group({
            nomeCompleto: ['', Validators.required],
            cpf: [''],
            dataNascimento: ['', Validators.required],
            email: ['', Validators.required],
            telefone: ['', Validators.required],
            senha,
            confirmacaoSenha
        });
    }

    obterFormularioLogin(): FormGroup {
        return this.formBuilder.group({
            cpf: ['', Validators.required],
            senha: ['', Validators.required]
        });
    }

    private exibirErros(erroResponse: HttpErrorResponse): void {
        erroResponse.error.errors.forEach(erro => {
            this.snackBar.open(erro, 'Ok');
        });
    }
}
