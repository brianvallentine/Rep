using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0634B
{
    public class PF0634B_PROPOSTA_FIDELIZ : QueryBasis<PF0634B_PROPOSTA_FIDELIZ>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0634B_PROPOSTA_FIDELIZ() { IsCursor = true; }

        public PF0634B_PROPOSTA_FIDELIZ(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUM_SICOB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_VAL_PAGO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_VAL_IOF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_COD_USUARIO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NSAS_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NSL { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NSAC_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO { get; set; }
        public string DCLBILHETE_BILHETE_NUM_BILHETE { get; set; }
        public string DCLBILHETE_BILHETE_NUM_APOLICE { get; set; }
        public string DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string DCLBILHETE_BILHETE_OPC_COBERTURA { get; set; }
        public string DCLBILHETE_BILHETE_DATA_QUITACAO { get; set; }
        public string DCLBILHETE_BILHETE_VAL_RCAP { get; set; }
        public string DCLBILHETE_BILHETE_RAMO { get; set; }
        public string DCLBILHETE_BILHETE_SITUACAO { get; set; }
        public string W_DATA_SITUACAO { get; set; }

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


        public override PF0634B_PROPOSTA_FIDELIZ OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0634B_PROPOSTA_FIDELIZ();
            var i = 0;

            dta.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUM_SICOB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_VAL_PAGO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_VAL_IOF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_COD_USUARIO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NSAS_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NSL = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NSAC_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_RAMO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.W_DATA_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}