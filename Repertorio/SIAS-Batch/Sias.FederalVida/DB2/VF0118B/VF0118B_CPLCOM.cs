using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class VF0118B_CPLCOM : QueryBasis<VF0118B_CPLCOM>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0118B_CPLCOM() { IsCursor = true; }

        public VF0118B_CPLCOM(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PLCOM_CODPDT { get; set; }

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


        public override VF0118B_CPLCOM OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0118B_CPLCOM();
            var i = 0;

            dta.PLCOM_CODPDT = result[i++].Value?.ToString();

            return dta;
        }

    }
}