using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class VA0123B_CURS02 : QueryBasis<VA0123B_CURS02>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0123B_CURS02() { IsCursor = true; }

        public VA0123B_CURS02(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ENDOSSO { get; set; }
        public string APOLICOB_NUM_ITEM { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_MODALI_COBERTURA { get; set; }
        public string APOLICOB_OCORR_HISTORICO { get; set; }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_IMP_SEGURADA_VAR { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string APOLICOB_PCT_COBERTURA { get; set; }
        public string APOLICOB_FATOR_MULTIPLICA { get; set; }

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


        public override VA0123B_CURS02 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0123B_CURS02();
            var i = 0;

            dta.APOLICOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLICOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_MODALI_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.APOLICOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.APOLICOB_IMP_SEGURADA_VAR = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            dta.APOLICOB_PCT_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_FATOR_MULTIPLICA = result[i++].Value?.ToString();

            return dta;
        }

    }
}