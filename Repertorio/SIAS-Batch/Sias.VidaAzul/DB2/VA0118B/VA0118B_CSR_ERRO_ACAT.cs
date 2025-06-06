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
    public class VA0118B_CSR_ERRO_ACAT : QueryBasis<VA0118B_CSR_ERRO_ACAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0118B_CSR_ERRO_ACAT() { IsCursor = true; }

        public VA0118B_CSR_ERRO_ACAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_SEQ_CRITICA { get; set; }
        public string VG103_COD_MSG_CRITICA { get; set; }

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


        public override VA0118B_CSR_ERRO_ACAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0118B_CSR_ERRO_ACAT();
            var i = 0;

            dta.VG103_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG103_SEQ_CRITICA = result[i++].Value?.ToString();
            dta.VG103_COD_MSG_CRITICA = result[i++].Value?.ToString();

            return dta;
        }

    }
}