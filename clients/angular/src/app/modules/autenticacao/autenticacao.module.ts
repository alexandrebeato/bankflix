import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AutenticacaoRoutingModule } from './autenticacao-routing.module';
import { AutenticacaoComponent } from './autenticacao.component';
import { CadastroClienteComponent } from './components/cliente/components/cadastro-cliente.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgxMaskModule } from 'ngx-mask';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatDividerModule } from '@angular/material/divider';
import { ClientesService } from './services/clientes.service';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { LoginAgenciaComponent } from './components/agencia/components/login-agencia.component';
import { AgenciaService } from './services/agencias.service';

@NgModule({
    declarations: [
        AutenticacaoComponent,
        CadastroClienteComponent,
        LoginAgenciaComponent
    ],
    imports: [
        CommonModule,
        AutenticacaoRoutingModule,
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatDatepickerModule,
        NgxMaskModule.forRoot(),
        MatProgressBarModule,
        MatDividerModule,
        ReactiveFormsModule,
        MatSnackBarModule
    ],
    exports: [],
    providers: [
        ClientesService,
        AgenciaService
    ],
})

export class AutenticacaoModule { }
