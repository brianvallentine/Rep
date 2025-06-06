using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class VA0853B_CGERARAT : QueryBasis<VA0853B_CGERARAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0853B_CGERARAT() { IsCursor = true; }

        public VA0853B_CGERARAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_NUM_PARCELA_ATZ { get; set; }

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


        public override VA0853B_CGERARAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0853B_CGERARAT();
            var i = 0;

            dta.WS_NUM_PARCELA_ATZ = result[i++].Value?.ToString();

            return dta;
        }

    }
}