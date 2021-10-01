﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entr {2} e {1} caracteres"), MinLength(2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entr {2} e {1} caracteres"), MinLength(1)]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter entr {2} e {1} caracteres"), MinLength(8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entr {2} e {1} caracteres"), MinLength(2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entr {2} e {1} caracteres"), MinLength(2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entr {2} e {1} caracteres"), MinLength(2)]
        public string Estado { get; set; }


        public Guid FornecedorId { get; set; }
    }
}