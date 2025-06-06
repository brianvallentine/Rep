using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class VA0601B_VGPLARAMC : QueryBasis<VA0601B_VGPLARAMC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0601B_VGPLARAMC() { IsCursor = true; }

        public VA0601B_VGPLARAMC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGPLAR_NUM_RAMO { get; set; }
        public string VGPLAR_NUM_COBERTURA { get; set; }
        public string VGPLAR_QTD_COBERTURA { get; set; }
        public string VGPLAR_IMPSEGURADA { get; set; }
        public string VGPLAR_CUSTO { get; set; }
        public string VGPLAR_PREMIO { get; set; }

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


        public override VA0601B_VGPLARAMC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0601B_VGPLARAMC();
            var i = 0;

            dta.VGPLAR_NUM_RAMO = result[i++].Value?.ToString();
            dta.VGPLAR_NUM_COBERTURA = result[i++].Value?.ToString();
            dta.VGPLAR_QTD_COBERTURA = result[i++].Value?.ToString();
            dta.VGPLAR_IMPSEGURADA = result[i++].Value?.ToString();
            dta.VGPLAR_CUSTO = result[i++].Value?.ToString();
            dta.VGPLAR_PREMIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}