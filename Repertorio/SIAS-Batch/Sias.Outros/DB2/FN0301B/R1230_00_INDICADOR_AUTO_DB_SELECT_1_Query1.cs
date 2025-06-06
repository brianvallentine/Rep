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
    public class R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1 : QueryBasis<R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_MATRICULA
            INTO :WHOST-MATRIC-IND
            FROM SEGUROS.V1APOLCOB
            WHERE NUM_APOLICE = :V1ENDO-NUMAPOL
            AND NRENDOS = :V1ENDO-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_MATRICULA
											FROM SEGUROS.V1APOLCOB
											WHERE NUM_APOLICE = '{this.V1ENDO_NUMAPOL}'
											AND NRENDOS = '{this.V1ENDO_NRENDOS}'
											WITH UR";

            return query;
        }
        public string WHOST_MATRIC_IND { get; set; }
        public string V1ENDO_NUMAPOL { get; set; }
        public string V1ENDO_NRENDOS { get; set; }

        public static R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1 Execute(R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1 r1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1)
        {
            var ths = r1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_MATRIC_IND = result[i++].Value?.ToString();
            return dta;
        }

    }
}