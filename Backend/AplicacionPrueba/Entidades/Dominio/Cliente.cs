namespace Entidades.Dominio
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string NumeroTelefono { get; set; }
        public bool IndicaEliminado { get; set; }
    }
}