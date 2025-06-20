using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0138B
{
    public class R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1 : QueryBasis<R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            INTO :V0SUBG-NUM-APOLICE
            FROM SEGUROS.V0SUBGRUPO
            WHERE COD_CLIENTE = :V0PROP-CODCLIEN
            AND NUM_APOLICE = :V0HCTB-NUM-APOLICE
            AND COD_SUBGRUPO = :V0HCTB-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											FROM SEGUROS.V0SUBGRUPO
											WHERE COD_CLIENTE = '{this.V0PROP_CODCLIEN}'
											AND NUM_APOLICE = '{this.V0HCTB_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0HCTB_CODSUBES}'";

            return query;
        }
        public string V0SUBG_NUM_APOLICE { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0HCTB_CODSUBES { get; set; }

        public static R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1 Execute(R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1 r0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1)
        {
            var ths = r0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SUBG_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}