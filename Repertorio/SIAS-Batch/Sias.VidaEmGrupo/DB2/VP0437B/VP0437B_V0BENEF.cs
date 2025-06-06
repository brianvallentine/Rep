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
    public class VP0437B_V0BENEF : QueryBasis<VP0437B_V0BENEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0437B_V0BENEF() { IsCursor = true; }

        public VP0437B_V0BENEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BENEFICI_NOME_BENEFICIARIO { get; set; }
        public string BENEFICI_GRAU_PARENTESCO { get; set; }
        public string BENEFICI_PCT_PART_BENEFICIA { get; set; }
        public string BENEFICI_NUM_CPF { get; set; }

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


        public override VP0437B_V0BENEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0437B_V0BENEF();
            var i = 0;

            dta.BENEFICI_NOME_BENEFICIARIO = result[i++].Value?.ToString();
            dta.BENEFICI_GRAU_PARENTESCO = result[i++].Value?.ToString();
            dta.BENEFICI_PCT_PART_BENEFICIA = result[i++].Value?.ToString();
            dta.BENEFICI_NUM_CPF = result[i++].Value?.ToString();

            return dta;
        }

    }
}