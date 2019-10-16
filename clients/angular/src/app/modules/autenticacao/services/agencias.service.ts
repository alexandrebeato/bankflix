import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { Observable } from 'rxjs';
import { Agencia } from 'src/app/models/agencia/agencia';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AgenciaService extends BaseService {
    constructor(private httpClient: HttpClient) {
        super();
    }

    login(agencia: { cnpj: string, senha: string }): Observable<{ token: string, agencia: Agencia }> {
        return this.httpClient.post<{ token: string, agencia: Agencia }>
            (this.apiUrl + 'agencia/login', agencia);
    }
}
