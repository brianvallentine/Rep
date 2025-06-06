using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0306B
{
    public class R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1 : QueryBasis<R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_CHEQUE_SAP
            ( NUM_OCORR_MOVTO ,
            NUM_CHEQUE_INTERNO,
            NSAS ,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO )
            VALUES
            (:GE097-NUM-OCORR-MOVTO,
            :GE097-NUM-CHEQUE-INTERNO,
            :GE097-NSAS,
            :GE097-IDE-SISTEMA,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CHEQUE_SAP ( NUM_OCORR_MOVTO , NUM_CHEQUE_INTERNO, NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE097_NUM_OCORR_MOVTO)}, {FieldThreatment(this.GE097_NUM_CHEQUE_INTERNO)}, {FieldThreatment(this.GE097_NSAS)}, {FieldThreatment(this.GE097_IDE_SISTEMA)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string GE097_NUM_OCORR_MOVTO { get; set; }
        public string GE097_NUM_CHEQUE_INTERNO { get; set; }
        public string GE097_NSAS { get; set; }
        public string GE097_IDE_SISTEMA { get; set; }

        public static void Execute(R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1 r1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1)
        {
            var ths = r1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}