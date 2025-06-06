using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_ENDERECO
            INTO :ENDOSSOS-OCORR-ENDERECO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :GE403-NUM-APOLICE
            AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_ENDERECO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.GE403_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.GE403_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }

        public static R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1 Execute(R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1 r7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}