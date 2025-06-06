using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0032B
{
    public class BI0032B_V1RELAT : QueryBasis<BI0032B_V1RELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0032B_V1RELAT() { IsCursor = true; }

        public BI0032B_V1RELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_COD_FONTE { get; set; }
        public string RELATORI_RAMO_EMISSOR { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

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


        public override BI0032B_V1RELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0032B_V1RELAT();
            var i = 0;

            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_FONTE = result[i++].Value?.ToString();
            dta.RELATORI_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATORI_NUM_TITULO = result[i++].Value?.ToString();

            return dta;
        }

    }
}