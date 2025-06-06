using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R1700_10_LOOP_DB_SELECT_7_Query1 : QueryBasis<R1700_10_LOOP_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CERTIFICADO ,
            OCORR_HISTORICO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            IMPSEGUR ,
            QUANT_VIDAS ,
            IMPSEGIND ,
            COD_OPERACAO ,
            OPCAO_COBERTURA ,
            IMP_MORNATU ,
            IMPMORACID ,
            IMPINVPERM ,
            IMPAMDS ,
            IMPDH ,
            IMPDIT ,
            VLPREMIO ,
            PRMVG ,
            PRMAP ,
            QTDE_TIT_CAPITALIZ ,
            VAL_TIT_CAPITALIZ ,
            VAL_CUSTO_CAPITALI ,
            IMPSEGCDG ,
            VLCUSTCDG ,
            COD_USUARIO ,
            IMPSEGAUXF ,
            VLCUSTAUXF ,
            PRMDIT ,
            QTMDIT
            INTO
            :HISCOBPR-NUM-CERTIFICADO ,
            :HISCOBPR-OCORR-HISTORICO ,
            :HISCOBPR-DATA-INIVIGENCIA ,
            :HISCOBPR-DATA-TERVIGENCIA ,
            :HISCOBPR-IMPSEGUR ,
            :HISCOBPR-QUANT-VIDAS ,
            :HISCOBPR-IMPSEGIND ,
            :HISCOBPR-COD-OPERACAO ,
            :HISCOBPR-OPCAO-COBERTURA ,
            :HISCOBPR-IMP-MORNATU ,
            :HISCOBPR-IMPMORACID ,
            :HISCOBPR-IMPINVPERM ,
            :HISCOBPR-IMPAMDS ,
            :HISCOBPR-IMPDH ,
            :HISCOBPR-IMPDIT ,
            :HISCOBPR-VLPREMIO ,
            :HISCOBPR-PRMVG ,
            :HISCOBPR-PRMAP ,
            :HISCOBPR-QTDE-TIT-CAPITALIZ ,
            :HISCOBPR-VAL-TIT-CAPITALIZ ,
            :HISCOBPR-VAL-CUSTO-CAPITALI ,
            :HISCOBPR-IMPSEGCDG ,
            :HISCOBPR-VLCUSTCDG ,
            :HISCOBPR-COD-USUARIO ,
            :HISCOBPR-IMPSEGAUXF
            :HISCOBPR-IMPSEGAUXF-I ,
            :HISCOBPR-VLCUSTAUXF
            :HISCOBPR-VLCUSTAUXF-I ,
            :HISCOBPR-PRMDIT
            :HISCOBPR-PRMDIT-I ,
            :HISCOBPR-QTMDIT
            :HISCOBPR-QTMDIT-I
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND OCORR_HISTORICO = :V0PROP-OCORHIST
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
											IMPSEGAUXF 
							,
											VLCUSTAUXF 
							,
											PRMDIT 
							,
											QTMDIT
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND OCORR_HISTORICO = '{this.V0PROP_OCORHIST}'";

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
        public string HISCOBPR_IMPSEGAUXF { get; set; }
        public string HISCOBPR_IMPSEGAUXF_I { get; set; }
        public string HISCOBPR_VLCUSTAUXF { get; set; }
        public string HISCOBPR_VLCUSTAUXF_I { get; set; }
        public string HISCOBPR_PRMDIT { get; set; }
        public string HISCOBPR_PRMDIT_I { get; set; }
        public string HISCOBPR_QTMDIT { get; set; }
        public string HISCOBPR_QTMDIT_I { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static R1700_10_LOOP_DB_SELECT_7_Query1 Execute(R1700_10_LOOP_DB_SELECT_7_Query1 r1700_10_LOOP_DB_SELECT_7_Query1)
        {
            var ths = r1700_10_LOOP_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_10_LOOP_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_10_LOOP_DB_SELECT_7_Query1();
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
            dta.HISCOBPR_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.HISCOBPR_IMPSEGAUXF) ? "-1" : "0";
            dta.HISCOBPR_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.HISCOBPR_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.HISCOBPR_VLCUSTAUXF) ? "-1" : "0";
            dta.HISCOBPR_PRMDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMDIT_I = string.IsNullOrWhiteSpace(dta.HISCOBPR_PRMDIT) ? "-1" : "0";
            dta.HISCOBPR_QTMDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_QTMDIT_I = string.IsNullOrWhiteSpace(dta.HISCOBPR_QTMDIT) ? "-1" : "0";
            return dta;
        }

    }
}