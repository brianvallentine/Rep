using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0805B
{
    public class M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1 : QueryBasis<M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FITACEF
            VALUES (:FITCEF-NSA,
            :FITCEF-DTRET,
            2,
            2,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FITACEF VALUES ({FieldThreatment(this.FITCEF_NSA)}, {FieldThreatment(this.FITCEF_DTRET)}, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string FITCEF_NSA { get; set; }
        public string FITCEF_DTRET { get; set; }

        public static void Execute(M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1 m_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1)
        {
            var ths = m_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}