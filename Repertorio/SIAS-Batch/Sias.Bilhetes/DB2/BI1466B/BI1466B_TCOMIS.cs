using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1466B
{
    public class BI1466B_TCOMIS : QueryBasis<BI1466B_TCOMIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI1466B_TCOMIS() { IsCursor = true; }

        public BI1466B_TCOMIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_NUMBIL { get; set; }
        public string V0PROP_RAMO { get; set; }
        public string V0PROP_AGECOBR { get; set; }
        public string V0PROP_DTQITBCO { get; set; }
        public string V0PROP_CODUSU { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_OCOREND { get; set; }
        public string V0PROP_VLPREMIO { get; set; }
        public string V0PROP_PROFISSAO { get; set; }
        public string V0PROP_SITUACAO { get; set; }

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


        public override BI1466B_TCOMIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI1466B_TCOMIS();
            var i = 0;

            dta.V0PROP_NUMBIL = result[i++].Value?.ToString();
            dta.V0PROP_RAMO = result[i++].Value?.ToString();
            dta.V0PROP_AGECOBR = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO = result[i++].Value?.ToString();
            dta.V0PROP_CODUSU = result[i++].Value?.ToString();
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_OCOREND = result[i++].Value?.ToString();
            dta.V0PROP_VLPREMIO = result[i++].Value?.ToString();
            dta.V0PROP_PROFISSAO = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}