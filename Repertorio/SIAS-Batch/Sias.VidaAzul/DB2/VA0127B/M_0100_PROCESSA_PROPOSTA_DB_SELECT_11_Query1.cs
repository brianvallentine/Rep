using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0127B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CERTIFICADO,
            OCORR_HISTORICO,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            IMPSEGUR,
            QUANT_VIDAS,
            IMPSEGIND,
            COD_OPERACAO,
            OPCAO_COBERTURA,
            IMP_MORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIO,
            PRMVG,
            PRMAP,
            QTDE_TIT_CAPITALIZ,
            VAL_TIT_CAPITALIZ,
            VAL_CUSTO_CAPITALI,
            IMPSEGCDG,
            VLCUSTCDG,
            COD_USUARIO,
            TIMESTAMP,
            VALUE(IMPSEGAUXF,0),
            VALUE(VLCUSTAUXF,0),
            VALUE(PRMDIT,0),
            VALUE(QTMDIT,0),
            DATA_INIVIGENCIA + 1 DAY
            INTO
            :HISCOBPR-NUM-CERTIFICADO,
            :HISCOBPR-OCORR-HISTORICO,
            :HISCOBPR-DATA-INIVIGENCIA,
            :HISCOBPR-DATA-TERVIGENCIA,
            :HISCOBPR-IMPSEGUR,
            :HISCOBPR-QUANT-VIDAS,
            :HISCOBPR-IMPSEGIND,
            :HISCOBPR-COD-OPERACAO,
            :HISCOBPR-OPCAO-COBERTURA,
            :HISCOBPR-IMP-MORNATU,
            :HISCOBPR-IMPMORACID,
            :HISCOBPR-IMPINVPERM,
            :HISCOBPR-IMPAMDS,
            :HISCOBPR-IMPDH,
            :HISCOBPR-IMPDIT,
            :HISCOBPR-VLPREMIO,
            :HISCOBPR-PRMVG,
            :HISCOBPR-PRMAP,
            :HISCOBPR-QTDE-TIT-CAPITALIZ,
            :HISCOBPR-VAL-TIT-CAPITALIZ,
            :HISCOBPR-VAL-CUSTO-CAPITALI,
            :HISCOBPR-IMPSEGCDG,
            :HISCOBPR-VLCUSTCDG,
            :HISCOBPR-COD-USUARIO,
            :HISCOBPR-TIMESTAMP,
            :HISCOBPR-IMPSEGAUXF,
            :HISCOBPR-VLCUSTAUXF,
            :HISCOBPR-PRMDIT,
            :HISCOBPR-QTMDIT,
            :HISCOBPR-DTINIVIG-1DAY
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CERTIFICADO
							,
											OCORR_HISTORICO
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
							,
											IMPSEGUR
							,
											QUANT_VIDAS
							,
											IMPSEGIND
							,
											COD_OPERACAO
							,
											OPCAO_COBERTURA
							,
											IMP_MORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPAMDS
							,
											IMPDH
							,
											IMPDIT
							,
											VLPREMIO
							,
											PRMVG
							,
											PRMAP
							,
											QTDE_TIT_CAPITALIZ
							,
											VAL_TIT_CAPITALIZ
							,
											VAL_CUSTO_CAPITALI
							,
											IMPSEGCDG
							,
											VLCUSTCDG
							,
											COD_USUARIO
							,
											TIMESTAMP
							,
											VALUE(IMPSEGAUXF
							,0)
							,
											VALUE(VLCUSTAUXF
							,0)
							,
											VALUE(PRMDIT
							,0)
							,
											VALUE(QTMDIT
							,0)
							,
											DATA_INIVIGENCIA + 1 DAY
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND OCORR_HISTORICO = '{this.HISCOBPR_OCORR_HISTORICO}'";

            return query;
        }
        public string HISCOBPR_NUM_CERTIFICADO { get; set; }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_DATA_TERVIGENCIA { get; set; }
        public string HISCOBPR_IMPSEGUR { get; set; }
        public string HISCOBPR_QUANT_VIDAS { get; set; }
        public string HISCOBPR_IMPSEGIND { get; set; }
        public string HISCOBPR_COD_OPERACAO { get; set; }
        public string HISCOBPR_OPCAO_COBERTURA { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }
        public string HISCOBPR_IMPAMDS { get; set; }
        public string HISCOBPR_IMPDH { get; set; }
        public string HISCOBPR_IMPDIT { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string HISCOBPR_QTDE_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VAL_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VAL_CUSTO_CAPITALI { get; set; }
        public string HISCOBPR_IMPSEGCDG { get; set; }
        public string HISCOBPR_VLCUSTCDG { get; set; }
        public string HISCOBPR_COD_USUARIO { get; set; }
        public string HISCOBPR_TIMESTAMP { get; set; }
        public string HISCOBPR_IMPSEGAUXF { get; set; }
        public string HISCOBPR_VLCUSTAUXF { get; set; }
        public string HISCOBPR_PRMDIT { get; set; }
        public string HISCOBPR_QTMDIT { get; set; }
        public string HISCOBPR_DTINIVIG_1DAY { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1();
            var i = 0;
            dta.HISCOBPR_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCOBPR_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGUR = result[i++].Value?.ToString();
            dta.HISCOBPR_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGIND = result[i++].Value?.ToString();
            dta.HISCOBPR_COD_OPERACAO = result[i++].Value?.ToString();
            dta.HISCOBPR_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPINVPERM = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPAMDS = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDH = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMVG = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMAP = result[i++].Value?.ToString();
            dta.HISCOBPR_QTDE_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.HISCOBPR_VAL_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.HISCOBPR_VAL_CUSTO_CAPITALI = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGCDG = result[i++].Value?.ToString();
            dta.HISCOBPR_VLCUSTCDG = result[i++].Value?.ToString();
            dta.HISCOBPR_COD_USUARIO = result[i++].Value?.ToString();
            dta.HISCOBPR_TIMESTAMP = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.HISCOBPR_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_QTMDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_DTINIVIG_1DAY = result[i++].Value?.ToString();
            return dta;
        }

    }
}