using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class EM0010B_V1RCAPCOMP : QueryBasis<EM0010B_V1RCAPCOMP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0010B_V1RCAPCOMP() { IsCursor = true; }

        public EM0010B_V1RCAPCOMP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PCOM_FONTE { get; set; }
        public string PCOM_NRRCAP { get; set; }
        public string PCOM_NRRCAPCO { get; set; }
        public string PCOM_OPERACAO { get; set; }
        public string PCOM_DTMOVTO { get; set; }
        public string PCOM_HORAOPER { get; set; }
        public string PCOM_SITUACAO { get; set; }
        public string PCOM_BCOAVISO { get; set; }
        public string PCOM_AGEAVISO { get; set; }
        public string PCOM_NRAVISO { get; set; }
        public string PCOM_VLRCAP { get; set; }
        public string PCOM_DATARCAP { get; set; }
        public string PCOM_DTCADAST { get; set; }
        public string PCOM_SITCONTB { get; set; }

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


        public override EM0010B_V1RCAPCOMP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0010B_V1RCAPCOMP();
            var i = 0;

            dta.PCOM_FONTE = result[i++].Value?.ToString();
            dta.PCOM_NRRCAP = result[i++].Value?.ToString();
            dta.PCOM_NRRCAPCO = result[i++].Value?.ToString();
            dta.PCOM_OPERACAO = result[i++].Value?.ToString();
            dta.PCOM_DTMOVTO = result[i++].Value?.ToString();
            dta.PCOM_HORAOPER = result[i++].Value?.ToString();
            dta.PCOM_SITUACAO = result[i++].Value?.ToString();
            dta.PCOM_BCOAVISO = result[i++].Value?.ToString();
            dta.PCOM_AGEAVISO = result[i++].Value?.ToString();
            dta.PCOM_NRAVISO = result[i++].Value?.ToString();
            dta.PCOM_VLRCAP = result[i++].Value?.ToString();
            dta.PCOM_DATARCAP = result[i++].Value?.ToString();
            dta.PCOM_DTCADAST = result[i++].Value?.ToString();
            dta.PCOM_SITCONTB = result[i++].Value?.ToString();

            return dta;
        }

    }
}