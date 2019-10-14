import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BoardComponent } from './board.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';
import { DepositosComponent } from './components/depositos/components/depositos.component';
import { TransferenciasComponent } from './components/transferencias/components/transferencias.component';

const routes: Routes = [{
    path: '', component: BoardComponent,
    children: [
        { path: '', component: MovimentacoesComponent },
        { path: 'movimentacoes', component: MovimentacoesComponent },
        { path: 'depositos', component: DepositosComponent },
        { path: 'transferencias', component: TransferenciasComponent }
    ]
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class BoardRoutingModule { }
