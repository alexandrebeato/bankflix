import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutenticacaoComponent } from './autenticacao.component';
import { CadastroClienteComponent } from './components/cliente/components/cadastro-cliente.component';

const routes: Routes = [{
    path: '', component: AutenticacaoComponent,
    children: [
        { path: '', component: CadastroClienteComponent },
        { path: 'cadastro', component: CadastroClienteComponent }
    ]
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AutenticacaoRoutingModule { }
