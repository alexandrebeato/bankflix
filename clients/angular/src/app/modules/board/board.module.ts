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
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { DepositosComponent } from './components/depositos/components/depositos.component';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { TransferenciasComponent } from './components/transferencias/components/transferencias.component';
import { ContasService } from './services/contas.service';
import { DepositosService } from './services/depositos.service';
import { NgxMaskModule } from 'ngx-mask';
import { FormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
    declarations: [
        BoardComponent,
        MovimentacoesComponent,
        DepositosComponent,
        TransferenciasComponent
    ],
    imports: [
        CommonModule,
        BoardRoutingModule,
        MatSidenavModule,
        MatToolbarModule,
        MatListModule,
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule,
        MatCardModule,
        MatExpansionModule,
        MatInputModule,
        MatProgressSpinnerModule,
        MatProgressBarModule,
        NgxMaskModule.forRoot(),
        FormsModule,
        MatSnackBarModule
    ],
    exports: [],
    providers: [
        ContasService,
        DepositosService
    ],
})

export class BoardModule { }
