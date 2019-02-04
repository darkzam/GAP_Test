using AutoMapper;
using GAP.Insurance.Entities;
using GAP.Insurance.Models;
using GAP.Insurance.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Controllers
{
    [Route("/Clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;

        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<ClientDto>> GetClients()
        {
            var clients = _clientService.GetClients();

            var clientsDto = Mapper.Map<List<ClientDto>>(clients);

            return Ok(clientsDto);
        }

        [Route("{id}", Name = "GetClientById")]
        [HttpGet]
        public ActionResult<Client> GetClientById(int id)
        {
            if (!_clientService.ClientExists(id))
                return NotFound();

            var Client = _clientService.GetClientById(id);

            return Ok(Client);
        }

        [Route("")]
        [HttpPost]
        public ActionResult AddClient(ClientCreateDto clientDto)
        {
            if (clientDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var client = Mapper.Map<Client>(clientDto);

            var newClient = _clientService.AddClient(client);

            if (!_clientService.Save())
                throw new Exception($"Creation has failed.");

            return CreatedAtRoute("GetClientById",
                                   new { id = newClient.Id },
                                   newClient
                                   );
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteClient(int id)
        {
            if (!_clientService.ClientExists(id))
                return NotFound();

            var client = _clientService.GetClientById(id);

            if (client == null)
                return NotFound();

            _clientService.DeleteClient(client);

            if (!_clientService.Save())
                throw new Exception($"Deleting has failed.");

            return NoContent();
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdateClient(int id, ClientCreateDto clientDto)
        {
            if (clientDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            if (!_clientService.ClientExists(id))
                return NotFound();

            var client = _clientService.GetClientById(id);

            Mapper.Map(clientDto, client);

            _clientService.UpdateClient(client);

            if (!_clientService.Save())
                throw new Exception("Update has failed.");

            return NoContent();
        }
    }
}
