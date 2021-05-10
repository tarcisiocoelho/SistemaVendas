using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Classes
{

    class userBLL
    {
        public int id_user { get; set; }
        public string primeiro_nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string user { get; set; }
        public string senha { get; set; }
        public string contato { get; set; }
        public string endereco { get; set; }
        public string genero { get; set; }
        public string tipo_usuario { get; set; }
        public DateTime cadastro_data { get; set; }
        public int cadastrado_por { get; set; }
    }
}
