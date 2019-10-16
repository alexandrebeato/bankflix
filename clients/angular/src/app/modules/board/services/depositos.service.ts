import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Deposito } from 'src/app/models/movimentacoes/deposito';

@Injectable()
export class DepositosService extends BaseService {
    constructor(private httpClient: HttpClient) {
        super();
    }

    obterMeusDepositos(): Observable<Deposito[]> {
        return this.httpClient.get<Deposito[]>
            (this.apiUrl + 'depositos/meus', super.obterTokenJson());
    }

    solicitarDeposito(valor: number): Observable<Deposito> {
        return this.httpClient.post<Deposito>
            (this.apiUrl + 'depositos/solicitar', { valor: +valor }, super.obterTokenJson());
    }
}
