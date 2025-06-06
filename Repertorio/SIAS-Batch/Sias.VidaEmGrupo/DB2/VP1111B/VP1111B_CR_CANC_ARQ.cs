using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1111B
{
    public class VP1111B_CR_CANC_ARQ : QueryBasis<VP1111B_CR_CANC_ARQ>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP1111B_CR_CANC_ARQ() { IsCursor = true; }

        public VP1111B_CR_CANC_ARQ(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string EF064_NUM_CONTRATO { get; set; }
        public string WS_DATA_CANCEL { get; set; }

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


        public override VP1111B_CR_CANC_ARQ OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP1111B_CR_CANC_ARQ();
            var i = 0;

            dta.EF064_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.WS_DATA_CANCEL = result[i++].Value?.ToString();

            return dta;
        }

    }
}