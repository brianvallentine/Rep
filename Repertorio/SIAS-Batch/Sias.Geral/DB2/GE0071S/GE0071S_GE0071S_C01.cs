using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0071S
{
    public class GE0071S_GE0071S_C01 : QueryBasis<GE0071S_GE0071S_C01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0071S_GE0071S_C01() { IsCursor = true; }

        public GE0071S_GE0071S_C01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE091_COD_COBERTURA { get; set; }
        public string GE091_VLR_IS { get; set; }
        public string GE091_VLR_PREMIO { get; set; }
        public string GE091_PCT_PARTICIPACAO { get; set; }
        public string GE118_IND_TIPO_COBERTURA { get; set; }
        public string GE118_IND_SINISTRO_CANCELA { get; set; }
        public string GE118_IND_INDENIZA_MAIS_VEZES { get; set; }
        public string GE118_COD_RAMO_COBERTURA { get; set; }
        public string GE118_DES_APRESENTA_DOC { get; set; }

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


        public override GE0071S_GE0071S_C01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0071S_GE0071S_C01();
            var i = 0;

            dta.GE091_COD_COBERTURA = result[i++].Value?.ToString();
            dta.GE091_VLR_IS = result[i++].Value?.ToString();
            dta.GE091_VLR_PREMIO = result[i++].Value?.ToString();
            dta.GE091_PCT_PARTICIPACAO = result[i++].Value?.ToString();
            dta.GE118_IND_TIPO_COBERTURA = result[i++].Value?.ToString();
            dta.GE118_IND_SINISTRO_CANCELA = result[i++].Value?.ToString();
            dta.GE118_IND_INDENIZA_MAIS_VEZES = result[i++].Value?.ToString();
            dta.GE118_COD_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.GE118_DES_APRESENTA_DOC = result[i++].Value?.ToString();

            return dta;
        }

    }
}