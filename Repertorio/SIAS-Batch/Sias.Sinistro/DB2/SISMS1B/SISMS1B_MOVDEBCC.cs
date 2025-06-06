using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISMS1B
{
    public class SISMS1B_MOVDEBCC : QueryBasis<SISMS1B_MOVDEBCC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SISMS1B_MOVDEBCC() { IsCursor = true; }

        public SISMS1B_MOVDEBCC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_RAMO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string GE367_NUM_PESSOA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_DATA_ENVIO { get; set; }
        public string MOVDEBCE_DATA_RETORNO { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string GE369_COD_BANCO { get; set; }
        public string GE369_COD_AGENCIA { get; set; }
        public string GE369_NUM_CONTA_CNB { get; set; }
        public string GE369_NUM_DV_CONTA_CNB { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string OD002_NOM_PESSOA { get; set; }
        public string OD002_NUM_CPF { get; set; }
        public string OD002_NUM_DV_CPF { get; set; }
        public string OD005_DES_EMAIL { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }

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


        public override SISMS1B_MOVDEBCC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SISMS1B_MOVDEBCC();
            var i = 0;

            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.GE367_NUM_PESSOA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_ENVIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_RETORNO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VLR_CREDITO = result[i++].Value?.ToString();
            dta.GE369_COD_BANCO = result[i++].Value?.ToString();
            dta.GE369_COD_AGENCIA = result[i++].Value?.ToString();
            dta.GE369_NUM_CONTA_CNB = result[i++].Value?.ToString();
            dta.GE369_NUM_DV_CONTA_CNB = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.OD002_NOM_PESSOA = result[i++].Value?.ToString();
            dta.OD002_NUM_CPF = result[i++].Value?.ToString();
            dta.OD002_NUM_DV_CPF = result[i++].Value?.ToString();
            dta.OD005_DES_EMAIL = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_CERTIFICADO = result[i++].Value?.ToString();

            return dta;
        }

    }
}