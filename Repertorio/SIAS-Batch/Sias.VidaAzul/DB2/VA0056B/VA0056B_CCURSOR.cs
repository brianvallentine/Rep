using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0056B
{
    public class VA0056B_CCURSOR : QueryBasis<VA0056B_CCURSOR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0056B_CCURSOR() { IsCursor = true; }

        public VA0056B_CCURSOR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }

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


        public override VA0056B_CCURSOR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0056B_CCURSOR();
            var i = 0;

            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}