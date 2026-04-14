using ClienteBackend.Models;
using Microsoft.AspNetCore.Mvc;
namespace ClienteBackEnd.Controllers;
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
    public ActionResult<Cliente> GetById(int id) 
    {
        var cliente = clienteRepository.ObtenerPorId(id);
        return cliente == null ? NotFound() : cliente;
    }

    [HttpPost]
    public IActionResult Create(Cliente cliente)
    {
        clienteRepository.Agregar(cliente);
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, Cliente actualizado)
    {
        var exito = clienteRepository.Actualizar(id, actualizado);
        return exito ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var exito = clienteRepository.Eliminar(id);
        return exito ? NoContent() : NotFound();
    }
}