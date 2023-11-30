using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Source.Business;
using WebAPI.Source.Entities;

namespace WebAPI.Controllers;
/*
* Bu controllerda CRUD operasyonları için gerekli metodlar bulunmaktadır.
* İlgili sınıfın tanımı ve operasyonları için WebAPI/Source/Business/UserManager.cs dosyasına bakabilirsiniz.
*/
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    // ! Burada GetAll metodunu kullanarak tüm kullanıcıları listeliyoruz.
    [HttpGet("getall")]
    public IActionResult GetAll([FromQuery] string sortBy)
    {
        try
    {
        // Kullanıcı servisinden sıralanmış kullanıcı listesini al
        var userList = _userService.GetAll(sortBy);

        if (userList == null || userList.Count() == 0)
        {
            return NotFound("Sıralanmış kullanıcı listesi bulunamadı."); // HTTP 404 Not Found
        }

        return Ok(userList); // HTTP 200 OK
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Bir hata oluştu: {ex.Message}"); // HTTP 500 Internal Server Error
    }
        
    }
    // ! Burada GetById metodunu kullanarak bir kullanıcıyı buluyoruz.
    [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result == null)
            {
                return NotFound(); // HTTP 404 Not Found
            }
            return Ok(result); // HTTP 200 OK
        }

    // ! Burada Add metodunu kullanarak bir kullanıcı ekliyoruz.
    [HttpPost("add")]
        public IActionResult Add([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest(); // HTTP 400 Bad Request
        }

        // Model binding 
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // HTTP 400 Bad Request
        }

        if (!_userService.GetAll("id").Any(u => u.Id == user.Id))
        {
            _userService.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user); // HTTP 201 Created
        }

        return Conflict(); // HTTP 409 Conflict
    }

    // ! Burada Delete metodunu kullanarak bir kullanıcı siliyoruz.
    [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound(); // HTTP 404 Not Found
            }

            _userService.Delete(user);
            return NoContent(); // HTTP 204 No Content
        }
    // ! Burada Update metodunu kullanarak bir kullanıcıyı güncelliyoruz.
    [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest(); // HTTP 400 Bad Request
            }

            // Model binding işlemi kontrolü
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // HTTP 400 Bad Request
            }

            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound(); // HTTP 404 Not Found
            }

            _userService.Update(user);
            return NoContent(); // HTTP 204 No Content
        }

        [HttpPatch("update-email/{id}")]
        public IActionResult UpdateUserEmail(int id, [FromBody] JsonPatchDocument<UserDto> patch)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound(); // HTTP 404 Not Found
            }

            var userDto = _userService.Map<UserDto>(user);
            patch.ApplyTo(userDto);

            // Model binding işlemi kontrolü
            if (!TryValidateModel(userDto))
            {
                return BadRequest(ModelState); // HTTP 400 Bad Request
            }

            user.Email = userDto.Email;
            _userService.Update(user);
            return Ok(user); // HTTP 200 OK
        }
    

}

