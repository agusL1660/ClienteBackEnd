using ClienteBackend.Models;
using Microsoft.AspNetCore.Mvc;
namespace ClienteBackEnd.Controllers;

using ClienteBackend.Request;
using ClienteBackEnd.Repositories;


[ApiController]
[Route("clientes")]
public class ClientesController : ControllerBase
{
    private readonly ClienteRepository clienteRepository;

    public ClientesController(ClienteRepository repository)
    {
        clienteRepository = repository;
    }

    [HttpGet]
    public IEnumerable<Cliente> GetAll() => clienteRepository.ObtenerTodos();

    [HttpGet("{id}")]
    public ActionResult<ClienteDTO> GetById(int id) 
    {
        var cliente = clienteRepository.ObtenerPorId(id);
        
        if (cliente == null) return NotFound();

        return (ClienteDTO)cliente;
    }

    [HttpPost]
    public IActionResult Create(ClienteDTO cliente)
    {
        var nuevoCliente = new Cliente 
    {
        Nombre = cliente.Nombre,
        Apellido = cliente.Apellido,
        Direccion = cliente.Direccion
    };

    clienteRepository.Agregar(nuevoCliente);
        return CreatedAtAction(nameof(GetById), new { id = nuevoCliente.Id }, (ClienteDTO)nuevoCliente);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, ClienteDTO actualizado)
    {   
        var datosNuevos = new Cliente 
        {
            Nombre = actualizado.Nombre,
            Apellido = actualizado.Apellido,
            Direccion = actualizado.Direccion
        };
        var exito = clienteRepository.Actualizar(id, datosNuevos);
        return exito ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var exito = clienteRepository.Eliminar(id);
        return exito ? NoContent() : NotFound();
    }
}