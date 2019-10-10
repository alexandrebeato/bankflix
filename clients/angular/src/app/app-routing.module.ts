import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanActivateAutenticacaoGuard } from './utils/canActivates/canActivateAutenticacao.service';
import { CanActivateAgenciaGuard } from './utils/canActivates/canActivateAgencia.service';
import { CanActivateClienteGuard } from './utils/canActivates/canActivateCliente.service';


const routes: Routes = [
  {
    path: '',
    canActivateChild: [CanActivateAutenticacaoGuard],
    loadChildren: () => import('./modules/autenticacao/autenticacao.module').then(m => m.AutenticacaoModule)
  },
  {
    path: 'board',
    canActivateChild: [CanActivateClienteGuard],
    loadChildren: () => import('./modules/board/board.module').then(m => m.BoardModule)
  },
  {
    path: 'agencia',
    canActivateChild: [CanActivateAgenciaGuard],
    loadChildren: () => import('./modules/agencia/agencia.module').then(m => m.AgenciaModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
