using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_EMPRESA, 0),
            NRPROPOS,
            FONTE,
            DTINIVIG,
            DTTERVIG,
            TIPO_ENDOSSO,
            CODPRODU
            INTO :V0ENDOS-COD-EMPRESA,
            :V0ENDOS-NRPROPOS,
            :V0ENDOS-FONTE,
            :V0ENDOS-DTINIVIG,
            :V0ENDOS-DTTERVIG,
            :V0ENDOS-TIPO-ENDOSSO,
            :V0ENDOS-COD-PRODUTO
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V0ENDOS-NUM-APOLICE
            AND NRENDOS = :V0ENDOS-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_EMPRESA
							, 0)
							,
											NRPROPOS
							,
											FONTE
							,
											DTINIVIG
							,
											DTTERVIG
							,
											TIPO_ENDOSSO
							,
											CODPRODU
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V0ENDOS_NUM_APOLICE}'
											AND NRENDOS = '{this.V0ENDOS_NRENDOS}'";

            return query;
        }
        public string V0ENDOS_COD_EMPRESA { get; set; }
        public string V0ENDOS_NRPROPOS { get; set; }
        public string V0ENDOS_FONTE { get; set; }
        public string V0ENDOS_DTINIVIG { get; set; }
        public string V0ENDOS_DTTERVIG { get; set; }
        public string V0ENDOS_TIPO_ENDOSSO { get; set; }
        public string V0ENDOS_COD_PRODUTO { get; set; }
        public string V0ENDOS_NUM_APOLICE { get; set; }
        public string V0ENDOS_NRENDOS { get; set; }

        public static R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1 r0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDOS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V0ENDOS_NRPROPOS = result[i++].Value?.ToString();
            dta.V0ENDOS_FONTE = result[i++].Value?.ToString();
            dta.V0ENDOS_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDOS_DTTERVIG = result[i++].Value?.ToString();
            dta.V0ENDOS_TIPO_ENDOSSO = result[i++].Value?.ToString();
            dta.V0ENDOS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}