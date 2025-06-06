using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class VA0141B_V0APOLCOSS : QueryBasis<VA0141B_V0APOLCOSS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0141B_V0APOLCOSS() { IsCursor = true; }

        public VA0141B_V0APOLCOSS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

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


        public override VA0141B_V0APOLCOSS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0141B_V0APOLCOSS();
            var i = 0;

            dta.APOLCOSS_COD_COSSEGURADORA = result[i++].Value?.ToString();

            return dta;
        }

    }
}