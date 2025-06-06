using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class VA0118B_CSR_RISCO : QueryBasis<VA0118B_CSR_RISCO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0118B_CSR_RISCO() { IsCursor = true; }

        public VA0118B_CSR_RISCO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_NUM_CERTIFICADO_RISCO { get; set; }
        public string WS_SIT_REGISTRO_RISCO { get; set; }

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


        public override VA0118B_CSR_RISCO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0118B_CSR_RISCO();
            var i = 0;

            dta.WS_NUM_CERTIFICADO_RISCO = result[i++].Value?.ToString();
            dta.WS_SIT_REGISTRO_RISCO = result[i++].Value?.ToString();

            return dta;
        }

    }
}