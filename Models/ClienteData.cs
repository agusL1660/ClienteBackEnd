using ClienteBackend.Models;

namespace ClienteBackEnd.Data;

public class ClienteData
{
    public List<Cliente> Lista = new List<Cliente>
    {
        new Cliente { 
            Id = 1, 
            Nombre = "Agustin", 
            Apellido = "Lelli", 
            Direccion = "Domicilio 123" }
    };
}