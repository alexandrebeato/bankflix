import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BoardComponent } from './board.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';

const routes: Routes = [{
    path: '', component: BoardComponent,
    children: [
        { path: '', component: MovimentacoesComponent },
        { path: 'movimentacoes', component: MovimentacoesComponent }
    ]
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class BoardRoutingModule { }
