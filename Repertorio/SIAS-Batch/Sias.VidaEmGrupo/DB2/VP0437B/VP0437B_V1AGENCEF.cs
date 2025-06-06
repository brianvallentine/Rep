using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class VP0437B_V1AGENCEF : QueryBasis<VP0437B_V1AGENCEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0437B_V1AGENCEF() { IsCursor = true; }

        public VP0437B_V1AGENCEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MALHACEF_COD_FONTE { get; set; }
        public string FONTES_NOME_FONTE { get; set; }
        public string FONTES_ENDERECO { get; set; }
        public string FONTES_BAIRRO { get; set; }
        public string FONTES_CIDADE { get; set; }
        public string FONTES_CEP { get; set; }
        public string FONTES_SIGLA_UF { get; set; }

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


        public override VP0437B_V1AGENCEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0437B_V1AGENCEF();
            var i = 0;

            dta.MALHACEF_COD_FONTE = result[i++].Value?.ToString();
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            dta.FONTES_ENDERECO = result[i++].Value?.ToString();
            dta.FONTES_BAIRRO = result[i++].Value?.ToString();
            dta.FONTES_CIDADE = result[i++].Value?.ToString();
            dta.FONTES_CEP = result[i++].Value?.ToString();
            dta.FONTES_SIGLA_UF = result[i++].Value?.ToString();

            return dta;
        }

    }
}