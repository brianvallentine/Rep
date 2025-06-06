using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0030B
{
    public class BI0030B_CORIGEM : QueryBasis<BI0030B_CORIGEM>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0030B_CORIGEM() { IsCursor = true; }

        public BI0030B_CORIGEM(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ARQSIVPF_SISTEMA_ORIGEM { get; set; }

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


        public override BI0030B_CORIGEM OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0030B_CORIGEM();
            var i = 0;

            dta.ARQSIVPF_SISTEMA_ORIGEM = result[i++].Value?.ToString();

            return dta;
        }

    }
}