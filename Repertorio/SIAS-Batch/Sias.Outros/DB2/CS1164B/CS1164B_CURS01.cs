using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CS1164B
{
    public class CS1164B_CURS01 : QueryBasis<CS1164B_CURS01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CS1164B_CURS01() { IsCursor = true; }

        public CS1164B_CURS01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOSTA_COD_FONTE { get; set; }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string PROPOSTA_NUM_RCAP { get; set; }
        public string PROPOSTA_DATA_CADASTRAMENTO { get; set; }
        public string PROPOSTA_DATA_INIVIGENCIA { get; set; }
        public string PROPOSTA_DATA_TERVIGENCIA { get; set; }
        public string PROPOAUT_NUM_PROPOSTA_CONV { get; set; }

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


        public override CS1164B_CURS01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CS1164B_CURS01();
            var i = 0;

            dta.PROPOSTA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_RCAP = result[i++].Value?.ToString();
            dta.PROPOSTA_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.PROPOSTA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.PROPOSTA_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.PROPOAUT_NUM_PROPOSTA_CONV = result[i++].Value?.ToString();

            return dta;
        }

    }
}