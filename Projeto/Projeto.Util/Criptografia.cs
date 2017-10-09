﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
   
namespace Projeto.Util
{
    public class Criptografia
    {
        public static string EncriptarSenha(string senha)
        {
            var md5 = new MD5CryptoServiceProvider();

            byte[] binario = Encoding.UTF8.GetBytes(senha);
            byte[] hash = md5.ComputeHash(binario);

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
