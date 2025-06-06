using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class VA2601B_VGPLAACES : QueryBasis<VA2601B_VGPLAACES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2601B_VGPLAACES() { IsCursor = true; }

        public VA2601B_VGPLAACES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGPLAA_NUM_ACESSORIO { get; set; }
        public string VGPLAA_QTD_COBERTURA { get; set; }
        public string VGPLAA_IMPSEGURADA { get; set; }
        public string VGPLAA_CUSTO { get; set; }
        public string VGPLAA_PREMIO { get; set; }

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


        public override VA2601B_VGPLAACES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2601B_VGPLAACES();
            var i = 0;

            dta.VGPLAA_NUM_ACESSORIO = result[i++].Value?.ToString();
            dta.VGPLAA_QTD_COBERTURA = result[i++].Value?.ToString();
            dta.VGPLAA_IMPSEGURADA = result[i++].Value?.ToString();
            dta.VGPLAA_CUSTO = result[i++].Value?.ToString();
            dta.VGPLAA_PREMIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}