using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0142B
{
    public class R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 : QueryBasis<R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRM_TOTAL
            INTO :PARCEHIS-PRM-TOTAL
            FROM SEGUROS.PARCELA_HISTORICO
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            AND COD_OPERACAO = 101
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRM_TOTAL
											FROM SEGUROS.PARCELA_HISTORICO
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											AND COD_OPERACAO = 101
											WITH UR";

            return query;
        }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 Execute(R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 r0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1)
        {
            var ths = r0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEHIS_PRM_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}