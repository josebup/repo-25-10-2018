using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Pages.Usuarios
{
    public class LoginModel : PageModel
    {
        WebApplication4Context _context;
        public LoginModel(WebApplication4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginData dados { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = _context.Usuario.Where(u => u.Email == dados.email && u.Senha == dados.senha).FirstOrDefault();
                if (usuario != null)
                {
                    return RedirectToPage("./Index");
                }
                ModelState.AddModelError("", "Email ou senha inválidos");
            }
            return Page();
        }
    }
    public class LoginData
    {
        [Required(ErrorMessage ="Digite o email")]
        public string email { get; set; }
        [Required(ErrorMessage ="Digite a senha")]
        public string senha { get; set; }
    }

}