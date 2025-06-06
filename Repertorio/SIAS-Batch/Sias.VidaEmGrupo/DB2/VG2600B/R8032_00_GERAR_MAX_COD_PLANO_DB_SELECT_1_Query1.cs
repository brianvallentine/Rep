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
    public class R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1 : QueryBasis<R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(COD_PLANO), 0) + 1
            INTO :PLANOVGA-COD-PLANO
            FROM SEGUROS.PLANOS_VGAP
            WHERE NUM_APOLICE = :PLANOVGA-NUM-APOLICE
            AND COD_SUBGRUPO = :PLANOVGA-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(COD_PLANO)
							, 0) + 1
											FROM SEGUROS.PLANOS_VGAP
											WHERE NUM_APOLICE = '{this.PLANOVGA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PLANOVGA_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string PLANOVGA_COD_PLANO { get; set; }
        public string PLANOVGA_COD_SUBGRUPO { get; set; }
        public string PLANOVGA_NUM_APOLICE { get; set; }

        public static R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1 Execute(R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1 r8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1)
        {
            var ths = r8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOVGA_COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}