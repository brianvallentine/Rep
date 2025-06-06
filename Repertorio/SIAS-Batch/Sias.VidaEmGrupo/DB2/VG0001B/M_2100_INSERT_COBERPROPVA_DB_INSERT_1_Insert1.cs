using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 : QueryBasis<M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIS_COBER_PROPOST
            (NUM_CERTIFICADO ,
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
            QTDE_TIT_CAPITALIZ,
            VAL_TIT_CAPITALIZ ,
            VAL_CUSTO_CAPITALI,
            IMPSEGCDG ,
            VLCUSTCDG ,
            COD_USUARIO ,
            TIMESTAMP ,
            IMPSEGAUXF ,
            VLCUSTAUXF ,
            PRMDIT ,
            QTMDIT )
            VALUES (:NUMEROUT-NUM-CERT-VGAP,
            1,
            :HISCOBPR-DATA-INIVIGENCIA,
            '9999-12-31' ,
            :HISCOBPR-IMPSEGUR,
            :VGSOLFAT-QUANT-VIDAS,
            :HISCOBPR-IMPSEGIND,
            101,
            ' ' ,
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
            'VG0001B' ,
            CURRENT TIMESTAMP,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT ) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)}, 1, {FieldThreatment(this.HISCOBPR_DATA_INIVIGENCIA)}, '9999-12-31' , {FieldThreatment(this.HISCOBPR_IMPSEGUR)}, {FieldThreatment(this.VGSOLFAT_QUANT_VIDAS)}, {FieldThreatment(this.HISCOBPR_IMPSEGIND)}, 101, ' ' , {FieldThreatment(this.HISCOBPR_IMP_MORNATU)}, {FieldThreatment(this.HISCOBPR_IMPMORACID)}, {FieldThreatment(this.HISCOBPR_IMPINVPERM)}, {FieldThreatment(this.HISCOBPR_IMPAMDS)}, {FieldThreatment(this.HISCOBPR_IMPDH)}, {FieldThreatment(this.HISCOBPR_IMPDIT)}, {FieldThreatment(this.HISCOBPR_VLPREMIO)}, {FieldThreatment(this.HISCOBPR_PRMVG)}, {FieldThreatment(this.HISCOBPR_PRMAP)}, {FieldThreatment(this.HISCOBPR_QTDE_TIT_CAPITALIZ)}, {FieldThreatment(this.HISCOBPR_VAL_TIT_CAPITALIZ)}, {FieldThreatment(this.HISCOBPR_VAL_CUSTO_CAPITALI)}, {FieldThreatment(this.HISCOBPR_IMPSEGCDG)}, {FieldThreatment(this.HISCOBPR_VLCUSTCDG)}, 'VG0001B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_IMPSEGUR { get; set; }
        public string VGSOLFAT_QUANT_VIDAS { get; set; }
        public string HISCOBPR_IMPSEGIND { get; set; }
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

        public static void Execute(M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1)
        {
            var ths = m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}