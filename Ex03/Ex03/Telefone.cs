﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    internal class Telefone
    {
        private string tipo;
        private string numero;
        private bool principal;

        public Telefone(string tipo, string numero, bool principal)
        {
            this.tipo = tipo;
            this.numero = numero;
            this.principal = principal;
        }

        public Telefone() : this(" ", " ", false) { }

        public string Tipo { get => tipo; set => tipo = value; }
        public string Numero { get => numero; set => numero = value; }
        public bool Principal { get => principal; set => principal = value; }
    }
}
