import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardComponent } from './board.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';
import { BoardRoutingModule } from './board-routing.module';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
    declarations: [
        BoardComponent,
        MovimentacoesComponent
    ],
    imports: [
        CommonModule,
        BoardRoutingModule,
        MatSidenavModule,
        MatToolbarModule,
        MatListModule,
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule
    ],
    exports: [],
    providers: [],
})

export class BoardModule { }
