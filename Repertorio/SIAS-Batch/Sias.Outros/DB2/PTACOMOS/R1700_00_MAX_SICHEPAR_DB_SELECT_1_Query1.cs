using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMOS
{
    public class R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1 : QueryBasis<R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DATA_INIVIGENCIA)
            INTO :SICHEPAR-DATA-INIVIGENCIA
            FROM SEGUROS.SI_CHECKLIST_PARAM
            WHERE COD_PRODUTO = :SIMOVSIN-COD-PRODUTO
            AND COD_GRUPO_CAUSA = :SINISCAU-COD-GRUPO-CAUSA
            AND COD_SUBGRUPO_CAUSA = :SINISCAU-COD-SUBGRUPO-CAUSA
            AND COD_DOCUMENTO = 0
            AND NUM_PARTICIPANTE = 3
            AND COD_FASE = 2
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DATA_INIVIGENCIA)
											FROM SEGUROS.SI_CHECKLIST_PARAM
											WHERE COD_PRODUTO = '{this.SIMOVSIN_COD_PRODUTO}'
											AND COD_GRUPO_CAUSA = '{this.SINISCAU_COD_GRUPO_CAUSA}'
											AND COD_SUBGRUPO_CAUSA = '{this.SINISCAU_COD_SUBGRUPO_CAUSA}'
											AND COD_DOCUMENTO = 0
											AND NUM_PARTICIPANTE = 3
											AND COD_FASE = 2";

            return query;
        }
        public string SICHEPAR_DATA_INIVIGENCIA { get; set; }
        public string SINISCAU_COD_SUBGRUPO_CAUSA { get; set; }
        public string SINISCAU_COD_GRUPO_CAUSA { get; set; }
        public string SIMOVSIN_COD_PRODUTO { get; set; }

        public static R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1 Execute(R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1 r1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SICHEPAR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}