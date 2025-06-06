using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8007B
{
    public class R1150_00_SELECT_CNAB_DB_SELECT_1_Query1 : QueryBasis<R1150_00_SELECT_CNAB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NRSEQ),0)
            INTO :V0CNAB-NRSEQ
            FROM SEGUROS.V0CONTROCNAB
            WHERE NRCTACED = :V0CNAB-NRCTACED
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NRSEQ)
							,0)
											FROM SEGUROS.V0CONTROCNAB
											WHERE NRCTACED = '{this.V0CNAB_NRCTACED}'
											WITH UR";

            return query;
        }
        public string V0CNAB_NRSEQ { get; set; }
        public string V0CNAB_NRCTACED { get; set; }

        public static R1150_00_SELECT_CNAB_DB_SELECT_1_Query1 Execute(R1150_00_SELECT_CNAB_DB_SELECT_1_Query1 r1150_00_SELECT_CNAB_DB_SELECT_1_Query1)
        {
            var ths = r1150_00_SELECT_CNAB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1150_00_SELECT_CNAB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1150_00_SELECT_CNAB_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CNAB_NRSEQ = result[i++].Value?.ToString();
            return dta;
        }

    }
}