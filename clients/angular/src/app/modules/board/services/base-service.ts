import { environment } from 'src/environments/environment';
import { HttpHeaders } from '@angular/common/http';
import { LocalStorageUtils } from 'src/app/utils/storage/local-storage-utils';

export abstract class BaseService {
    public apiUrl = environment.apiUrl;

    protected obterTokenJson() {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${LocalStorageUtils.obterClienteToken()}`
            })
        };
    }

    protected obterTokenStream() {
        return {
            headers: new HttpHeaders({
                'Authorization': `Bearer ${LocalStorageUtils.obterClienteToken()}`
            })
        };
    }

    protected extractData(response: any) {
        return response.data || {};
    }
}
