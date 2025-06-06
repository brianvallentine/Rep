using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1617B
{
    public class R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1 : QueryBasis<R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_BENEFICIARIO), 0)
            INTO :BENEFICI-NUM-BENEFICIARIO
            FROM SEGUROS.BENEFICIARIOS
            WHERE NUM_APOLICE = :BENEFICI-NUM-APOLICE
            AND COD_SUBGRUPO = :BENEFICI-COD-SUBGRUPO
            AND NUM_CERTIFICADO = :BENEFICI-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_BENEFICIARIO)
							, 0)
											FROM SEGUROS.BENEFICIARIOS
											WHERE NUM_APOLICE = '{this.BENEFICI_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.BENEFICI_COD_SUBGRUPO}'
											AND NUM_CERTIFICADO = '{this.BENEFICI_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string BENEFICI_NUM_BENEFICIARIO { get; set; }
        public string BENEFICI_NUM_CERTIFICADO { get; set; }
        public string BENEFICI_COD_SUBGRUPO { get; set; }
        public string BENEFICI_NUM_APOLICE { get; set; }

        public static R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1 Execute(R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1 r0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1)
        {
            var ths = r0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1();
            var i = 0;
            dta.BENEFICI_NUM_BENEFICIARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}