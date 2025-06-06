using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0230B
{
    public class R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            , DATA_SOLICITACAO
            , IDE_SISTEMA
            , COD_RELATORIO
            , NUM_COPIAS
            , QUANTIDADE
            , PERI_INICIAL
            , PERI_FINAL
            ,(PERI_FINAL + 01 DAYS)
            , DATA_REFERENCIA
            , MES_REFERENCIA
            , ANO_REFERENCIA
            , ORGAO_EMISSOR
            , COD_FONTE
            , COD_PRODUTOR
            , RAMO_EMISSOR
            , COD_MODALIDADE
            , COD_CONGENERE
            , NUM_APOLICE
            , NUM_ENDOSSO
            , NUM_PARCELA
            , NUM_CERTIFICADO
            , NUM_TITULO
            , COD_SUBGRUPO
            , COD_OPERACAO
            , COD_PLANO
            , OCORR_HISTORICO
            , NUM_APOL_LIDER
            , ENDOS_LIDER
            , NUM_PARC_LIDER
            , NUM_SINISTRO
            , NUM_SINI_LIDER
            , NUM_ORDEM
            , COD_MOEDA
            , TIPO_CORRECAO
            , SIT_REGISTRO
            , IND_PREV_DEFINIT
            , IND_ANAL_RESUMO
            , COD_EMPRESA
            , PERI_RENOVACAO
            , PCT_AUMENTO
            INTO :RELATORI-COD-USUARIO
            ,:RELATORI-DATA-SOLICITACAO
            ,:RELATORI-IDE-SISTEMA
            ,:RELATORI-COD-RELATORIO
            ,:RELATORI-NUM-COPIAS
            ,:RELATORI-QUANTIDADE
            ,:RELATORI-PERI-INICIAL
            ,:RELATORI-PERI-FINAL
            ,:WSHOST-DTINIVIG
            ,:RELATORI-DATA-REFERENCIA
            ,:RELATORI-MES-REFERENCIA
            ,:RELATORI-ANO-REFERENCIA
            ,:RELATORI-ORGAO-EMISSOR
            ,:RELATORI-COD-FONTE
            ,:RELATORI-COD-PRODUTOR
            ,:RELATORI-RAMO-EMISSOR
            ,:RELATORI-COD-MODALIDADE
            ,:RELATORI-COD-CONGENERE
            ,:RELATORI-NUM-APOLICE
            ,:RELATORI-NUM-ENDOSSO
            ,:RELATORI-NUM-PARCELA
            ,:RELATORI-NUM-CERTIFICADO
            ,:RELATORI-NUM-TITULO
            ,:RELATORI-COD-SUBGRUPO
            ,:RELATORI-COD-OPERACAO
            ,:RELATORI-COD-PLANO
            ,:RELATORI-OCORR-HISTORICO
            ,:RELATORI-NUM-APOL-LIDER
            ,:RELATORI-ENDOS-LIDER
            ,:RELATORI-NUM-PARC-LIDER
            ,:RELATORI-NUM-SINISTRO
            ,:RELATORI-NUM-SINI-LIDER
            ,:RELATORI-NUM-ORDEM
            ,:RELATORI-COD-MOEDA
            ,:RELATORI-TIPO-CORRECAO
            ,:RELATORI-SIT-REGISTRO
            ,:RELATORI-IND-PREV-DEFINIT
            ,:RELATORI-IND-ANAL-RESUMO
            ,:RELATORI-COD-EMPRESA:VIND-NULL01
            ,:RELATORI-PERI-RENOVACAO:VIND-NULL02
            ,:RELATORI-PCT-AUMENTO:VIND-NULL03
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'BI'
            AND COD_RELATORIO = 'BI0230B1'
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											, DATA_SOLICITACAO
											, IDE_SISTEMA
											, COD_RELATORIO
											, NUM_COPIAS
											, QUANTIDADE
											, PERI_INICIAL
											, PERI_FINAL
											,(PERI_FINAL + 01 DAYS)
											, DATA_REFERENCIA
											, MES_REFERENCIA
											, ANO_REFERENCIA
											, ORGAO_EMISSOR
											, COD_FONTE
											, COD_PRODUTOR
											, RAMO_EMISSOR
											, COD_MODALIDADE
											, COD_CONGENERE
											, NUM_APOLICE
											, NUM_ENDOSSO
											, NUM_PARCELA
											, NUM_CERTIFICADO
											, NUM_TITULO
											, COD_SUBGRUPO
											, COD_OPERACAO
											, COD_PLANO
											, OCORR_HISTORICO
											, NUM_APOL_LIDER
											, ENDOS_LIDER
											, NUM_PARC_LIDER
											, NUM_SINISTRO
											, NUM_SINI_LIDER
											, NUM_ORDEM
											, COD_MOEDA
											, TIPO_CORRECAO
											, SIT_REGISTRO
											, IND_PREV_DEFINIT
											, IND_ANAL_RESUMO
											, COD_EMPRESA
											, PERI_RENOVACAO
											, PCT_AUMENTO
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'BI'
											AND COD_RELATORIO = 'BI0230B1'
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_COPIAS { get; set; }
        public string RELATORI_QUANTIDADE { get; set; }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }
        public string WSHOST_DTINIVIG { get; set; }
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
        public string VIND_NULL01 { get; set; }
        public string RELATORI_PERI_RENOVACAO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string RELATORI_PCT_AUMENTO { get; set; }
        public string VIND_NULL03 { get; set; }

        public static R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 Execute(R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_COPIAS = result[i++].Value?.ToString();
            dta.RELATORI_QUANTIDADE = result[i++].Value?.ToString();
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();
            dta.WSHOST_DTINIVIG = result[i++].Value?.ToString();
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
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.RELATORI_COD_EMPRESA) ? "-1" : "0";
            dta.RELATORI_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.RELATORI_PERI_RENOVACAO) ? "-1" : "0";
            dta.RELATORI_PCT_AUMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.RELATORI_PCT_AUMENTO) ? "-1" : "0";
            return dta;
        }

    }
}