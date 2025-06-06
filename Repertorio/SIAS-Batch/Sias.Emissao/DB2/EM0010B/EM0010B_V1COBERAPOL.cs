using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class EM0010B_V1COBERAPOL : QueryBasis<EM0010B_V1COBERAPOL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0010B_V1COBERAPOL() { IsCursor = true; }

        public EM0010B_V1COBERAPOL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COBT_TARIFARIO_VAR { get; set; }
        public string COBT_TARIFARIO_IX { get; set; }

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


        public override EM0010B_V1COBERAPOL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0010B_V1COBERAPOL();
            var i = 0;

            dta.COBT_TARIFARIO_VAR = result[i++].Value?.ToString();
            dta.COBT_TARIFARIO_IX = result[i++].Value?.ToString();

            return dta;
        }

    }
}