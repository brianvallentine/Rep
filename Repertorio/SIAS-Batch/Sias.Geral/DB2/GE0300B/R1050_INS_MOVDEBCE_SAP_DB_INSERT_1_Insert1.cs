using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0300B
{
    public class R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1 : QueryBasis<R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_MOVDEBCE_SAP
            ( NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            COD_CONVENIO ,
            NSAS ,
            NUM_OCORR_MOVTO ,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO )
            VALUES
            (:GE094-NUM-APOLICE ,
            :GE094-NUM-ENDOSSO ,
            :GE094-NUM-PARCELA ,
            :GE094-COD-CONVENIO ,
            :GE094-NSAS ,
            :GE094-NUM-OCORR-MOVTO ,
            :GE094-IDE-SISTEMA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_MOVDEBCE_SAP ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , COD_CONVENIO , NSAS , NUM_OCORR_MOVTO , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE094_NUM_APOLICE)} , {FieldThreatment(this.GE094_NUM_ENDOSSO)} , {FieldThreatment(this.GE094_NUM_PARCELA)} , {FieldThreatment(this.GE094_COD_CONVENIO)} , {FieldThreatment(this.GE094_NSAS)} , {FieldThreatment(this.GE094_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE094_IDE_SISTEMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE094_NUM_APOLICE { get; set; }
        public string GE094_NUM_ENDOSSO { get; set; }
        public string GE094_NUM_PARCELA { get; set; }
        public string GE094_COD_CONVENIO { get; set; }
        public string GE094_NSAS { get; set; }
        public string GE094_NUM_OCORR_MOVTO { get; set; }
        public string GE094_IDE_SISTEMA { get; set; }

        public static void Execute(R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1 r1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1)
        {
            var ths = r1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}