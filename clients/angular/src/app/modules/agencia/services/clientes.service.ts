import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/models/clientes/cliente';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ClientesService extends BaseService {
    constructor(private httpClient: HttpClient) {
        super();
    }

    obterClientesPendentes(): Observable<Cliente[]> {
        return this.httpClient.get<Cliente[]>
            (this.apiUrl + 'clientes/pendentes', super.obterTokenJson());
    }

    aprovarCliente(id: string): Observable<any> {
        return this.httpClient.post<any>
            (this.apiUrl + `clientes/${id}/aprovar`, null, super.obterTokenJson());
    }

    recusarCliente(id: string): Observable<any> {
        return this.httpClient.post<any>
            (this.apiUrl + `clientes/${id}/recusar`, null, super.obterTokenJson());
    }
}
