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
    public class VP1111B_CR_CANC_SIAS : QueryBasis<VP1111B_CR_CANC_SIAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP1111B_CR_CANC_SIAS() { IsCursor = true; }

        public VP1111B_CR_CANC_SIAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOVA_TIMESTAMP { get; set; }

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


        public override VP1111B_CR_CANC_SIAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP1111B_CR_CANC_SIAS();
            var i = 0;

            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOVA_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}