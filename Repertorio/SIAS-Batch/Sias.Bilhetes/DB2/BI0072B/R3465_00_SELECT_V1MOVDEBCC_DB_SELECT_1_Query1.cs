using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 : QueryBasis<R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :WS-QTDBIL
            FROM SEGUROS.V1MOVDEBCC_CEF
            WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE
            AND NRENDOS <= :V1MVDB-NRENDOS
            AND COD_CONVENIO = :V1MVDB-COD-CONVENIO
            AND SIT_COBRANCA = '3'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.V1MOVDEBCC_CEF
											WHERE NUM_APOLICE = '{this.V1MVDB_NUM_APOLICE}'
											AND NRENDOS <= '{this.V1MVDB_NRENDOS}'
											AND COD_CONVENIO = '{this.V1MVDB_COD_CONVENIO}'
											AND SIT_COBRANCA = '3'
											WITH UR";

            return query;
        }
        public string WS_QTDBIL { get; set; }
        public string V1MVDB_COD_CONVENIO { get; set; }
        public string V1MVDB_NUM_APOLICE { get; set; }
        public string V1MVDB_NRENDOS { get; set; }

        public static R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 Execute(R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 r3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1)
        {
            var ths = r3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QTDBIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}