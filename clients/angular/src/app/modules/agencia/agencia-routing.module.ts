import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AgenciaComponent } from './agencia.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';
import { ClientesPendentesComponent } from './components/clientes-pendentes/components/clientes-pendentes.component';

const routes: Routes = [
    {
        path: '', component: AgenciaComponent,
        children: [
            { path: '', component: MovimentacoesComponent },
            { path: 'movimentacoes', component: MovimentacoesComponent },
            { path: 'clientes-pendentes', component: ClientesPendentesComponent }
        ]
    }
];

@NgModule({
    imports: [CommonModule, RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AgenciaRoutingModule { }
