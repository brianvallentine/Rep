using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0706B
{
    public class PF0706B_C01_BILHETE : QueryBasis<PF0706B_C01_BILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0706B_C01_BILHETE() { IsCursor = true; }

        public PF0706B_C01_BILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLBILHETE_BILHETE_NUM_BILHETE { get; set; }
        public string DCLBILHETE_BILHETE_NUM_APOLICE { get; set; }
        public string DCLBILHETE_BILHETE_FONTE { get; set; }
        public string DCLBILHETE_BILHETE_AGE_COBRANCA { get; set; }
        public string DCLBILHETE_BILHETE_NUM_MATRICULA { get; set; }
        public string DCLBILHETE_BILHETE_COD_AGENCIA { get; set; }
        public string DCLBILHETE_BILHETE_OPERACAO_CONTA { get; set; }
        public string DCLBILHETE_BILHETE_NUM_CONTA { get; set; }
        public string DCLBILHETE_BILHETE_DIG_CONTA { get; set; }
        public string DCLBILHETE_BILHETE_COD_CLIENTE { get; set; }
        public string DCLBILHETE_BILHETE_PROFISSAO { get; set; }
        public string DCLBILHETE_BILHETE_IDE_SEXO { get; set; }
        public string DCLBILHETE_BILHETE_ESTADO_CIVIL { get; set; }
        public string DCLBILHETE_BILHETE_OCORR_ENDERECO { get; set; }
        public string DCLBILHETE_BILHETE_COD_AGENCIA_DEB { get; set; }
        public string DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB { get; set; }
        public string DCLBILHETE_BILHETE_NUM_CONTA_DEB { get; set; }
        public string DCLBILHETE_BILHETE_DIG_CONTA_DEB { get; set; }
        public string DCLBILHETE_BILHETE_OPC_COBERTURA { get; set; }
        public string DCLBILHETE_BILHETE_DATA_QUITACAO { get; set; }
        public string DCLBILHETE_BILHETE_VAL_RCAP { get; set; }
        public string DCLBILHETE_BILHETE_RAMO { get; set; }
        public string DCLBILHETE_BILHETE_DATA_VENDA { get; set; }
        public string DCLBILHETE_BILHETE_DATA_MOVIMENTO { get; set; }
        public string DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string DCLBILHETE_BILHETE_SITUACAO { get; set; }
        public string DCLBILHETE_BILHETE_TIP_CANCELAMENTO { get; set; }
        public string DCLBILHETE_BILHETE_SIT_SINISTRO { get; set; }
        public string DCLBILHETE_BILHETE_COD_USUARIO { get; set; }
        public string WHOST_DATA_REFERENCIA { get; set; }
        public string VIND_DT_REFERENCIA { get; set; }
        public string DCLBILHETE_BILHETE_DATA_CANCELAMENTO { get; set; }
        public string VIND_DT_CANCELAMENTO { get; set; }

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


        public override PF0706B_C01_BILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0706B_C01_BILHETE();
            var i = 0;

            dta.DCLBILHETE_BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_FONTE = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_COD_AGENCIA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_CONTA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_DIG_CONTA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_PROFISSAO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_IDE_SEXO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_RAMO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_DATA_VENDA = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_TIP_CANCELAMENTO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_SIT_SINISTRO = result[i++].Value?.ToString();
            dta.DCLBILHETE_BILHETE_COD_USUARIO = result[i++].Value?.ToString();
            dta.WHOST_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.VIND_DT_REFERENCIA = string.IsNullOrWhiteSpace(dta.WHOST_DATA_REFERENCIA) ? "-1" : "0";
            dta.DCLBILHETE_BILHETE_DATA_CANCELAMENTO = result[i++].Value?.ToString();
            dta.VIND_DT_CANCELAMENTO = string.IsNullOrWhiteSpace(dta.DCLBILHETE_BILHETE_DATA_CANCELAMENTO) ? "-1" : "0";

            return dta;
        }

    }
}