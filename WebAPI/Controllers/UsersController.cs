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
    public IActionResult GetAll()
    {
        var result = _userService.GetAll();
        if (result==null)
        {
            return BadRequest();
        }
        else
        {
            return Ok(result);
        }
        
    }
    // ! Burada GetById metodunu kullanarak bir kullanıcıyı buluyoruz.
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _userService.GetById(id);
        if (result == null) {  return BadRequest(); }
        return Ok(result);
    }
    // ! Burada Add metodunu kullanarak bir kullanıcı ekliyoruz.
    [HttpPost("add")]
    public IActionResult Add(User user)
    {
        if(_userService.GetAll().Contains(user)) {
            return BadRequest();
        } else {
            _userService.Add(user);
            return Ok(); 
        }
    }
    // ! Burada Delete metodunu kullanarak bir kullanıcı siliyoruz.
    [HttpDelete("delete")]
    public IActionResult Delete(User user)
    {
        if(!_userService.GetAll().Contains(user)) {
            return BadRequest();
        } else {
            _userService.Delete(user);
            return Ok(); 
        }
    }
    // ! Burada Update metodunu kullanarak bir kullanıcıyı güncelliyoruz.
    [HttpPut("update")]
    public IActionResult Update(User user)
    {
        if(_userService.GetAll().Contains(user)) {
            return BadRequest();
        } else {
            _userService.Update(user);
            return Ok(); 
        }
    }
    
    [HttpPatch("{id}")]
public IActionResult UpdateUserEmail(int id, [FromBody] JsonPatchDocument<UserDto> patch)
{
    var user = _userService.GetById(id);
    if (user == null)
    {
        return NotFound();
    }
    var userDto = _userService.Map<UserDto>(user);
    // Apply the patch to the user DTO
    patch.ApplyTo(userDto);
    // Update the user's email in the database
    user.Email = userDto.Email;
    _userService.Update(user);
    return Ok(user);
}
    

}

