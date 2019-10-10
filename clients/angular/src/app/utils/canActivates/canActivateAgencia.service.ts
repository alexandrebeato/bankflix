import { Injectable } from '@angular/core';
import { CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageUtils } from '../storage/local-storage-utils';

@Injectable()
export class CanActivateAgenciaGuard implements CanActivateChild {

    constructor(private router: Router) { }

    canActivateChild(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {

        const agenciaToken = LocalStorageUtils.obterAgenciaToken();

        if (!agenciaToken) {
            this.router.navigate(['/']);
            return false;
        }

        return true;
    }
}
