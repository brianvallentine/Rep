using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0706B
{
    public class R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            INTO :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1 Execute(R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1 r0101_00_LER_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r0101_00_LER_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}