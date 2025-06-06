using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0891B
{
    public class SI0891B_CMOTI : QueryBasis<SI0891B_CMOTI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0891B_CMOTI() { IsCursor = true; }

        public SI0891B_CMOTI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SITIPMOT_DES_TIPO_MOTIVO { get; set; }

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


        public override SI0891B_CMOTI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0891B_CMOTI();
            var i = 0;

            dta.SITIPMOT_DES_TIPO_MOTIVO = result[i++].Value?.ToString();

            return dta;
        }

    }
}