using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM1139B
{
    public class EM1139B_V0PARCEHIS : QueryBasis<EM1139B_V0PARCEHIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM1139B_V0PARCEHIS() { IsCursor = true; }

        public EM1139B_V0PARCEHIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ORDEMCOS_NUM_APOLICE { get; set; }
        public string ORDEMCOS_NUM_ENDOSSO { get; set; }
        public string ORDEMCOS_COD_COSSEGURADORA { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_IMP_SEGURADA_VAR { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string PARCEHIS_DATA_MOVIMENTO { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string APOLCOSS_PCT_COM_COSSEGURO { get; set; }

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


        public override EM1139B_V0PARCEHIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM1139B_V0PARCEHIS();
            var i = 0;

            dta.ORDEMCOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ORDEMCOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ORDEMCOS_COD_COSSEGURADORA = result[i++].Value?.ToString();
            dta.APOLICOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_IMP_SEGURADA_VAR = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLCOSS_PCT_COM_COSSEGURO = result[i++].Value?.ToString();

            return dta;
        }

    }
}