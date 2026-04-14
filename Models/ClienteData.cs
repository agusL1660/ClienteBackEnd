using ClienteBackend.Models;

namespace ClienteBackEnd.Data;

public static class ClienteData
{
    public static List<Cliente> Lista = new List<Cliente>
    {
        new Cliente { 
            Id = 1, 
            Nombre = "Agustin", 
            Apellido = "Lelli", 
            Direccion = "Domicilio 123" }
    };
}