import { Component, OnInit } from '@angular/core';
import { LocalStorageUtils } from 'src/app/utils/storage/local-storage-utils';
import { Router } from '@angular/router';

@Component({
    selector: 'app-board',
    templateUrl: './board.component.html',
    styleUrls: ['board.component.scss']
})
export class BoardComponent implements OnInit {
    constructor(
        private router: Router
    ) { }

    ngOnInit(): void { }

    sair(): void {
        LocalStorageUtils.limparTudo();
        this.router.navigate(['/']);
    }
}
