using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1 : QueryBasis<R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            B.NUM_CERTIFICADO
            ,B.OCORR_HISTORICO
            ,B.DATA_INIVIGENCIA
            ,B.DATA_TERVIGENCIA
            ,B.IMPSEGUR
            ,B.QUANT_VIDAS
            ,B.IMPSEGIND
            ,B.COD_OPERACAO
            ,B.OPCAO_COBERTURA
            ,B.IMP_MORNATU
            ,B.IMPMORACID
            ,B.IMPINVPERM
            ,B.IMPAMDS
            ,B.IMPDH
            ,B.IMPDIT
            ,B.VLPREMIO
            ,B.PRMVG
            ,B.PRMAP
            ,B.QTDE_TIT_CAPITALIZ
            ,B.VAL_TIT_CAPITALIZ
            ,B.VAL_CUSTO_CAPITALI
            ,B.IMPSEGCDG
            ,B.VLCUSTCDG
            ,B.COD_USUARIO
            ,B.TIMESTAMP
            ,B.IMPSEGAUXF
            ,B.VLCUSTAUXF
            ,B.PRMDIT
            ,B.QTMDIT
            INTO
            :WHOST-NUM-CERTIFICADO
            ,:WHOST-OCORR-HISTORICO
            ,:WHOST-DATA-INIVIGENCIA
            ,:WHOST-DATA-TERVIGENCIA
            ,:WHOST-IMPSEGUR
            ,:WHOST-QUANT-VIDAS
            ,:WHOST-IMPSEGIND
            ,:WHOST-COD-OPERACAO
            ,:WHOST-OPCAO-COBERTURA
            ,:WHOST-IMP-MORNATU
            ,:WHOST-IMPMORACID
            ,:WHOST-IMPINVPERM
            ,:WHOST-IMPAMDS
            ,:WHOST-IMPDH
            ,:WHOST-IMPDIT
            ,:WHOST-VLPREMIO
            ,:WHOST-PRMVG
            ,:WHOST-PRMAP
            ,:WHOST-QTDE-TIT-CAPITALIZ
            ,:WHOST-VAL-TIT-CAPITALIZ
            ,:WHOST-VAL-CUSTO-CAPITALI
            ,:WHOST-IMPSEGCDG
            ,:WHOST-VLCUSTCDG
            ,:WHOST-COD-USUARIO
            ,:WHOST-TIMESTAMP
            ,:WHOST-IMPSEGAUXF
            ,:WHOST-VLCUSTAUXF
            ,:WHOST-PRMDIT
            ,:WHOST-QTMDIT
            FROM SEGUROS.RELATORIOS A
            , SEGUROS.HIS_COBER_PROPOST B
            WHERE A.NUM_SINISTRO = :DCLPESSOA-FISICA.CPF
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND B.DATA_TERVIGENCIA = '9999-12-31'
            FETCH FIRST ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											B.NUM_CERTIFICADO
											,B.OCORR_HISTORICO
											,B.DATA_INIVIGENCIA
											,B.DATA_TERVIGENCIA
											,B.IMPSEGUR
											,B.QUANT_VIDAS
											,B.IMPSEGIND
											,B.COD_OPERACAO
											,B.OPCAO_COBERTURA
											,B.IMP_MORNATU
											,B.IMPMORACID
											,B.IMPINVPERM
											,B.IMPAMDS
											,B.IMPDH
											,B.IMPDIT
											,B.VLPREMIO
											,B.PRMVG
											,B.PRMAP
											,B.QTDE_TIT_CAPITALIZ
											,B.VAL_TIT_CAPITALIZ
											,B.VAL_CUSTO_CAPITALI
											,B.IMPSEGCDG
											,B.VLCUSTCDG
											,B.COD_USUARIO
											,B.TIMESTAMP
											,B.IMPSEGAUXF
											,B.VLCUSTAUXF
											,B.PRMDIT
											,B.QTMDIT
											FROM SEGUROS.RELATORIOS A
											, SEGUROS.HIS_COBER_PROPOST B
											WHERE A.NUM_SINISTRO = '{this.CPF}'
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND B.DATA_TERVIGENCIA = '9999-12-31'
											FETCH FIRST ROWS ONLY";

            return query;
        }
        public string WHOST_NUM_CERTIFICADO { get; set; }
        public string WHOST_OCORR_HISTORICO { get; set; }
        public string WHOST_DATA_INIVIGENCIA { get; set; }
        public string WHOST_DATA_TERVIGENCIA { get; set; }
        public string WHOST_IMPSEGUR { get; set; }
        public string WHOST_QUANT_VIDAS { get; set; }
        public string WHOST_IMPSEGIND { get; set; }
        public string WHOST_COD_OPERACAO { get; set; }
        public string WHOST_OPCAO_COBERTURA { get; set; }
        public string WHOST_IMP_MORNATU { get; set; }
        public string WHOST_IMPMORACID { get; set; }
        public string WHOST_IMPINVPERM { get; set; }
        public string WHOST_IMPAMDS { get; set; }
        public string WHOST_IMPDH { get; set; }
        public string WHOST_IMPDIT { get; set; }
        public string WHOST_VLPREMIO { get; set; }
        public string WHOST_PRMVG { get; set; }
        public string WHOST_PRMAP { get; set; }
        public string WHOST_QTDE_TIT_CAPITALIZ { get; set; }
        public string WHOST_VAL_TIT_CAPITALIZ { get; set; }
        public string WHOST_VAL_CUSTO_CAPITALI { get; set; }
        public string WHOST_IMPSEGCDG { get; set; }
        public string WHOST_VLCUSTCDG { get; set; }
        public string WHOST_COD_USUARIO { get; set; }
        public string WHOST_TIMESTAMP { get; set; }
        public string WHOST_IMPSEGAUXF { get; set; }
        public string WHOST_VLCUSTAUXF { get; set; }
        public string WHOST_PRMDIT { get; set; }
        public string WHOST_QTMDIT { get; set; }
        public string CPF { get; set; }

        public static R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1 Execute(R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1 r3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1)
        {
            var ths = r3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.WHOST_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.WHOST_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WHOST_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WHOST_IMPSEGUR = result[i++].Value?.ToString();
            dta.WHOST_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.WHOST_IMPSEGIND = result[i++].Value?.ToString();
            dta.WHOST_COD_OPERACAO = result[i++].Value?.ToString();
            dta.WHOST_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.WHOST_IMP_MORNATU = result[i++].Value?.ToString();
            dta.WHOST_IMPMORACID = result[i++].Value?.ToString();
            dta.WHOST_IMPINVPERM = result[i++].Value?.ToString();
            dta.WHOST_IMPAMDS = result[i++].Value?.ToString();
            dta.WHOST_IMPDH = result[i++].Value?.ToString();
            dta.WHOST_IMPDIT = result[i++].Value?.ToString();
            dta.WHOST_VLPREMIO = result[i++].Value?.ToString();
            dta.WHOST_PRMVG = result[i++].Value?.ToString();
            dta.WHOST_PRMAP = result[i++].Value?.ToString();
            dta.WHOST_QTDE_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.WHOST_VAL_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.WHOST_VAL_CUSTO_CAPITALI = result[i++].Value?.ToString();
            dta.WHOST_IMPSEGCDG = result[i++].Value?.ToString();
            dta.WHOST_VLCUSTCDG = result[i++].Value?.ToString();
            dta.WHOST_COD_USUARIO = result[i++].Value?.ToString();
            dta.WHOST_TIMESTAMP = result[i++].Value?.ToString();
            dta.WHOST_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.WHOST_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.WHOST_PRMDIT = result[i++].Value?.ToString();
            dta.WHOST_QTMDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}