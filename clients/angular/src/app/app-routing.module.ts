import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    // canActivateChild: [RoutePermissionsAutenticacaoService],
    loadChildren: () => import('./modules/autenticacao/autenticacao.module').then(m => m.AutenticacaoModule)
  },
  {
    path: 'board',
    // canActivateChild: [RoutePermissionsAutenticacaoService],
    loadChildren: () => import('./modules/board/board.module').then(m => m.BoardModule)
  },
  {
    path: 'agencia',
    // canActivateChild: [RoutePermissionsAutenticacaoService],
    loadChildren: () => import('./modules/agencia/agencia.module').then(m => m.AgenciaModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
