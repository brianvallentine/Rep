using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI5166B
{
    public class BI5166B_V0BILHETE : QueryBasis<BI5166B_V0BILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI5166B_V0BILHETE() { IsCursor = true; }

        public BI5166B_V0BILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string BILHETE_AGE_COBRANCA { get; set; }
        public string BILHETE_NUM_CONTA { get; set; }
        public string BILHETE_DIG_CONTA { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }
        public string BILHETE_PROFISSAO { get; set; }
        public string BILHETE_IDE_SEXO { get; set; }
        public string BILHETE_ESTADO_CIVIL { get; set; }
        public string BILHETE_OCORR_ENDERECO { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_DATA_VENDA { get; set; }
        public string BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_TIP_CANCELAMENTO { get; set; }
        public string BILHETE_SIT_SINISTRO { get; set; }
        public string BILHETE_COD_USUARIO { get; set; }
        public string BILHETE_DATA_CANCELAMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string VIND_NULL02 { get; set; }

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


        public override BI5166B_V0BILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI5166B_V0BILHETE();
            var i = 0;

            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_FONTE = result[i++].Value?.ToString();
            dta.BILHETE_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.BILHETE_NUM_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_DIG_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.BILHETE_PROFISSAO = result[i++].Value?.ToString();
            dta.BILHETE_IDE_SEXO = result[i++].Value?.ToString();
            dta.BILHETE_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.BILHETE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_VENDA = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.BILHETE_TIP_CANCELAMENTO = result[i++].Value?.ToString();
            dta.BILHETE_SIT_SINISTRO = result[i++].Value?.ToString();
            dta.BILHETE_COD_USUARIO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_CANCELAMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.BILHETE_DATA_CANCELAMENTO) ? "-1" : "0";
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";

            return dta;
        }

    }
}