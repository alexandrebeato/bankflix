import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AgenciaService } from '../../../services/agencias.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';
import { LocalStorageUtils } from 'src/app/utils/storage/local-storage-utils';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login-agencia',
    templateUrl: '../pages/login-agencia.component.html'
})
export class LoginAgenciaComponent implements OnInit {

    private formLogin: FormGroup;
    esconderSenhaLogin = true;
    logando = false;

    constructor(
        private formBuilder: FormBuilder,
        private agenciaService: AgenciaService,
        private snackBar: MatSnackBar,
        private router: Router
    ) {
        this.formLogin = this.obterFormularioLogin();
    }

    ngOnInit(): void { }

    obterFormularioLogin(): FormGroup {
        return this.formBuilder.group({
            cnpj: ['', Validators.required],
            senha: ['', Validators.required]
        });
    }

    login(): void {
        this.logando = true;
        this.agenciaService.login(this.formLogin.value).subscribe(
            loginResponse => {
                LocalStorageUtils.definirAgenciaToken(loginResponse.token);
                LocalStorageUtils.definirAgencia(loginResponse.agencia);
                this.router.navigate(['/agencia']);
                this.logando = false;
            },
            erroResponse => {
                this.logando = false;
                this.exibirErros(erroResponse);
            }
        );
    }

    private exibirErros(erroResponse: HttpErrorResponse): void {
        erroResponse.error.errors.forEach(erro => {
            this.snackBar.open(erro, 'Ok');
        });
    }
}
