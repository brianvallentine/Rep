using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class BI8005B_V1RCAPCOMP : QueryBasis<BI8005B_V1RCAPCOMP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI8005B_V1RCAPCOMP() { IsCursor = true; }

        public BI8005B_V1RCAPCOMP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1RCAC_FONTE { get; set; }
        public string V1RCAC_NRRCAP { get; set; }
        public string V1RCAC_NRRCAPCO { get; set; }
        public string V1RCAC_OPERACAO { get; set; }
        public string V1RCAC_DTMOVTO { get; set; }
        public string V1RCAC_HORAOPER { get; set; }
        public string V1RCAC_SITUACAO { get; set; }
        public string V1RCAC_BCOAVISO { get; set; }
        public string V1RCAC_AGEAVISO { get; set; }
        public string V1RCAC_NRAVISO { get; set; }
        public string V1RCAC_VLRCAP { get; set; }
        public string V1RCAC_DATARCAP { get; set; }
        public string V1RCAC_DTCADAST { get; set; }
        public string V1RCAC_SITCONTB { get; set; }

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


        public override BI8005B_V1RCAPCOMP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI8005B_V1RCAPCOMP();
            var i = 0;

            dta.V1RCAC_FONTE = result[i++].Value?.ToString();
            dta.V1RCAC_NRRCAP = result[i++].Value?.ToString();
            dta.V1RCAC_NRRCAPCO = result[i++].Value?.ToString();
            dta.V1RCAC_OPERACAO = result[i++].Value?.ToString();
            dta.V1RCAC_DTMOVTO = result[i++].Value?.ToString();
            dta.V1RCAC_HORAOPER = result[i++].Value?.ToString();
            dta.V1RCAC_SITUACAO = result[i++].Value?.ToString();
            dta.V1RCAC_BCOAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_AGEAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_NRAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_VLRCAP = result[i++].Value?.ToString();
            dta.V1RCAC_DATARCAP = result[i++].Value?.ToString();
            dta.V1RCAC_DTCADAST = result[i++].Value?.ToString();
            dta.V1RCAC_SITCONTB = result[i++].Value?.ToString();

            return dta;
        }

    }
}