import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movimentacao } from 'src/app/models/movimentacoes/movimentacao';

@Injectable()
export class MovimentacoesService extends BaseService {
    constructor(private httpClient: HttpClient) {
        super();
    }

    obterPorPeriodo(dataInicial: string, dataFinal: string): Observable<Movimentacao[]> {
        return this.httpClient.get<Movimentacao[]>
            (this.apiUrl + `movimentacoes/por-periodo?dataInicial=${dataInicial}&dataFinal=${dataFinal}`, super.obterTokenJson());
    }
}
