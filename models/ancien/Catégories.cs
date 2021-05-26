using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    class Catégories
    {
        int code;
        char name;
        char picture;

        public Catégories(char name, int code, char picture)
        {
            this.code = code;
            this.name = name;
            this.picture = picture;
        }

        public Catégories(DataRow row)
            {
            this.code =(int) row["codeCateg"];
            this.name = (char)row["nomCateg"];
            this.picture = (char)row["photoCateg"];
            }

    }
}
