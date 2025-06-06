using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class VA0601B_CRISCO3 : QueryBasis<VA0601B_CRISCO3>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0601B_CRISCO3() { IsCursor = true; }

        public VA0601B_CRISCO3(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BILHETE_NUM_APOLICE { get; set; }

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


        public override VA0601B_CRISCO3 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0601B_CRISCO3();
            var i = 0;

            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();

            return dta;
        }

    }
}