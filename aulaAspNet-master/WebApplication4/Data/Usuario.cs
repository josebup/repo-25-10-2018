﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Data
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage="Nome é obrigatório")]
        [MaxLength(30, ErrorMessage = "Nome pode conter no máximo 30 letras")]
        public string Nome { get; set; }
        public string Senha { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email deve estar no formato conta@dominio.com")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        
        public string Cpf { get; set; }
        [RegularExpression(@"\d\d\d\d\d-\d\d\d", ErrorMessage = "CEP deve estar no formato 00000-000")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
