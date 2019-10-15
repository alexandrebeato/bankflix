import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { Cliente } from 'src/app/models/clientes/cliente';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ClientesService extends BaseService {

    constructor(private httpClient: HttpClient) {
        super();
    }

    cadastrar(cliente: any): Observable<{ token: string, cliente: Cliente }> {
        return this.httpClient.post<{ token: string, cliente: Cliente }>
            (this.apiUrl + 'clientes/cadastrar', cliente);
    }

    login(cliente: { cpf: string, senha: string }): Observable<{ token: string, cliente: Cliente }> {
        return this.httpClient.post<{ token: string, cliente: Cliente }>
            (this.apiUrl + 'clientes/login', cliente);
    }
}
