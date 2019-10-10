import { Injectable } from '@angular/core';
import { CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageUtils } from '../storage/local-storage-utils';

@Injectable()
export class CanActivateAutenticacaoGuard implements CanActivateChild {

    constructor(private router: Router) { }

    canActivateChild(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {

        const clienteToken = LocalStorageUtils.obterClienteToken();
        const agenciaToken = LocalStorageUtils.obterAgenciaToken();

        if (!clienteToken && !agenciaToken) {
            return true;
        }

        if (clienteToken && agenciaToken) {
            LocalStorageUtils.limparTudo();
            return true;
        }

        if (clienteToken) {
            this.router.navigate(['/board']);
            return false;
        }

        if (agenciaToken) {
            this.router.navigate(['/agencia']);
            return false;
        }

        return true;
    }
}
