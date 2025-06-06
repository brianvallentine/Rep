using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class VG2600B_CAMPOARQ : QueryBasis<VG2600B_CAMPOARQ>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG2600B_CAMPOARQ() { IsCursor = true; }

        public VG2600B_CAMPOARQ(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PF088_NUM_DET_ARQ_PROPOSTA { get; set; }
        public string PF088_NOM_DET_ARQ_PROPOSTA { get; set; }

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


        public override VG2600B_CAMPOARQ OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG2600B_CAMPOARQ();
            var i = 0;

            dta.PF088_NUM_DET_ARQ_PROPOSTA = result[i++].Value?.ToString();
            dta.PF088_NOM_DET_ARQ_PROPOSTA = result[i++].Value?.ToString();

            return dta;
        }

    }
}