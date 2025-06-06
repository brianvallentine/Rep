using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class BI7028B_CVG033 : QueryBasis<BI7028B_CVG033>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI7028B_CVG033() { IsCursor = true; }

        public BI7028B_CVG033(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGCOBSUB_COD_COBERTURA { get; set; }
        public string VG033_DES_ACESSORIO { get; set; }

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


        public override BI7028B_CVG033 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI7028B_CVG033();
            var i = 0;

            dta.VGCOBSUB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.VG033_DES_ACESSORIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}