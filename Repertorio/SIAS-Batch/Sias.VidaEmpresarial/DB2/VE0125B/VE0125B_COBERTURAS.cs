using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class VE0125B_COBERTURAS : QueryBasis<VE0125B_COBERTURAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0125B_COBERTURAS() { IsCursor = true; }

        public VE0125B_COBERTURAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISCOBPR_NUM_CERTIFICADO { get; set; }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_DATA_TERVIGENCIA { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }

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


        public override VE0125B_COBERTURAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0125B_COBERTURAS();
            var i = 0;

            dta.HISCOBPR_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCOBPR_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPINVPERM = result[i++].Value?.ToString();

            return dta;
        }

    }
}