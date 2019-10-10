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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
