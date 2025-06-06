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
    public class R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1 : QueryBasis<R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :VGPROSIA-COD-PRODUTO
            FROM SEGUROS.VG_PRODUTO_SIAS
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND NUM_PERIODO_PAG = 1
            AND (COD_PRODUTO_EMP = 16
            OR :V0PRVG-ORIG-PRODU = 'GLOBAL'
            OR NUM_APOLICE IN (109300000959,
            109300001694,
            108210624684))
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.VG_PRODUTO_SIAS
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND NUM_PERIODO_PAG = 1
											AND (COD_PRODUTO_EMP = 16
											OR '{this.V0PRVG_ORIG_PRODU}' = 'GLOBAL'
											OR NUM_APOLICE IN (109300000959
							,
											109300001694
							,
											108210624684))
											WITH UR";

            return query;
        }
        public string VGPROSIA_COD_PRODUTO { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PRVG_ORIG_PRODU { get; set; }

        public static R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1 Execute(R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1 r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGPROSIA_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}