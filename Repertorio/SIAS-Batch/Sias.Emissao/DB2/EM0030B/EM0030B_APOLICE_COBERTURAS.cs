using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class EM0030B_APOLICE_COBERTURAS : QueryBasis<EM0030B_APOLICE_COBERTURAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0030B_APOLICE_COBERTURAS() { IsCursor = true; }

        public EM0030B_APOLICE_COBERTURAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ENDOSSO { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_MODALI_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_DATA_INIVIGENCIA { get; set; }
        public string APOLICOB_DATA_TERVIGENCIA { get; set; }

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


        public override EM0030B_APOLICE_COBERTURAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0030B_APOLICE_COBERTURAS();
            var i = 0;

            dta.APOLICOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.APOLICOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_MODALI_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}