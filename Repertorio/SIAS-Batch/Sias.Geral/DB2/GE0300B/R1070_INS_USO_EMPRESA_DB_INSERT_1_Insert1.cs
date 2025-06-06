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
    public class R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1 : QueryBasis<R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_FEBRABAN_USO_EMPRESA
            ( NUM_OCORR_MOVTO ,
            CHR_USO_EMPRESA ,
            DTH_CADASTRAMENTO )
            VALUES
            (:GE113-NUM-OCORR-MOVTO ,
            :GE113-CHR-USO-EMPRESA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_FEBRABAN_USO_EMPRESA ( NUM_OCORR_MOVTO , CHR_USO_EMPRESA , DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE113_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE113_CHR_USO_EMPRESA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE113_NUM_OCORR_MOVTO { get; set; }
        public string GE113_CHR_USO_EMPRESA { get; set; }

        public static void Execute(R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1 r1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1)
        {
            var ths = r1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}