using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class VA2646B_BENEFICIARIOS : QueryBasis<VA2646B_BENEFICIARIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2646B_BENEFICIARIOS() { IsCursor = true; }

        public VA2646B_BENEFICIARIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BENEFICI_NUM_BENEFICIARIO { get; set; }
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


        public override VA2646B_BENEFICIARIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2646B_BENEFICIARIOS();
            var i = 0;

            dta.BENEFICI_NUM_BENEFICIARIO = result[i++].Value?.ToString();
            dta.BENEFICI_NOME_BENEFICIARIO = result[i++].Value?.ToString();
            dta.BENEFICI_GRAU_PARENTESCO = result[i++].Value?.ToString();
            dta.BENEFICI_PCT_PART_BENEFICIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}