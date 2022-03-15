using EmailServices.Example.DTOs;
using EmailServices.Interfaces;
using EmailServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailServices.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public AccountsController(IMailServices mailServices) =>
            _mailServices = mailServices;

        private readonly IMailServices _mailServices;

        [HttpPost, Route("register")]
        public IActionResult RegisterAccount([FromBody] RegisterAccountDTO registerAccountDTO)
        {
            var mailRequest = new MailRequestModel(registerAccountDTO.Email, "Account Registrered Successfully", BuildEmailBody(registerAccountDTO.UserName));

            _mailServices.Send(mailRequest);

            return Ok();
        }

        [HttpPost, Route("register-async")]
        public async Task<IActionResult> RegisterAccountAsync([FromBody] RegisterAccountDTO registerAccountDTO, CancellationToken cancellationToken)
        {
            var mailRequest = new MailRequestModel(registerAccountDTO.Email, "Account Registrered Successfully", BuildEmailBody(registerAccountDTO.UserName));

            await _mailServices.SendAsync(mailRequest, cancellationToken);

            return Ok();
        }

        private static string BuildEmailBody(string userName) =>
            $"<h1>Welcome {userName}</h1><br><p>Your account has been <strong>registered</strong>.</p>";
    }
}