import { Component, OnInit } from '@angular/core';
import { LocalStorageUtils } from 'src/app/utils/storage/local-storage-utils';
import { Router } from '@angular/router';

@Component({
    selector: 'app-agencia',
    templateUrl: './agencia.component.html',
    styleUrls: ['./agencia.component.scss']
})
export class AgenciaComponent implements OnInit {
    constructor(private router: Router) { }

    ngOnInit(): void { }

    sair(): void {
        LocalStorageUtils.limparTudo();
        this.router.navigate(['/administrativa']);
    }
}
