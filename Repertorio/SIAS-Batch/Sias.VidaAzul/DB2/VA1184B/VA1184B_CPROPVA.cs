using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class VA1184B_CPROPVA : QueryBasis<VA1184B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA1184B_CPROPVA() { IsCursor = true; }

        public VA1184B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATO_DTSOLICITACAO { get; set; }
        public string RELATO_NUM_APOLICE { get; set; }
        public string RELATO_CODSUBES { get; set; }
        public string RELATO_NRCERTIF { get; set; }
        public string RELATO_OPERACAO { get; set; }
        public string RELATO_PCT_AUMENTO { get; set; }
        public string RELATO_SITUACAO { get; set; }

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


        public override VA1184B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA1184B_CPROPVA();
            var i = 0;

            dta.RELATO_DTSOLICITACAO = result[i++].Value?.ToString();
            dta.RELATO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATO_CODSUBES = result[i++].Value?.ToString();
            dta.RELATO_NRCERTIF = result[i++].Value?.ToString();
            dta.RELATO_OPERACAO = result[i++].Value?.ToString();
            dta.RELATO_PCT_AUMENTO = result[i++].Value?.ToString();
            dta.RELATO_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}