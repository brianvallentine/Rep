using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class VA0130B_VGHISTACE : QueryBasis<VA0130B_VGHISTACE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0130B_VGHISTACE() { IsCursor = true; }

        public VA0130B_VGHISTACE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGHISA_NRCERTIF { get; set; }
        public string VGHISA_NUM_ACESSORIO { get; set; }
        public string VGHISA_QTD_COBERTURA { get; set; }
        public string VGHISA_IMPSEGURADA { get; set; }
        public string VGHISA_CUSTO { get; set; }
        public string VGHISA_PREMIO { get; set; }

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


        public override VA0130B_VGHISTACE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0130B_VGHISTACE();
            var i = 0;

            dta.VGHISA_NRCERTIF = result[i++].Value?.ToString();
            dta.VGHISA_NUM_ACESSORIO = result[i++].Value?.ToString();
            dta.VGHISA_QTD_COBERTURA = result[i++].Value?.ToString();
            dta.VGHISA_IMPSEGURADA = result[i++].Value?.ToString();
            dta.VGHISA_CUSTO = result[i++].Value?.ToString();
            dta.VGHISA_PREMIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}