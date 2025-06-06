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
    public class M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 : QueryBasis<M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.ERROS_PROP_VIDAZUL
            VALUES (:PROPVA-NRCERTIF,
            :ERRPROVI-COD-ERRO)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, {FieldThreatment(this.ERRPROVI_COD_ERRO)})";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string ERRPROVI_COD_ERRO { get; set; }

        public static void Execute(M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 m_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1)
        {
            var ths = m_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}