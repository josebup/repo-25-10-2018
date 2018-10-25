using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Util;

namespace WebApplication4.Pages.Usuarios
{
    public class CadastrarModel : PageModel
    {
        WebApplication4Context _context;
        public CadastrarModel(WebApplication4Context context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public Usuario usuario { get; set; }
        
        public void OnGet()
        {
            if (usuario == null)
            {
                usuario = new Usuario();
            }
        }
        [HttpPost]
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                if (!DigitosUtil.IsCpf(usuario.Cpf))
                {
                    _context.Usuario.Add(usuario);
                    _context.SaveChanges();
                    return RedirectToPage("./Index");
                    
                }
                else
                {
                    ModelState.AddModelError("usuario.Cpf", "CPF Invalido");
                }        
            }
            return Page();
        }
    }
}