import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transferencia } from 'src/app/models/movimentacoes/transferencia';

@Injectable()
export class TransferenciasService extends BaseService {
    constructor(private httpClient: HttpClient) {
        super();
    }

    obterMinhasTransferenciasRealizadas(): Observable<Transferencia[]> {
        return this.httpClient.get<Transferencia[]>
            (this.apiUrl + 'transferencias/minhas-realizadas', super.obterTokenJson());
    }

    obterMinhasTransferenciasRecebidas(): Observable<Transferencia[]> {
        return this.httpClient.get<Transferencia[]>
            (this.apiUrl + 'transferencias/minhas-recebidas', super.obterTokenJson());
    }

    solicitarTransferencia(numeroContaDestino: string, digitoVerificadorContaDestino: string, valor: number): Observable<Transferencia> {
        return this.httpClient.post<Transferencia>
            (
                this.apiUrl + 'transferencias/solicitar',
                { numeroContaDestino, digitoVerificadorContaDestino, valor: +valor },
                super.obterTokenJson()
            );
    }
}
