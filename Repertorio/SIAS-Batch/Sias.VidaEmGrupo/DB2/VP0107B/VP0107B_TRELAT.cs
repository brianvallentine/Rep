using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0107B
{
    public class VP0107B_TRELAT : QueryBasis<VP0107B_TRELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0107B_TRELAT() { IsCursor = true; }

        public VP0107B_TRELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DATA_SOLICITACAO { get; set; }
        public string NRCOPIAS { get; set; }

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


        public override VP0107B_TRELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0107B_TRELAT();
            var i = 0;

            dta.DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.NRCOPIAS = result[i++].Value?.ToString();

            return dta;
        }

    }
}