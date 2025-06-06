using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0126B
{
    public class VA0126B_CUR_MOVTO : QueryBasis<VA0126B_CUR_MOVTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0126B_CUR_MOVTO() { IsCursor = true; }

        public VA0126B_CUR_MOVTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_COPIAS { get; set; }
        public string RELATORI_QUANTIDADE { get; set; }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string RELATORI_MES_REFERENCIA { get; set; }
        public string RELATORI_ANO_REFERENCIA { get; set; }
        public string RELATORI_ORGAO_EMISSOR { get; set; }
        public string RELATORI_COD_FONTE { get; set; }
        public string RELATORI_COD_PRODUTOR { get; set; }
        public string RELATORI_RAMO_EMISSOR { get; set; }
        public string RELATORI_COD_MODALIDADE { get; set; }
        public string RELATORI_COD_CONGENERE { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }
        public string RELATORI_COD_PLANO { get; set; }
        public string RELATORI_OCORR_HISTORICO { get; set; }
        public string RELATORI_NUM_APOL_LIDER { get; set; }
        public string RELATORI_ENDOS_LIDER { get; set; }
        public string RELATORI_NUM_PARC_LIDER { get; set; }
        public string RELATORI_NUM_SINISTRO { get; set; }
        public string RELATORI_NUM_SINI_LIDER { get; set; }
        public string RELATORI_NUM_ORDEM { get; set; }
        public string RELATORI_COD_MOEDA { get; set; }
        public string RELATORI_TIPO_CORRECAO { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }
        public string RELATORI_IND_PREV_DEFINIT { get; set; }
        public string RELATORI_IND_ANAL_RESUMO { get; set; }
        public string RELATORI_COD_EMPRESA { get; set; }
        public string RELATORI_PERI_RENOVACAO { get; set; }
        public string RELATORI_PCT_AUMENTO { get; set; }
        public string RELATORI_TIMESTAMP { get; set; }

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


        public override VA0126B_CUR_MOVTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0126B_CUR_MOVTO();
            var i = 0;

            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_COPIAS = result[i++].Value?.ToString();
            dta.RELATORI_QUANTIDADE = result[i++].Value?.ToString();
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_MES_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.RELATORI_COD_FONTE = result[i++].Value?.ToString();
            dta.RELATORI_COD_PRODUTOR = result[i++].Value?.ToString();
            dta.RELATORI_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.RELATORI_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.RELATORI_COD_CONGENERE = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATORI_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.RELATORI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_TITULO = result[i++].Value?.ToString();
            dta.RELATORI_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.RELATORI_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_PLANO = result[i++].Value?.ToString();
            dta.RELATORI_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOL_LIDER = result[i++].Value?.ToString();
            dta.RELATORI_ENDOS_LIDER = result[i++].Value?.ToString();
            dta.RELATORI_NUM_PARC_LIDER = result[i++].Value?.ToString();
            dta.RELATORI_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_SINI_LIDER = result[i++].Value?.ToString();
            dta.RELATORI_NUM_ORDEM = result[i++].Value?.ToString();
            dta.RELATORI_COD_MOEDA = result[i++].Value?.ToString();
            dta.RELATORI_TIPO_CORRECAO = result[i++].Value?.ToString();
            dta.RELATORI_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RELATORI_IND_PREV_DEFINIT = result[i++].Value?.ToString();
            dta.RELATORI_IND_ANAL_RESUMO = result[i++].Value?.ToString();
            dta.RELATORI_COD_EMPRESA = result[i++].Value?.ToString();
            dta.RELATORI_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.RELATORI_PCT_AUMENTO = result[i++].Value?.ToString();
            dta.RELATORI_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}