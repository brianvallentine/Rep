using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0061B
{
    public class VA0061B_CURSOR01 : QueryBasis<VA0061B_CURSOR01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0061B_CURSOR01() { IsCursor = true; }

        public VA0061B_CURSOR01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ERRPROVI_NUM_CERTIFICADO { get; set; }
        public string ERRPROVI_COD_ERRO { get; set; }

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


        public override VA0061B_CURSOR01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0061B_CURSOR01();
            var i = 0;

            dta.ERRPROVI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.ERRPROVI_COD_ERRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}