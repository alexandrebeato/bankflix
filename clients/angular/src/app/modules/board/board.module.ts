import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardComponent } from './board.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';
import { BoardRoutingModule } from './board-routing.module';

@NgModule({
    declarations: [
        BoardComponent,
        MovimentacoesComponent
    ],
    imports: [
        CommonModule,
        BoardRoutingModule
    ],
    exports: [],
    providers: [],
})

export class BoardModule { }