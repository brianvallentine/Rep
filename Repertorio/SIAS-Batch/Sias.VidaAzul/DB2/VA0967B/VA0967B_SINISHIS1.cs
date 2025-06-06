using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0967B
{
    public class VA0967B_SINISHIS1 : QueryBasis<VA0967B_SINISHIS1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0967B_SINISHIS1() { IsCursor = true; }

        public VA0967B_SINISHIS1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }

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


        public override VA0967B_SINISHIS1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0967B_SINISHIS1();
            var i = 0;

            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}