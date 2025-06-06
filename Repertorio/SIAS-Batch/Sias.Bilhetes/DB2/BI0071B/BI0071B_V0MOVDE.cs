using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class BI0071B_V0MOVDE : QueryBasis<BI0071B_V0MOVDE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0071B_V0MOVDE() { IsCursor = true; }

        public BI0071B_V0MOVDE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MOVDE_COD_CONVENIO { get; set; }
        public string V0MOVDE_COD_AGENCIA_DEB { get; set; }
        public string V0MOVDE_OPER_CONTA_DEB { get; set; }
        public string V0MOVDE_NUM_CONTA_DEB { get; set; }
        public string V0MOVDE_DIG_CONTA_DEB { get; set; }
        public string V0MOVDE_DTVENCTO { get; set; }
        public string V0MOVDE_DTVENCTO_5 { get; set; }
        public string V0MOVDE_VLR_DEBITO { get; set; }
        public string V0MOVDE_NUM_APOLICE { get; set; }
        public string V0MOVDE_NRENDOS { get; set; }
        public string V0MOVDE_NRPARCEL { get; set; }
        public string V0MOVDE_DIA_DEBITO { get; set; }
        public string V0MOVDE_SIT_COBRANCA { get; set; }
        public string V0MOVDE_COD_RETORNO_CEF { get; set; }
        public string VIND_COD_RETORNO { get; set; }
        public string V0MOVDE_DAYS { get; set; }
        public string V0MOVDE_NSAS { get; set; }
        public string V0MOVDE_COD_USUARIO { get; set; }

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


        public override BI0071B_V0MOVDE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0071B_V0MOVDE();
            var i = 0;

            dta.V0MOVDE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.V0MOVDE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.V0MOVDE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.V0MOVDE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.V0MOVDE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.V0MOVDE_DTVENCTO = result[i++].Value?.ToString();
            dta.V0MOVDE_DTVENCTO_5 = result[i++].Value?.ToString();
            dta.V0MOVDE_VLR_DEBITO = result[i++].Value?.ToString();
            dta.V0MOVDE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0MOVDE_NRENDOS = result[i++].Value?.ToString();
            dta.V0MOVDE_NRPARCEL = result[i++].Value?.ToString();
            dta.V0MOVDE_DIA_DEBITO = result[i++].Value?.ToString();
            dta.V0MOVDE_SIT_COBRANCA = result[i++].Value?.ToString();
            dta.V0MOVDE_COD_RETORNO_CEF = result[i++].Value?.ToString();
            dta.VIND_COD_RETORNO = string.IsNullOrWhiteSpace(dta.V0MOVDE_COD_RETORNO_CEF) ? "-1" : "0";
            dta.V0MOVDE_DAYS = result[i++].Value?.ToString();
            dta.V0MOVDE_NSAS = result[i++].Value?.ToString();
            dta.V0MOVDE_COD_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}