using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 : QueryBasis<R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIS_COBER_PROPOST
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
            QTMDIT)
            SELECT
            NUM_CERTIFICADO,
            :PROPOVA-OCORR-HISTORICO1 OCORR_HISTORICO,
            :SISTEMAS-DATA-MOV-ABERTO DATA_INIVIGENCIA,
            '9998-12-31' DATA_TERVIGENCIA,
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
            :PLAVAVGA-VLPREMIOTOT VLPREMIO,
            :PLAVAVGA-PRMVG PRMVG,
            :PLAVAVGA-PRMAP PRMAP,
            :PLAVAVGA-QTTITCAP QTDE_TIT_CAPITALIZ,
            :PLAVAVGA-VLTITCAP VAL_TIT_CAPITALIZ,
            :PLAVAVGA-VLCUSTCAP VAL_CUSTO_CAPITALI,
            IMPSEGCDG,
            VLCUSTCDG,
            'VA0123B' COD_USUARIO,
            CURRENT TIMESTAMP,
            IMPSEGAUXF,
            VLCUSTAUXF,
            PRMDIT,
            QTMDIT
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) SELECT NUM_CERTIFICADO, {FieldThreatment(this.PROPOVA_OCORR_HISTORICO1)} OCORR_HISTORICO, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} DATA_INIVIGENCIA, '9998-12-31' DATA_TERVIGENCIA, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, {FieldThreatment(this.PLAVAVGA_VLPREMIOTOT)} VLPREMIO, {FieldThreatment(this.PLAVAVGA_PRMVG)} PRMVG, {FieldThreatment(this.PLAVAVGA_PRMAP)} PRMAP, {FieldThreatment(this.PLAVAVGA_QTTITCAP)} QTDE_TIT_CAPITALIZ, {FieldThreatment(this.PLAVAVGA_VLTITCAP)} VAL_TIT_CAPITALIZ, {FieldThreatment(this.PLAVAVGA_VLCUSTCAP)} VAL_CUSTO_CAPITALI, IMPSEGCDG, VLCUSTCDG, 'VA0123B' COD_USUARIO, CURRENT TIMESTAMP, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = {FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)} AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string PROPOVA_OCORR_HISTORICO1 { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string PLAVAVGA_PRMVG { get; set; }
        public string PLAVAVGA_PRMAP { get; set; }
        public string PLAVAVGA_QTTITCAP { get; set; }
        public string PLAVAVGA_VLTITCAP { get; set; }
        public string PLAVAVGA_VLCUSTCAP { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 r1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1)
        {
            var ths = r1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}