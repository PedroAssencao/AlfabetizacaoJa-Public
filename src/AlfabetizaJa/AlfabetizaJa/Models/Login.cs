using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlfabetizaJa.Models
{
    public class Login
    {
        public int log_id { get; set; }
        public string log_user { get; set; }

        [EmailAddress]
        public string log_email { get; set; }
        public string log_senha { get; set;}
        public string log_numeroW { get; set; }

        public string CriptografaSenha(string senha)
        {
            var a = Encoding.UTF8.GetBytes(senha);
            var b = Convert.ToBase64String(a);
            return b;
        }

        public string DescriptografaSenha(string senha)
        {
            var c = Convert.FromBase64String(senha);
            var d = Encoding.UTF8.GetString(c);
            return d;
        }


    }
}
