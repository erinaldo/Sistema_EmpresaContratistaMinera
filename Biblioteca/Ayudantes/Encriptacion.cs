using System;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Ayudantes
{
    public static class Encriptacion
    {
        #region Métodos 
        public static string GenerarContrasenia()
        {
            StringBuilder nuevaContrasenia = new StringBuilder();
            Random rnd = new Random();
            int i = 4; //Especifica la longitud de la contraseña (4)
            //Especifica los caracteres y símbolos válidos para la contraseña
            string caracteresValidos = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            string numerosValidos = "123456789";
            string simbolosValidos = "_-@#$";
            //Define de forma aleatoria que la contraseña contenga al menos un número y un símbolo
            int incluirNumero = rnd.Next(0, 1);
            int incluirSimbolo = rnd.Next(1, 3);
            while (i-- > 0)
            {
                //Genera una contraseña segura de forma aleatoria con caractéres, numeros y simbolos variados
                if (i == incluirNumero) nuevaContrasenia.Append(numerosValidos[rnd.Next(numerosValidos.Length)]);
                else if (i == incluirSimbolo) nuevaContrasenia.Append(simbolosValidos[rnd.Next(simbolosValidos.Length)]);
                else nuevaContrasenia.Append(caracteresValidos[rnd.Next(caracteresValidos.Length)]);
            }
            return nuevaContrasenia.ToString();
        }

        public static byte[] EncriptarContrasenia(string contrasenia)
        {
            byte[] llave = Encoding.UTF8.GetBytes("salt:$Pr?T4!Tg%9y&Z0x+9G*7ryd-32"); //Seguridad Paso 1: Determina un valor de llave
            string salt = contrasenia + Convert.ToBase64String(llave); //Seguridad Paso 2: Determina un valor final y especifico para salt 
            int iteraciones = salt.Length - 1; //Seguridad Paso 3: Establece la cantidad de iteraciones para Hash 
            //Seguridad Paso 4: Encriptado de la contraseña con Algoritmo SHA512
            PasswordDeriveBytes encriptado = new PasswordDeriveBytes(contrasenia, Encoding.UTF8.GetBytes(salt), "SHA512", Convert.ToInt32(iteraciones));
            return encriptado.GetBytes(32); //Seguridad Paso 5: Convierte la contraseña encriptada a un string
        }

        public static byte[] Encriptar(string mensaje, string llave)
        {
            using (Rijndael algoritmo = Rijndael.Create())
            {
                byte[] encriptado = null;
                byte[] mensajeEncriptado = null;
                algoritmo.Key = Encoding.UTF8.GetBytes(llave); //Seguridad Paso 1: Codifica el valor de llave
                algoritmo.GenerateIV(); //Seguridad Paso 2: Establece un vector de inicialización aleatorio
                byte[] mensajeBinario = Encoding.UTF8.GetBytes(mensaje); //Seguridad Paso 3: Codifica el contenido del mensaje
                // ------ Seguridad Paso 3: Encriptación del mensaje ------ //
                encriptado = (algoritmo.CreateEncryptor()).TransformFinalBlock(mensajeBinario, 0, mensajeBinario.Length);
                mensajeEncriptado = new byte[algoritmo.IV.Length + encriptado.Length];
                algoritmo.IV.CopyTo(mensajeEncriptado, 0);
                encriptado.CopyTo(mensajeEncriptado, algoritmo.IV.Length);
                return mensajeEncriptado;
            }
        }

        public static byte[] Encriptar(byte[] mensajeBinario, string llave)
        {
            using (Rijndael algoritmo = Rijndael.Create())
            {
                byte[] encriptado = null;
                byte[] mensajeEncriptado = null;
                algoritmo.Key = Encoding.UTF8.GetBytes(llave); //Seguridad Paso 1: Codifica el valor de llave
                algoritmo.GenerateIV(); //Seguridad Paso 2: Establece un vector de inicialización aleatorio
                // ------ Seguridad Paso 3: Encriptación del mensaje ------ //
                encriptado = (algoritmo.CreateEncryptor()).TransformFinalBlock(mensajeBinario, 0, mensajeBinario.Length);
                mensajeEncriptado = new byte[algoritmo.IV.Length + encriptado.Length];
                algoritmo.IV.CopyTo(mensajeEncriptado, 0);
                encriptado.CopyTo(mensajeEncriptado, algoritmo.IV.Length);
                return mensajeEncriptado;
            }
        }

        public static byte[] Desencriptar(string llave, byte[] mensajeEncriptado)
        {
            using (Rijndael algoritmo = Rijndael.Create())
            {
                byte[] temp = new byte[algoritmo.IV.Length];
                byte[] encriptado = new byte[mensajeEncriptado.Length - algoritmo.IV.Length];
                byte[] mensaje = new byte[] { };
                algoritmo.Key = Encoding.UTF8.GetBytes(llave);
                Array.Copy(mensajeEncriptado, temp, temp.Length);
                Array.Copy(mensajeEncriptado, temp.Length, encriptado, 0, encriptado.Length);
                algoritmo.IV = temp;
                mensaje = (algoritmo.CreateDecryptor()).TransformFinalBlock(encriptado, 0, encriptado.Length);
                return mensaje;
            }
        }

        public static string Desencriptar(byte[] mensajeEncriptado, string llave)
        {
            using (Rijndael algoritmo = Rijndael.Create())
            {
                byte[] temp = new byte[algoritmo.IV.Length];
                byte[] encriptado = new byte[mensajeEncriptado.Length - algoritmo.IV.Length];
                string mensaje = "";
                algoritmo.Key = Encoding.UTF8.GetBytes(llave);
                Array.Copy(mensajeEncriptado, temp, temp.Length);
                Array.Copy(mensajeEncriptado, temp.Length, encriptado, 0, encriptado.Length);
                algoritmo.IV = temp;
                mensaje = Encoding.UTF8.GetString((algoritmo.CreateDecryptor()).TransformFinalBlock(encriptado, 0, encriptado.Length));
                return mensaje;
            }
        }
        #endregion
    }
}
