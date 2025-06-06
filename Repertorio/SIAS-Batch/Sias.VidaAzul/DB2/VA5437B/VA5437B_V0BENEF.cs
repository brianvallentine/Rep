using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class VA5437B_V0BENEF : QueryBasis<VA5437B_V0BENEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA5437B_V0BENEF() { IsCursor = true; }

        public VA5437B_V0BENEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BENEFICI_NOME_BENEFICIARIO { get; set; }
        public string BENEFICI_GRAU_PARENTESCO { get; set; }
        public string BENEFICI_PCT_PART_BENEFICIA { get; set; }

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


        public override VA5437B_V0BENEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA5437B_V0BENEF();
            var i = 0;

            dta.BENEFICI_NOME_BENEFICIARIO = result[i++].Value?.ToString();
            dta.BENEFICI_GRAU_PARENTESCO = result[i++].Value?.ToString();
            dta.BENEFICI_PCT_PART_BENEFICIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}