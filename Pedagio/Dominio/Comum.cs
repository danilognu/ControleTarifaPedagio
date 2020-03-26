using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Pedagio.Dominio
{
    public class Comum
    {
        public static int CodigoTipoPessoaUsuario = 5;
        public static int CodigoTipoPessoaEmpresa = 6;

        public static string ClearCNPJ(string value)
        {
            string _retorno = value;
            if(value != null && value.Length > 0)
            {
                _retorno = value.Replace(".", "").Replace("-", "").Replace("/", "");
            }
            return _retorno;
        }
        public static string ClearCEP(string value)
        {
            string _retorno = value;
            if (value != null && value.Length > 0)
            {
                _retorno = value.Replace("-", "");
            }
            return _retorno;
        }
        public static string ClearTelefone(string value)
        {
            string _retorno = value;
            if (value != null && value.Length > 0)
            {
                _retorno = value.Replace("(.", "").Replace(")", "").Replace("-", "");
            }
            return _retorno;
        }


        public static string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string RemoverAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }


    }
}
