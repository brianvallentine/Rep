using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1 : QueryBasis<R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_HIST), 0)
            INTO :VG093-NUM-OCORR-HIST
            FROM SEGUROS.VG_REPRES_LEGAL
            WHERE COD_PESSOA = :VG093-COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_HIST)
							, 0)
											FROM SEGUROS.VG_REPRES_LEGAL
											WHERE COD_PESSOA = '{this.VG093_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string VG093_NUM_OCORR_HIST { get; set; }
        public string VG093_COD_PESSOA { get; set; }

        public static R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1 Execute(R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1 r8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1)
        {
            var ths = r8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG093_NUM_OCORR_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}