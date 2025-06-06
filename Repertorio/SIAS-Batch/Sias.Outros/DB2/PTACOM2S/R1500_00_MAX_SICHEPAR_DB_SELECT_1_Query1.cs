using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOM2S
{
    public class R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1 : QueryBasis<R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA,
            COD_FASE
            INTO :SICHEPAR-DATA-INIVIGENCIA
            ,:SICHEPAR-COD-FASE
            FROM SEGUROS.SI_CHECKLIST_PARAM
            WHERE COD_PRODUTO = :SIDOCACO-COD-PRODUTO
            AND COD_GRUPO_CAUSA = :SIDOCACO-COD-GRUPO-CAUSA
            AND COD_SUBGRUPO_CAUSA = :SIDOCACO-COD-SUBGRUPO-CAUSA
            AND COD_DOCUMENTO = :SIDOCACO-COD-DOCUMENTO
            AND NUM_PARTICIPANTE = 3
            AND COD_FASE IN (2, 3)
            FETCH FIRST 01 ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
							,
											COD_FASE
											FROM SEGUROS.SI_CHECKLIST_PARAM
											WHERE COD_PRODUTO = '{this.SIDOCACO_COD_PRODUTO}'
											AND COD_GRUPO_CAUSA = '{this.SIDOCACO_COD_GRUPO_CAUSA}'
											AND COD_SUBGRUPO_CAUSA = '{this.SIDOCACO_COD_SUBGRUPO_CAUSA}'
											AND COD_DOCUMENTO = '{this.SIDOCACO_COD_DOCUMENTO}'
											AND NUM_PARTICIPANTE = 3
											AND COD_FASE IN (2
							, 3)
											FETCH FIRST 01 ROWS ONLY";

            return query;
        }
        public string SICHEPAR_DATA_INIVIGENCIA { get; set; }
        public string SICHEPAR_COD_FASE { get; set; }
        public string SIDOCACO_COD_SUBGRUPO_CAUSA { get; set; }
        public string SIDOCACO_COD_GRUPO_CAUSA { get; set; }
        public string SIDOCACO_COD_DOCUMENTO { get; set; }
        public string SIDOCACO_COD_PRODUTO { get; set; }

        public static R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1 Execute(R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1 r1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SICHEPAR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SICHEPAR_COD_FASE = result[i++].Value?.ToString();
            return dta;
        }

    }
}