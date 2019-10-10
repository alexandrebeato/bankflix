import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AutenticacaoRoutingModule } from './autenticacao-routing.module';
import { AutenticacaoComponent } from './autenticacao.component';
import { CadastroClienteComponent } from './components/cliente/components/cadastro-cliente.component';

@NgModule({
    declarations: [
        AutenticacaoComponent,
        CadastroClienteComponent
    ],
    imports: [
        CommonModule,
        AutenticacaoRoutingModule
    ],
    exports: [],
    providers: [],
})

export class AutenticacaoModule { }