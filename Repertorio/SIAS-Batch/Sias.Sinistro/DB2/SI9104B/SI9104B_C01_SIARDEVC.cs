using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9104B
{
    public class SI9104B_C01_SIARDEVC : QueryBasis<SI9104B_C01_SIARDEVC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI9104B_C01_SIARDEVC() { IsCursor = true; }

        public SI9104B_C01_SIARDEVC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SIARDEVC_NOM_ARQUIVO { get; set; }
        public string SIARDEVC_SEQ_GERACAO { get; set; }
        public string SIARDEVC_TIPO_REGISTRO { get; set; }
        public string SIARDEVC_SEQ_REGISTRO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_NUM_SINISTRO_VC { get; set; }
        public string SIARDEVC_NUM_EXPEDIENTE_VC { get; set; }
        public string SIARDEVC_IND_FAVORECIDO { get; set; }
        public string SIARDEVC_CGCCPF { get; set; }
        public string SIARDEVC_TIPO_PESSOA { get; set; }
        public string SIARDEVC_NOM_FAVORECIDO { get; set; }
        public string SIARDEVC_COD_BANCO { get; set; }
        public string SIARDEVC_COD_AGENCIA { get; set; }
        public string SIARDEVC_OPERACAO_CONTA { get; set; }
        public string SIARDEVC_COD_CONTA { get; set; }
        public string SIARDEVC_DV_CONTA { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string SIARDEVC_NUM_ENDOSSO { get; set; }
        public string SIARDEVC_NUM_ITEM { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }
        public string SIARDEVC_COD_COBERTURA { get; set; }
        public string SIARDEVC_DATA_OCORRENCIA { get; set; }
        public string SIARDEVC_DATA_NEGOCIADA { get; set; }
        public string SIARDEVC_COD_CAUSA { get; set; }
        public string SIARDEVC_VAL_TOT_MOVIMENTO { get; set; }
        public string SIARDEVC_VAL_MAO_OBRA { get; set; }
        public string SIARDEVC_IND_FORMA_PAGTO { get; set; }
        public string SIARDEVC_NOM_BAIRRO { get; set; }
        public string SIARDEVC_NOM_CIDADE { get; set; }
        public string SIARDEVC_COD_UF { get; set; }
        public string SIARDEVC_NUM_CEP { get; set; }
        public string SIARDEVC_NUM_DDD { get; set; }
        public string SIARDEVC_NUM_TELEFONE { get; set; }
        public string SIARDEVC_IND_DOC_FISCAL { get; set; }
        public string SIARDEVC_NUM_DOC_FISCAL { get; set; }
        public string SIARDEVC_SERIE_DOC_FISCAL { get; set; }
        public string SIARDEVC_DATA_EMISSAO { get; set; }
        public string IND_DATA_EMISSAO { get; set; }
        public string SIARDEVC_COD_FONTE { get; set; }

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


        public override SI9104B_C01_SIARDEVC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI9104B_C01_SIARDEVC();
            var i = 0;

            dta.SIARDEVC_NOM_ARQUIVO = result[i++].Value?.ToString();
            dta.SIARDEVC_SEQ_GERACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_SEQ_REGISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_SINISTRO_VC = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_EXPEDIENTE_VC = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_FAVORECIDO = result[i++].Value?.ToString();
            dta.SIARDEVC_CGCCPF = result[i++].Value?.ToString();
            dta.SIARDEVC_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_FAVORECIDO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_BANCO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_AGENCIA = result[i++].Value?.ToString();
            dta.SIARDEVC_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_CONTA = result[i++].Value?.ToString();
            dta.SIARDEVC_DV_CONTA = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_ITEM = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_RAMO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_NEGOCIADA = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_CAUSA = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_TOT_MOVIMENTO = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_MAO_OBRA = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_FORMA_PAGTO = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_CIDADE = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_UF = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CEP = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_DDD = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_TELEFONE = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_DOC_FISCAL = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_DOC_FISCAL = result[i++].Value?.ToString();
            dta.SIARDEVC_SERIE_DOC_FISCAL = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.IND_DATA_EMISSAO = string.IsNullOrWhiteSpace(dta.SIARDEVC_DATA_EMISSAO) ? "-1" : "0";
            dta.SIARDEVC_COD_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}