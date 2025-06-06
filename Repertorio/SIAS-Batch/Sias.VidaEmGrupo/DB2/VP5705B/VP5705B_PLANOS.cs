using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP5705B
{
    public class VP5705B_PLANOS : QueryBasis<VP5705B_PLANOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP5705B_PLANOS() { IsCursor = true; }

        public VP5705B_PLANOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SQL_NRPARCEL { get; set; }
        public string SQL_PERC_COMIS { get; set; }

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


        public override VP5705B_PLANOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP5705B_PLANOS();
            var i = 0;

            dta.SQL_NRPARCEL = result[i++].Value?.ToString();
            dta.SQL_PERC_COMIS = result[i++].Value?.ToString();

            return dta;
        }

    }
}