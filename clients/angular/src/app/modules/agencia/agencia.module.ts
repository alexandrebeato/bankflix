import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgenciaRoutingModule } from './agencia-routing.module';
import { AgenciaComponent } from './agencia.component';
import { MovimentacoesComponent } from './components/movimentacoes/components/movimentacoes.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { ClientesPendentesComponent } from './components/clientes-pendentes/components/clientes-pendentes.component';
import { ClientesService } from './services/clientes.service';
import { NgxMaskModule } from 'ngx-mask';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
    declarations: [
        AgenciaComponent,
        MovimentacoesComponent,
        ClientesPendentesComponent
    ],
    imports: [
        CommonModule,
        AgenciaRoutingModule,
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
        NgxMaskModule.forChild(),
        MatSnackBarModule
    ],
    exports: [],
    providers: [
        ClientesService
    ],
})

export class AgenciaModule { }
