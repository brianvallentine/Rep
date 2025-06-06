using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class BI0072B_V0PARC : QueryBasis<BI0072B_V0PARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0072B_V0PARC() { IsCursor = true; }

        public BI0072B_V0PARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1MVDB_NRENDOS1 { get; set; }

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


        public override BI0072B_V0PARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0072B_V0PARC();
            var i = 0;

            dta.V1MVDB_NRENDOS1 = result[i++].Value?.ToString();

            return dta;
        }

    }
}