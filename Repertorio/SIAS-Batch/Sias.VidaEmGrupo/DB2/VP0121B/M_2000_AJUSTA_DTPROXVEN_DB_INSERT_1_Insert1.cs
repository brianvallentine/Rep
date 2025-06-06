using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1 : QueryBasis<M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CONDTEC
            VALUES (0109700000024,
            :PROPVA-CODSUBES,
            0,
            0,
            0,
            :MTXAPMA,
            :MTXAPIP,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
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
				INSERT INTO SEGUROS.V0CONDTEC VALUES (0109700000024, {FieldThreatment(this.PROPVA_CODSUBES)}, 0, 0, 0, {FieldThreatment(this.MTXAPMA)}, {FieldThreatment(this.MTXAPIP)}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string PROPVA_CODSUBES { get; set; }
        public string MTXAPMA { get; set; }
        public string MTXAPIP { get; set; }

        public static void Execute(M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1 m_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1)
        {
            var ths = m_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}