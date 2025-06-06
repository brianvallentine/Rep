using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class PF0600B_CFONTES : QueryBasis<PF0600B_CFONTES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0600B_CFONTES() { IsCursor = true; }

        public PF0600B_CFONTES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLFONTES_FONTES_COD_FONTE { get; set; }
        public string DCLFONTES_FONTES_ULT_PROP_AUTOMAT { get; set; }

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


        public override PF0600B_CFONTES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0600B_CFONTES();
            var i = 0;

            dta.DCLFONTES_FONTES_COD_FONTE = result[i++].Value?.ToString();
            dta.DCLFONTES_FONTES_ULT_PROP_AUTOMAT = result[i++].Value?.ToString();

            return dta;
        }

    }
}