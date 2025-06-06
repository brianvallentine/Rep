using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0268B
{
    public class R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1 : QueryBasis<R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(IND_IOF, 'S' )
            INTO :V0SUBG-IND-IOF
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND COD_SUBGRUPO = :WHOST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(IND_IOF
							, 'S' )
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND COD_SUBGRUPO = '{this.WHOST_CODSUBES}'";

            return query;
        }
        public string V0SUBG_IND_IOF { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1 Execute(R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1 r2210_00_MONTA_DETALHE_DB_SELECT_2_Query1)
        {
            var ths = r2210_00_MONTA_DETALHE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0SUBG_IND_IOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}