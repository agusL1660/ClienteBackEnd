using ClienteBackend.Models;
using ClienteBackEnd.Data;

namespace ClienteBackEnd.Repositories;

public class ClienteRepository
{
    private readonly ClienteData dataCliente;

    public ClienteRepository(ClienteData data)
    {
        dataCliente = data;
    }
    public List<Cliente> ObtenerTodos() => dataCliente.Lista;

    public Cliente? ObtenerPorId(int id) => dataCliente.Lista.FirstOrDefault(c => c.Id == id);

    public void Agregar(Cliente cliente)
    {
        if (dataCliente.Lista.Count == 0)
        {
            cliente.Id = 1;
        }
        else
        {
            cliente.Id = dataCliente.Lista.Max(c => c.Id) + 1;
        }
        dataCliente.Lista.Add(cliente);
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

        dataCliente.Lista.Remove(cliente);
        return true;
    }
}