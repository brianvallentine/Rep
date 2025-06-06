using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class CB0155B_V0AVISOCRE : QueryBasis<CB0155B_V0AVISOCRE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0155B_V0AVISOCRE() { IsCursor = true; }

        public CB0155B_V0AVISOCRE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string AVISOCRE_BCO_AVISO { get; set; }
        public string AVISOCRE_AGE_AVISO { get; set; }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string AVISOCRE_NUM_SEQUENCIA { get; set; }
        public string AVISOCRE_DATA_MOVIMENTO { get; set; }
        public string AVISOCRE_TIPO_AVISO { get; set; }
        public string AVISOCRE_DATA_AVISO { get; set; }
        public string AVISOCRE_VAL_DESPESA { get; set; }
        public string AVISOCRE_PRM_LIQUIDO { get; set; }
        public string AVISOCRE_PRM_TOTAL { get; set; }
        public string AVISOCRE_ORIGEM_AVISO { get; set; }
        public string VIND_ORIGEM { get; set; }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string AVISOSAL_SIT_REGISTRO { get; set; }

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


        public override CB0155B_V0AVISOCRE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0155B_V0AVISOCRE();
            var i = 0;

            dta.AVISOCRE_BCO_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_AGE_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.AVISOCRE_NUM_SEQUENCIA = result[i++].Value?.ToString();
            dta.AVISOCRE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.AVISOCRE_TIPO_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_DATA_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_VAL_DESPESA = result[i++].Value?.ToString();
            dta.AVISOCRE_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.AVISOCRE_PRM_TOTAL = result[i++].Value?.ToString();
            dta.AVISOCRE_ORIGEM_AVISO = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.AVISOCRE_ORIGEM_AVISO) ? "-1" : "0";
            dta.AVISOSAL_SALDO_ATUAL = result[i++].Value?.ToString();
            dta.AVISOSAL_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}