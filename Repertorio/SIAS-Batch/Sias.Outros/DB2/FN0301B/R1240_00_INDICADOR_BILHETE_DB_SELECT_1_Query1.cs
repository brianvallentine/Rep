using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_MATRICULA
            INTO :WHOST-MATRIC-IND
            FROM SEGUROS.V0BILHETE
            WHERE NUM_APOLICE = :V1ENDO-NUMAPOL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_MATRICULA
											FROM SEGUROS.V0BILHETE
											WHERE NUM_APOLICE = '{this.V1ENDO_NUMAPOL}'
											WITH UR";

            return query;
        }
        public string WHOST_MATRIC_IND { get; set; }
        public string V1ENDO_NUMAPOL { get; set; }

        public static R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1 Execute(R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1 r1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_MATRIC_IND = result[i++].Value?.ToString();
            return dta;
        }

    }
}