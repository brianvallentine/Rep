using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CS1301B
{
    public class CS1301B_PARCELAS : QueryBasis<CS1301B_PARCELAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CS1301B_PARCELAS() { IsCursor = true; }

        public CS1301B_PARCELAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CLIENTES_CGCCPF { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string ENDOSSOS_DATA_EMISSAO { get; set; }
        public string ENDOSSOS_NUM_RCAP { get; set; }
        public string APOLIAUT_NUM_PROPOSTA_CONV { get; set; }
        public string PARCEHIS_DATA_VENCIMENTO { get; set; }
        public string PARCEHIS_DATA_QUITACAO { get; set; }
        public string ENDOSSOS_VAL_RCAP { get; set; }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string PARCEHIS_VAL_OPERACAO { get; set; }
        public string PARCEHIS_DIFERENCA1 { get; set; }
        public string PARCEHIS_DIFERENCA2 { get; set; }

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


        public override CS1301B_PARCELAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CS1301B_PARCELAS();
            var i = 0;

            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_RCAP = result[i++].Value?.ToString();
            dta.APOLIAUT_NUM_PROPOSTA_CONV = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_VAL_RCAP = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TOTAL = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.PARCEHIS_DIFERENCA1 = result[i++].Value?.ToString();
            dta.PARCEHIS_DIFERENCA2 = result[i++].Value?.ToString();

            return dta;
        }

    }
}