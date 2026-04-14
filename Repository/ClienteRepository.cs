using ClienteBackend.Models;
using ClienteBackEnd.Data;

namespace ClienteBackEnd.Repositories;

public class ClienteRepository
{
    public List<Cliente> ObtenerTodos() => ClienteData.Lista;

    public Cliente? ObtenerPorId(int id) => ClienteData.Lista.FirstOrDefault(c => c.Id == id);

    public void Agregar(Cliente cliente)
    {
        if (ClienteData.Lista.Count == 0)
        {
            cliente.Id = 1;
        }
        else
        {
            cliente.Id = ClienteData.Lista.Max(c => c.Id) + 1;
        }
        ClienteData.Lista.Add(cliente);
    }

    public bool Actualizar(int id, Cliente actualizado)
    {
        var existente = ObtenerPorId(id);
        if (existente == null) return false;

        existente.Nombre = actualizado.Nombre;
        existente.Apellido = actualizado.Apellido;
        existente.Direccion = actualizado.Direccion;
        return true;
    }

    public bool Eliminar(int id)
    {
        var cliente = ObtenerPorId(id);
        if (cliente == null) return false;

        ClienteData.Lista.Remove(cliente);
        return true;
    }
}