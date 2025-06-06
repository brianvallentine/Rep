using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1 : QueryBasis<R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_IOCC_RAMO
            INTO :RAMOCOMP-PCT-IOCC-RAMO
            FROM SEGUROS.RAMO_COMPLEMENTAR
            WHERE RAMO_EMISSOR = :V1BILC-RAMOFR
            AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO
            AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_IOCC_RAMO
											FROM SEGUROS.RAMO_COMPLEMENTAR
											WHERE RAMO_EMISSOR = '{this.V1BILC_RAMOFR}'
											AND DATA_INIVIGENCIA <= '{this.V0BILH_DTQITBCO}'
											AND DATA_TERVIGENCIA >= '{this.V0BILH_DTQITBCO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V1BILC_RAMOFR { get; set; }

        public static R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1 Execute(R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1 r0500_00_TRATA_APOLICE_DB_SELECT_3_Query1)
        {
            var ths = r0500_00_TRATA_APOLICE_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1();
            var i = 0;
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}