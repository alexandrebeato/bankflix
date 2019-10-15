import { Cliente } from 'src/app/models/clientes/cliente';

export class LocalStorageUtils {
    private static clienteKey = 'bankflix.cliente';
    private static clienteToken = 'bankflix.cliente.token';

    private static agenciaKey = 'bankflix.agencia';
    private static agenciaToken = 'bankflix.agencia.token';

    public static obterClienteToken(): string {
        return localStorage.getItem(this.clienteToken);
    }

    public static definirClienteToken(token: string): void {
        localStorage.setItem(this.clienteToken, token);
    }

    public static definirCliente(cliente: Cliente): void {
        localStorage.setItem(this.clienteKey, JSON.stringify(cliente));
    }

    public static obterCliente(): Cliente {
        return JSON.parse(localStorage.getItem(this.clienteKey));
    }

    public static obterAgenciaToken(): string {
        return localStorage.getItem(this.agenciaToken);
    }

    public static definirAgenciaToken(token: string): void {
        localStorage.setItem(this.agenciaToken, token);
    }

    public static limparTudo(): void {
        localStorage.clear();
    }
}
