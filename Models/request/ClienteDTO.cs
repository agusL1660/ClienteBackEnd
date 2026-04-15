namespace ClienteBackend.Request;
using ClienteBackend.Models;

public class ClienteDTO
{
   public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;

    public static explicit operator ClienteDTO(Cliente c) 
    {
        return new ClienteDTO { Nombre = c.Nombre, Apellido = c.Apellido, Direccion = c.Direccion };
    }
}