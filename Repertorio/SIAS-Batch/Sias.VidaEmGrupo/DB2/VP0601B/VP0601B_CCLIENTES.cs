using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class VP0601B_CCLIENTES : QueryBasis<VP0601B_CCLIENTES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0601B_CCLIENTES() { IsCursor = true; }

        public VP0601B_CCLIENTES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLCLIENTES_COD_CLIENTE { get; set; }

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


        public override VP0601B_CCLIENTES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0601B_CCLIENTES();
            var i = 0;

            dta.DCLCLIENTES_COD_CLIENTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}