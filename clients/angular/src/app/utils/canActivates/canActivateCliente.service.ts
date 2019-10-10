import { Injectable } from '@angular/core';
import { CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageUtils } from '../storage/local-storage-utils';

@Injectable()
export class CanActivateClienteGuard implements CanActivateChild {

    constructor(private router: Router) { }

    canActivateChild(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {

        const clienteToken = LocalStorageUtils.obterClienteToken();

        if (!clienteToken) {
            this.router.navigate(['/']);
            return false;
        }

        return true;
    }
}
