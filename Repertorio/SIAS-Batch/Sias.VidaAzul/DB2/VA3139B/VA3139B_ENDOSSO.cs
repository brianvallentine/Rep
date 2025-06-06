using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3139B
{
    public class VA3139B_ENDOSSO : QueryBasis<VA3139B_ENDOSSO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA3139B_ENDOSSO() { IsCursor = true; }

        public VA3139B_ENDOSSO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0ENDO_CODSUBES { get; set; }
        public string V0ENDO_FONTE { get; set; }
        public string V0ENDO_DTEMIS { get; set; }
        public string V0ENDO_DTVENCTO { get; set; }

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


        public override VA3139B_ENDOSSO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA3139B_ENDOSSO();
            var i = 0;

            dta.V0ENDO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0ENDO_NRENDOS = result[i++].Value?.ToString();
            dta.V0ENDO_CODSUBES = result[i++].Value?.ToString();
            dta.V0ENDO_FONTE = result[i++].Value?.ToString();
            dta.V0ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.V0ENDO_DTVENCTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}