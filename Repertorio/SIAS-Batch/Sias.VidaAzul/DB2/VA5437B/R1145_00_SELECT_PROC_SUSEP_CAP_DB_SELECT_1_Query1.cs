using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1 : QueryBasis<R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_PROCESSO_SUSEP, '********************' )
            INTO :FCPROSUS-COD-PROCESSO-SUSEP
            FROM FDRCAP.FC_PROCESSO_SUSEP
            WHERE NUM_PLANO = :FCPROSUS-NUM-PLANO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_PROCESSO_SUSEP
							, '********************' )
											FROM FDRCAP.FC_PROCESSO_SUSEP
											WHERE NUM_PLANO = '{this.FCPROSUS_NUM_PLANO}'
											WITH UR";

            return query;
        }
        public string FCPROSUS_COD_PROCESSO_SUSEP { get; set; }
        public string FCPROSUS_NUM_PLANO { get; set; }

        public static R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1 Execute(R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1 r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1)
        {
            var ths = r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.FCPROSUS_COD_PROCESSO_SUSEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}