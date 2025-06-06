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
    public class R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 : QueryBasis<R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_MOVIMENTO_SAP
            ( NUM_OCORR_MOVTO ,
            DTH_MOVIMENTO ,
            NOM_PROGRAMA ,
            DTH_CADASTRAMENTO )
            VALUES
            (:GE099-NUM-OCORR-MOVTO ,
            :GE099-DTH-MOVIMENTO,
            :GE099-NOM-PROGRAMA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_MOVIMENTO_SAP ( NUM_OCORR_MOVTO , DTH_MOVIMENTO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE099_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE099_DTH_MOVIMENTO)}, {FieldThreatment(this.GE099_NOM_PROGRAMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE099_NUM_OCORR_MOVTO { get; set; }
        public string GE099_DTH_MOVIMENTO { get; set; }
        public string GE099_NOM_PROGRAMA { get; set; }

        public static void Execute(R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 r1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1)
        {
            var ths = r1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}