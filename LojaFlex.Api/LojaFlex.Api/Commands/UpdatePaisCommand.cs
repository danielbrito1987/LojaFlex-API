namespace LojaFlex.Api.Commands
{
    public class UpdatePaisCommand
    {
        public int IdPais { get; set; }
        public string DscPais { get; set; }
        public string? Sigla { get; set; }
    }
}
