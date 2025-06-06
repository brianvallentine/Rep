using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0408B
{
    public class VF0408B_CPROPVF : QueryBasis<VF0408B_CPROPVF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0408B_CPROPVF() { IsCursor = true; }

        public VF0408B_CPROPVF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PRVA_NRCERTIF { get; set; }
        public string V0PRDR_CODPDT { get; set; }
        public string V0PRDR_NOMPDT { get; set; }
        public string V0PRDR_ENDERECO { get; set; }
        public string V0PRDR_BAIRRO { get; set; }
        public string V0PRDR_CIDADE { get; set; }
        public string V0PRDR_ESTADO { get; set; }
        public string V0PRDR_CEP { get; set; }
        public string V0PRVA_DTQITBCO { get; set; }
        public string V0CLIE_NOME_RAZAO { get; set; }
        public string V0ENDE_ENDERECO { get; set; }
        public string V0ENDE_BAIRRO { get; set; }
        public string V0ENDE_CIDADE { get; set; }
        public string V0ENDE_SIGLA_UF { get; set; }
        public string V0ENDE_CEP { get; set; }
        public string V0HSEG_DTMOVTO { get; set; }

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


        public override VF0408B_CPROPVF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0408B_CPROPVF();
            var i = 0;

            dta.V0PRVA_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PRDR_CODPDT = result[i++].Value?.ToString();
            dta.V0PRDR_NOMPDT = result[i++].Value?.ToString();
            dta.V0PRDR_ENDERECO = result[i++].Value?.ToString();
            dta.V0PRDR_BAIRRO = result[i++].Value?.ToString();
            dta.V0PRDR_CIDADE = result[i++].Value?.ToString();
            dta.V0PRDR_ESTADO = result[i++].Value?.ToString();
            dta.V0PRDR_CEP = result[i++].Value?.ToString();
            dta.V0PRVA_DTQITBCO = result[i++].Value?.ToString();
            dta.V0CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            dta.V0ENDE_ENDERECO = result[i++].Value?.ToString();
            dta.V0ENDE_BAIRRO = result[i++].Value?.ToString();
            dta.V0ENDE_CIDADE = result[i++].Value?.ToString();
            dta.V0ENDE_SIGLA_UF = result[i++].Value?.ToString();
            dta.V0ENDE_CEP = result[i++].Value?.ToString();
            dta.V0HSEG_DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}