using Microsoft.AspNetCore.Mvc;
using WebAPI.Source.Business;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
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
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result == null) {  return BadRequest(); }
            return Ok(result);
        }
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
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            if(!_userService.GetAll().Contains(user)) {
                return BadRequest();
            } else {
                _userService.Delete(user);
                return Ok(); 
            }
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            if(_userService.GetAll().Contains(user)) {
                return BadRequest();
            } else {
                _userService.Update(user);
                return Ok(); 
            }
        }

}

