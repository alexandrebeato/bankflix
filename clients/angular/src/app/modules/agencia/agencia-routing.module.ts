import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AgenciaComponent } from './agencia.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';

const routes: Routes = [
    {
        path: '', component: AgenciaComponent,
        children: [
            { path: '', component: MovimentacoesComponent },
            { path: 'movimentacoes', component: MovimentacoesComponent }
        ]
    }
];

@NgModule({
    imports: [CommonModule, RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AgenciaRoutingModule { }
