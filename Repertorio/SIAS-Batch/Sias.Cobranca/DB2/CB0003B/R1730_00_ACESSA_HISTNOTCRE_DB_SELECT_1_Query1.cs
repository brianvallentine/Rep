using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1 : QueryBasis<R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(MAX(OCORHIST),0)
            INTO :HNOTCRE-OCORHIST
            FROM SEGUROS.V1HISTNOTCRE
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOSC = :V1PARC-NRENDOS
            AND NRPARCELC = :V1PARC-NRPARCEL
            AND NRENDOSR = :V1NOTA-NRENDOSR
            AND NRPARCELR = :V1NOTA-NRPARCELR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(MAX(OCORHIST)
							,0)
											FROM SEGUROS.V1HISTNOTCRE
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOSC = '{this.V1PARC_NRENDOS}'
											AND NRPARCELC = '{this.V1PARC_NRPARCEL}'
											AND NRENDOSR = '{this.V1NOTA_NRENDOSR}'
											AND NRPARCELR = '{this.V1NOTA_NRPARCELR}'
											WITH UR";

            return query;
        }
        public string HNOTCRE_OCORHIST { get; set; }
        public string V1NOTA_NRPARCELR { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1NOTA_NRENDOSR { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1 Execute(R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1 r1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1)
        {
            var ths = r1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.HNOTCRE_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}