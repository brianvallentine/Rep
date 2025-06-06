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
    public class R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 : QueryBasis<R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLR_DEBITO,
            DTVENCTO + 30 DAYS
            INTO :V1MVDB-VLR-DEBITO,
            :V1MVDB-DTCREDITO
            FROM SEGUROS.V1MOVDEBCC_CEF
            WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE
            AND NRENDOS = :V1MVDB-NRENDOS
            AND NRPARCEL = :V1MVDB-NRPARCEL
            AND COD_CONVENIO = :V1MVDB-COD-CONVENIO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VLR_DEBITO
							,
											DTVENCTO + 30 DAYS
											FROM SEGUROS.V1MOVDEBCC_CEF
											WHERE NUM_APOLICE = '{this.V1MVDB_NUM_APOLICE}'
											AND NRENDOS = '{this.V1MVDB_NRENDOS}'
											AND NRPARCEL = '{this.V1MVDB_NRPARCEL}'
											AND COD_CONVENIO = '{this.V1MVDB_COD_CONVENIO}'";

            return query;
        }
        public string V1MVDB_VLR_DEBITO { get; set; }
        public string V1MVDB_DTCREDITO { get; set; }
        public string V1MVDB_COD_CONVENIO { get; set; }
        public string V1MVDB_NUM_APOLICE { get; set; }
        public string V1MVDB_NRPARCEL { get; set; }
        public string V1MVDB_NRENDOS { get; set; }

        public static R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 Execute(R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 r3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1)
        {
            var ths = r3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MVDB_VLR_DEBITO = result[i++].Value?.ToString();
            dta.V1MVDB_DTCREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}