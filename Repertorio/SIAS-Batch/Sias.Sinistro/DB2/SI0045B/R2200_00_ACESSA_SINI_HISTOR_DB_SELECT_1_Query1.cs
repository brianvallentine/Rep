using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1 : QueryBasis<R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA,
            TIPO_REGISTRO,
            NUM_APOL_SINISTRO,
            OCORR_HISTORICO,
            COD_OPERACAO,
            DATA_MOVIMENTO,
            HORA_OPERACAO,
            NOME_FAVORECIDO,
            VAL_OPERACAO,
            DATA_LIM_CORRECAO,
            TIPO_FAVORECIDO,
            DATA_NEGOCIADA,
            FONTE_PAGAMENTO,
            COD_PREST_SERVICO,
            COD_SERVICO,
            ORDEM_PAGAMENTO,
            NUM_RECIBO,
            NUM_MOV_SINISTRO,
            COD_USUARIO,
            SIT_CONTABIL,
            SIT_REGISTRO,
            NUM_APOLICE,
            COD_PRODUTO,
            VALUE(NOM_PROGRAMA, ' ' ),
            MONTH(DATA_MOVIMENTO)
            INTO :SINISHIS-COD-EMPRESA,
            :SINISHIS-TIPO-REGISTRO,
            :SINISHIS-NUM-APOL-SINISTRO,
            :SINISHIS-OCORR-HISTORICO,
            :SINISHIS-COD-OPERACAO,
            :SINISHIS-DATA-MOVIMENTO,
            :SINISHIS-HORA-OPERACAO,
            :SINISHIS-NOME-FAVORECIDO,
            :SINISHIS-VAL-OPERACAO,
            :SINISHIS-DATA-LIM-CORRECAO,
            :SINISHIS-TIPO-FAVORECIDO,
            :SINISHIS-DATA-NEGOCIADA,
            :SINISHIS-FONTE-PAGAMENTO,
            :SINISHIS-COD-PREST-SERVICO,
            :SINISHIS-COD-SERVICO,
            :SINISHIS-ORDEM-PAGAMENTO,
            :SINISHIS-NUM-RECIBO,
            :SINISHIS-NUM-MOV-SINISTRO,
            :SINISHIS-COD-USUARIO,
            :SINISHIS-SIT-CONTABIL,
            :SINISHIS-SIT-REGISTRO,
            :SINISHIS-NUM-APOLICE,
            :SINISHIS-COD-PRODUTO,
            :SINISHIS-NOM-PROGRAMA,
            :HOST-MES-OPERACAO-AVISO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND COD_OPERACAO = 101
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA
							,
											TIPO_REGISTRO
							,
											NUM_APOL_SINISTRO
							,
											OCORR_HISTORICO
							,
											COD_OPERACAO
							,
											DATA_MOVIMENTO
							,
											HORA_OPERACAO
							,
											NOME_FAVORECIDO
							,
											VAL_OPERACAO
							,
											DATA_LIM_CORRECAO
							,
											TIPO_FAVORECIDO
							,
											DATA_NEGOCIADA
							,
											FONTE_PAGAMENTO
							,
											COD_PREST_SERVICO
							,
											COD_SERVICO
							,
											ORDEM_PAGAMENTO
							,
											NUM_RECIBO
							,
											NUM_MOV_SINISTRO
							,
											COD_USUARIO
							,
											SIT_CONTABIL
							,
											SIT_REGISTRO
							,
											NUM_APOLICE
							,
											COD_PRODUTO
							,
											VALUE(NOM_PROGRAMA
							, ' ' )
							,
											MONTH(DATA_MOVIMENTO)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = 101
											WITH UR";

            return query;
        }
        public string SINISHIS_COD_EMPRESA { get; set; }
        public string SINISHIS_TIPO_REGISTRO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_HORA_OPERACAO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_DATA_LIM_CORRECAO { get; set; }
        public string SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string SINISHIS_DATA_NEGOCIADA { get; set; }
        public string SINISHIS_FONTE_PAGAMENTO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_COD_SERVICO { get; set; }
        public string SINISHIS_ORDEM_PAGAMENTO { get; set; }
        public string SINISHIS_NUM_RECIBO { get; set; }
        public string SINISHIS_NUM_MOV_SINISTRO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_NOM_PROGRAMA { get; set; }
        public string HOST_MES_OPERACAO_AVISO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1 Execute(R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1 r2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_HORA_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_LIM_CORRECAO = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_NEGOCIADA = result[i++].Value?.ToString();
            dta.SINISHIS_FONTE_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_ORDEM_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_RECIBO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_MOV_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.HOST_MES_OPERACAO_AVISO = result[i++].Value?.ToString();
            return dta;
        }

    }
}