using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1 : QueryBasis<R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE,
            OCORR_ENDERECO
            INTO :V0SUBG-COD-CLIENTE,
            :V0SUBG-OCOREND
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND COD_SUBGRUPO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							,
											OCORR_ENDERECO
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND COD_SUBGRUPO = 0
											WITH UR";

            return query;
        }
        public string V0SUBG_COD_CLIENTE { get; set; }
        public string V0SUBG_OCOREND { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1 Execute(R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1 r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1)
        {
            var ths = r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SUBG_COD_CLIENTE = result[i++].Value?.ToString();
            dta.V0SUBG_OCOREND = result[i++].Value?.ToString();
            return dta;
        }

    }
}