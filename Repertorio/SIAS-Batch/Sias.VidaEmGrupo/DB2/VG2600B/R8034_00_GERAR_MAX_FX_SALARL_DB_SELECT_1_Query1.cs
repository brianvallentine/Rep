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
    public class R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1 : QueryBasis<R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(FAIXA), 0) + 1
            INTO :FAIXASAL-FAIXA
            FROM SEGUROS.FAIXA_SALARIAL
            WHERE NUM_APOLICE = :FAIXASAL-NUM-APOLICE
            AND COD_SUBGRUPO = :FAIXASAL-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(FAIXA)
							, 0) + 1
											FROM SEGUROS.FAIXA_SALARIAL
											WHERE NUM_APOLICE = '{this.FAIXASAL_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.FAIXASAL_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string FAIXASAL_FAIXA { get; set; }
        public string FAIXASAL_COD_SUBGRUPO { get; set; }
        public string FAIXASAL_NUM_APOLICE { get; set; }

        public static R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1 Execute(R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1 r8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1)
        {
            var ths = r8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1();
            var i = 0;
            dta.FAIXASAL_FAIXA = result[i++].Value?.ToString();
            return dta;
        }

    }
}