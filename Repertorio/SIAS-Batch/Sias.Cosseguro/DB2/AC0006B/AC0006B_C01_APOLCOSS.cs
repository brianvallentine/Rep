using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class AC0006B_C01_APOLCOSS : QueryBasis<AC0006B_C01_APOLCOSS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0006B_C01_APOLCOSS() { IsCursor = true; }

        public AC0006B_C01_APOLCOSS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLCOSS_NUM_APOLICE { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }

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


        public override AC0006B_C01_APOLCOSS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0006B_C01_APOLCOSS();
            var i = 0;

            dta.APOLCOSS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLCOSS_COD_COSSEGURADORA = result[i++].Value?.ToString();

            return dta;
        }

    }
}