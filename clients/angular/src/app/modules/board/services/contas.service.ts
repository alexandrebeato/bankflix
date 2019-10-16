import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Conta } from 'src/app/models/clientes/conta';

@Injectable()
export class ContasService extends BaseService {
    constructor(private httpClient: HttpClient) {
        super();
    }

    obterMinhaConta(): Observable<Conta> {
        return this.httpClient.get<Conta>
            (this.apiUrl + 'contas/minha', super.obterTokenJson());
    }
}

