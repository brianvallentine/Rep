using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R8010_00_VER_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R8010_00_VER_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODPRODU
            INTO :V0PROP-CODPRODU
            FROM SEGUROS.V0PROPOSTAVA A,
            SEGUROS.V0PRODUTOSVG B
            WHERE A.NRCERTIF = :V0HCTA-NRCERTIF
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.CODSUBES = A.CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODPRODU
											FROM SEGUROS.V0PROPOSTAVA A
							,
											SEGUROS.V0PRODUTOSVG B
											WHERE A.NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.CODSUBES = A.CODSUBES
											WITH UR";

            return query;
        }
        public string V0PROP_CODPRODU { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static R8010_00_VER_PRODUTO_DB_SELECT_1_Query1 Execute(R8010_00_VER_PRODUTO_DB_SELECT_1_Query1 r8010_00_VER_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r8010_00_VER_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8010_00_VER_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8010_00_VER_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}