import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgenciaRoutingModule } from './agencia-routing.module';
import { AgenciaComponent } from './agencia.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';

@NgModule({
    declarations: [
        AgenciaComponent,
        MovimentacoesComponent
    ],
    imports: [
        CommonModule,
        AgenciaRoutingModule],
    exports: [],
    providers: [],
})

export class AgenciaModule { }
