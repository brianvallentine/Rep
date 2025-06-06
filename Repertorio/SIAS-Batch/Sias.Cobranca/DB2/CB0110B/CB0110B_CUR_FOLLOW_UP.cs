using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class CB0110B_CUR_FOLLOW_UP : QueryBasis<CB0110B_CUR_FOLLOW_UP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0110B_CUR_FOLLOW_UP() { IsCursor = true; }

        public CB0110B_CUR_FOLLOW_UP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_AGE_COBRANCA { get; set; }
        public string FOLLOUP_NUM_APOLICE { get; set; }
        public string FOLLOUP_NUM_ENDOSSO { get; set; }
        public string FOLLOUP_NUM_PARCELA { get; set; }
        public string FOLLOUP_DATA_MOVIMENTO { get; set; }
        public string FOLLOUP_HORA_OPERACAO { get; set; }
        public string FOLLOUP_VAL_OPERACAO { get; set; }
        public string FOLLOUP_AGE_AVISO { get; set; }
        public string FOLLOUP_TIPO_SEGURO { get; set; }
        public string FOLLOUP_NUM_AVISO_CREDITO { get; set; }
        public string APOLCOBR_TIPO_COBRANCA { get; set; }
        public string PARCELAS_QTD_DOCUMENTOS { get; set; }
        public string AVISOSAL_SALDO_ATUAL { get; set; }

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


        public override CB0110B_CUR_FOLLOW_UP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0110B_CUR_FOLLOW_UP();
            var i = 0;

            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.FOLLOUP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.FOLLOUP_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.FOLLOUP_NUM_PARCELA = result[i++].Value?.ToString();
            dta.FOLLOUP_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.FOLLOUP_HORA_OPERACAO = result[i++].Value?.ToString();
            dta.FOLLOUP_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.FOLLOUP_AGE_AVISO = result[i++].Value?.ToString();
            dta.FOLLOUP_TIPO_SEGURO = result[i++].Value?.ToString();
            dta.FOLLOUP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.APOLCOBR_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.PARCELAS_QTD_DOCUMENTOS = result[i++].Value?.ToString();
            dta.AVISOSAL_SALDO_ATUAL = result[i++].Value?.ToString();

            return dta;
        }

    }
}