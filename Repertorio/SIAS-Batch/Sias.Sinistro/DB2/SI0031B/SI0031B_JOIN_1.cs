using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class SI0031B_JOIN_1 : QueryBasis<SI0031B_JOIN_1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0031B_JOIN_1() { IsCursor = true; }

        public SI0031B_JOIN_1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string H_SIDOCACO_COD_FONTE { get; set; }
        public string H_SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string H_SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string H_SIDOCACO_COD_DOCUMENTO { get; set; }
        public string H_SIDOCACO_NUM_OCORR_DOCACO { get; set; }
        public string H_SIDOCACO_COD_PRODUTO { get; set; }
        public string H_SIDOCACO_COD_GRUPO_CAUSA { get; set; }
        public string H_SIDOCACO_COD_SUBGRUPO_CAUSA { get; set; }
        public string H_SIDOCACO_DATA_INIVIG_DOCPAR { get; set; }
        public string H_SIDOCACO_DATA_MOVTO_DOCACO { get; set; }
        public string H_SIDOCACO_NUM_CARTA { get; set; }
        public string SIDOCPAR_COD_TIPO_CARTA { get; set; }

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


        public override SI0031B_JOIN_1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0031B_JOIN_1();
            var i = 0;

            dta.H_SIDOCACO_COD_FONTE = result[i++].Value?.ToString();
            dta.H_SIDOCACO_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.H_SIDOCACO_DAC_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.H_SIDOCACO_COD_DOCUMENTO = result[i++].Value?.ToString();
            dta.H_SIDOCACO_NUM_OCORR_DOCACO = result[i++].Value?.ToString();
            dta.H_SIDOCACO_COD_PRODUTO = result[i++].Value?.ToString();
            dta.H_SIDOCACO_COD_GRUPO_CAUSA = result[i++].Value?.ToString();
            dta.H_SIDOCACO_COD_SUBGRUPO_CAUSA = result[i++].Value?.ToString();
            dta.H_SIDOCACO_DATA_INIVIG_DOCPAR = result[i++].Value?.ToString();
            dta.H_SIDOCACO_DATA_MOVTO_DOCACO = result[i++].Value?.ToString();
            dta.H_SIDOCACO_NUM_CARTA = result[i++].Value?.ToString();
            dta.SIDOCPAR_COD_TIPO_CARTA = result[i++].Value?.ToString();

            return dta;
        }

    }
}