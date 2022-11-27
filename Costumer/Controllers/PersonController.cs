using AutoMapper;
using Costumer.Models;
using Customer.Interfaces;
using Customer.Models;
using Customer.ViewModels.CompanyViewModels;
using Customer.ViewModels.PersonViewModels;
using JWTAuhtenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;


namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JWTTokenHandler _jwtTokenHandler;

        public PersonController(IMapper mapper, IUnitOfWork unitOfWork, JWTTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPerson(PostPersonViewModel model)
        {
            var person = _mapper.Map<Person>(model);
            if (await _unitOfWork.PersonRepository.AddPerson(person))
                if (await _unitOfWork.CompleteAsync())
                    return Ok(model);

            return StatusCode(500, "Could not add Person");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Person person)
        {
            var result = await _unitOfWork.PersonRepository.Login(person);
            if (result == null) return NotFound();
            
            
            var authenticationResponse = _jwtTokenHandler.GenerateJWTToken(result.Email, result.Role.Name);
            if (authenticationResponse == null) return Unauthorized();

            result.Token = _mapper.Map<Token>(authenticationResponse);

            return Ok(result);
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPerson(int id)
        {
            var result = await _unitOfWork.PersonRepository.FindPersonById(id);
            if (result == null) return NotFound($"Could not find any Person with id : {id}");

            var response = _mapper.Map<PersonViewModel>(result);

            return Ok(response);
        }

        [HttpGet("{lastName}")]
        [Authorize]
        public async Task<IActionResult> GetPersonsByLastName(string lastName)
        {
            var result = await _unitOfWork.PersonRepository.FindPersonsByLastName(lastName);
            if (result.Count <= 0) return NotFound($"Could not find any Person with FirstName: {lastName}");

            var response = _mapper.Map<IList<PersonViewModel>>(result);

            return Ok(response);
        }

        [HttpGet("{firstName}")]
        [Authorize]
        public async Task<IActionResult> GetPersonsByFirstName(string firstName)
        {
            var result = await _unitOfWork.PersonRepository.FindPersonsByFirstName(firstName);
            if (result.Count <= 0) return NotFound($"Could not find any Person with FirstName: {firstName}");

            var response = _mapper.Map<IList<PersonViewModel>>(result);

            return Ok(response);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPerson()
        {
            var result = await _unitOfWork.PersonRepository.ListAllPersons();
            if (result.Count <= 0) return NotFound($"Could not find any Persons");

            var response = _mapper.Map<IList<PersonViewModel>>(result);
            
            return Ok(response);
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePerson(int id, PatchPersonViewModel model)
        {
            var toUpdate = await _unitOfWork.PersonRepository.FindPersonById(id);
            if (toUpdate == null) return NotFound($"Could not find any Person with id : {id}");

            toUpdate.FirstName = model.FirstName;
            toUpdate.LastName = model.LastName;
            toUpdate.Email = model.Email;
            toUpdate.PhoneNumber = model.PhoneNumber;
            toUpdate.CompanyId = model.CompanyId;
            toUpdate.RoleId = model.RoleId;

            if (_unitOfWork.PersonRepository.UpdatePerson(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Person updated");

            return StatusCode(500, "Something went wrong updating");
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await _unitOfWork.PersonRepository.FindPersonById(id);
            if (result == null) return NotFound($"Could not find any Person with id : {id}");

            if (_unitOfWork.PersonRepository.DeletePerson(result))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Person removed");

            return StatusCode(500, "Something went wrong removing Person");
        }
    }
}
