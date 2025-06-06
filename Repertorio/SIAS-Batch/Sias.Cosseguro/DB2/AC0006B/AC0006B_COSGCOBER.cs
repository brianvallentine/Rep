using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class AC0006B_COSGCOBER : QueryBasis<AC0006B_COSGCOBER>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0006B_COSGCOBER() { IsCursor = true; }

        public AC0006B_COSGCOBER(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE397_NUM_APOLICE { get; set; }
        public string GE397_NUM_ENDOSSO { get; set; }
        public string GE397_COD_RAMO_COBER { get; set; }
        public string GE397_COD_COBERTURA { get; set; }
        public string GE397_VLR_IMP_SEGUR_VAR { get; set; }
        public string GE397_VLR_PREMIO_TARIF_VAR { get; set; }
        public string GE398_COD_COSSEGURADORA { get; set; }
        public string GE398_PCT_PARTIC_COBER { get; set; }
        public string GE398_PCT_COMCOS_COBER { get; set; }

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


        public override AC0006B_COSGCOBER OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0006B_COSGCOBER();
            var i = 0;

            dta.GE397_NUM_APOLICE = result[i++].Value?.ToString();
            dta.GE397_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.GE397_COD_RAMO_COBER = result[i++].Value?.ToString();
            dta.GE397_COD_COBERTURA = result[i++].Value?.ToString();
            dta.GE397_VLR_IMP_SEGUR_VAR = result[i++].Value?.ToString();
            dta.GE397_VLR_PREMIO_TARIF_VAR = result[i++].Value?.ToString();
            dta.GE398_COD_COSSEGURADORA = result[i++].Value?.ToString();
            dta.GE398_PCT_PARTIC_COBER = result[i++].Value?.ToString();
            dta.GE398_PCT_COMCOS_COBER = result[i++].Value?.ToString();

            return dta;
        }

    }
}