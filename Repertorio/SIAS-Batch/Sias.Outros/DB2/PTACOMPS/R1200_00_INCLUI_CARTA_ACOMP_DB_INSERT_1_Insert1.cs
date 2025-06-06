using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMPS
{
    public class R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CARTA_ACOMP
            (NUM_CARTA,
            NUM_OCORR_CARTACO,
            COD_EVENTO,
            DATA_MOVTO_CARTACO,
            COD_USUARIO,
            TIMESTAMP)
            VALUES (:GECARACO-NUM-CARTA,
            :GECARACO-NUM-OCORR-CARTACO,
            :GECARACO-COD-EVENTO,
            :GECARACO-DATA-MOVTO-CARTACO,
            :GECARACO-COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CARTA_ACOMP (NUM_CARTA, NUM_OCORR_CARTACO, COD_EVENTO, DATA_MOVTO_CARTACO, COD_USUARIO, TIMESTAMP) VALUES ({FieldThreatment(this.GECARACO_NUM_CARTA)}, {FieldThreatment(this.GECARACO_NUM_OCORR_CARTACO)}, {FieldThreatment(this.GECARACO_COD_EVENTO)}, {FieldThreatment(this.GECARACO_DATA_MOVTO_CARTACO)}, {FieldThreatment(this.GECARACO_COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string GECARACO_NUM_CARTA { get; set; }
        public string GECARACO_NUM_OCORR_CARTACO { get; set; }
        public string GECARACO_COD_EVENTO { get; set; }
        public string GECARACO_DATA_MOVTO_CARTACO { get; set; }
        public string GECARACO_COD_USUARIO { get; set; }

        public static void Execute(R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1 r1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}