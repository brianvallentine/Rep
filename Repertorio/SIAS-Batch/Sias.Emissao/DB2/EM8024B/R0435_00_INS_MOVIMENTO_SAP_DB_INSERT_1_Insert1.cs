using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 : QueryBasis<R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.GE_MOVIMENTO_SAP
            ( NUM_OCORR_MOVTO
            , DTH_MOVIMENTO
            , NOM_PROGRAMA
            , DTH_CADASTRAMENTO
            )
            VALUES
            ( :GE099-NUM-OCORR-MOVTO
            , :GE099-DTH-MOVIMENTO
            , :GE099-NOM-PROGRAMA
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_MOVIMENTO_SAP ( NUM_OCORR_MOVTO , DTH_MOVIMENTO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.GE099_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE099_DTH_MOVIMENTO)} , {FieldThreatment(this.GE099_NOM_PROGRAMA)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string GE099_NUM_OCORR_MOVTO { get; set; }
        public string GE099_DTH_MOVIMENTO { get; set; }
        public string GE099_NOM_PROGRAMA { get; set; }

        public static void Execute(R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 r0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1)
        {
            var ths = r0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}