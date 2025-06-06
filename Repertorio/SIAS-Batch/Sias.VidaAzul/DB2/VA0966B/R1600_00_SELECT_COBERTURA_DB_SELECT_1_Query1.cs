using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0966B
{
    public class R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            OPC_COBERTURA
            INTO
            :BILHETE-OPC-COBERTURA
            FROM
            SEGUROS.BILHETE
            WHERE
            NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											OPC_COBERTURA
											FROM
											SEGUROS.BILHETE
											WHERE
											NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'";

            return query;
        }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1 r1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}