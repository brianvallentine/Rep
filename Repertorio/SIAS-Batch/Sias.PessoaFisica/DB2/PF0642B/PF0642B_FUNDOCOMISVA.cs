using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
{
    public class PF0642B_FUNDOCOMISVA : QueryBasis<PF0642B_FUNDOCOMISVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0642B_FUNDOCOMISVA() { IsCursor = true; }

        public PF0642B_FUNDOCOMISVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO { get; set; }
        public string DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG { get; set; }
        public string DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP { get; set; }

        public new void Open()
        {
            if (!IsProcedure)
                SetQuery(GetQueryEvent());
            base.Open();
        }


        public new bool Fetch()
        {
            if (!JustACursor)
            {
                var idx = CurrentIndex;
                Open();
                CurrentIndex = idx > -1 ? idx : 0;
            }

            return base.Fetch();
        }


        public override PF0642B_FUNDOCOMISVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0642B_FUNDOCOMISVA();
            var i = 0;

            dta.DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG = result[i++].Value?.ToString();
            dta.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP = result[i++].Value?.ToString();

            return dta;
        }

    }
}