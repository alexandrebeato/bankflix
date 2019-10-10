export class LocalStorageUtils {
    private static clienteKey = 'bankflix.cliente';
    private static clienteToken = 'bankflix.cliente.token';

    private static agenciaKey = 'bankflix.agencia';
    private static agenciaToken = 'bankflix.agencia.token';

    public static obterClienteToken(): string {
        return localStorage.getItem(this.clienteKey);
    }

    public static obterAgenciaToken(): string {
        return localStorage.getItem(this.agenciaKey);
    }

    public static limparTudo(): void {
        localStorage.clear();
    }
}
