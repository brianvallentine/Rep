using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1 : QueryBasis<R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HISC-NRCERTIF,
            :WS-NUM-PARCELA-ATRD,
            :WHOST-NUM-PARCELA-F,
            682,
            :V0PROP-DTPROXVEN,
            0.00,
            0.00,
            0.00,
            0.00,
            :DESCON-PRMVG,
            :DESCON-PRMAP,
            0.00,
            ' ' )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HISC_NRCERTIF)}, {FieldThreatment(this.WS_NUM_PARCELA_ATRD)}, {FieldThreatment(this.WHOST_NUM_PARCELA_F)}, 682, {FieldThreatment(this.V0PROP_DTPROXVEN)}, 0.00, 0.00, 0.00, 0.00, {FieldThreatment(this.DESCON_PRMVG)}, {FieldThreatment(this.DESCON_PRMAP)}, 0.00, ' ' )";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string WS_NUM_PARCELA_ATRD { get; set; }
        public string WHOST_NUM_PARCELA_F { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string DESCON_PRMVG { get; set; }
        public string DESCON_PRMAP { get; set; }

        public static void Execute(R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1 r8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1)
        {
            var ths = r8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}