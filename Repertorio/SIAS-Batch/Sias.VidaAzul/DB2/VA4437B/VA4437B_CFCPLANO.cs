using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4437B
{
    public class VA4437B_CFCPLANO : QueryBasis<VA4437B_CFCPLANO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA4437B_CFCPLANO() { IsCursor = true; }

        public VA4437B_CFCPLANO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FCPLANO_NUM_PLANO { get; set; }
        public string FCPLANO_QTD_DIG_COMBINACAO { get; set; }

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


        public override VA4437B_CFCPLANO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA4437B_CFCPLANO();
            var i = 0;

            dta.FCPLANO_NUM_PLANO = result[i++].Value?.ToString();
            dta.FCPLANO_QTD_DIG_COMBINACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}