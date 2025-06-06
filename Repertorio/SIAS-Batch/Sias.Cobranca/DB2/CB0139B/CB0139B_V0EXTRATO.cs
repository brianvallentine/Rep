using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0139B
{
    public class CB0139B_V0EXTRATO : QueryBasis<CB0139B_V0EXTRATO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0139B_V0EXTRATO() { IsCursor = true; }

        public CB0139B_V0EXTRATO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string EXTFUNCE_COD_EMPRESA { get; set; }
        public string EXTFUNCE_COD_ESCNEG { get; set; }
        public string EXTFUNCE_DATA_MOVIMENTO { get; set; }
        public string EXTFUNCE_NRSEQ { get; set; }
        public string EXTFUNCE_TIPO_MOVIMENTO { get; set; }
        public string EXTFUNCE_VAL_MOVIMENTO { get; set; }
        public string EXTFUNCE_DATA_OCORRENCIA { get; set; }
        public string EXTFUNCE_DESC_OCORRENCIA { get; set; }
        public string EXTFUNCE_SALDO_ATUAL { get; set; }
        public string VIND_SALDO { get; set; }

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


        public override CB0139B_V0EXTRATO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0139B_V0EXTRATO();
            var i = 0;

            dta.EXTFUNCE_COD_EMPRESA = result[i++].Value?.ToString();
            dta.EXTFUNCE_COD_ESCNEG = result[i++].Value?.ToString();
            dta.EXTFUNCE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.EXTFUNCE_NRSEQ = result[i++].Value?.ToString();
            dta.EXTFUNCE_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.EXTFUNCE_VAL_MOVIMENTO = result[i++].Value?.ToString();
            dta.EXTFUNCE_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.EXTFUNCE_DESC_OCORRENCIA = result[i++].Value?.ToString();
            dta.EXTFUNCE_SALDO_ATUAL = result[i++].Value?.ToString();
            dta.VIND_SALDO = string.IsNullOrWhiteSpace(dta.EXTFUNCE_SALDO_ATUAL) ? "-1" : "0";

            return dta;
        }

    }
}