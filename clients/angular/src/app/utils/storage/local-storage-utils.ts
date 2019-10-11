export class LocalStorageUtils {
    private static clienteKey = 'bankflix.cliente';
    private static clienteToken = 'bankflix.cliente.token';

    private static agenciaKey = 'bankflix.agencia';
    private static agenciaToken = 'bankflix.agencia.token';

    public static obterClienteToken(): string {
        return localStorage.getItem(this.clienteToken);
    }

    public static obterAgenciaToken(): string {
        return localStorage.getItem(this.agenciaToken);
    }

    public static limparTudo(): void {
        localStorage.clear();
    }
}
