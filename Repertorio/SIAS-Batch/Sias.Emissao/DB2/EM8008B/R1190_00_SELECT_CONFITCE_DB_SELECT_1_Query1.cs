using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8008B
{
    public class R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1 : QueryBasis<R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAC
            INTO :CONFITCE-NSAC
            FROM SEGUROS.CONTROLE_FITAS_CEF
            WHERE NSAC = :CONFITCE-NSAC
            AND DATA_GERACAO > :V1SIST-DTCURRENT-18
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NSAC
											FROM SEGUROS.CONTROLE_FITAS_CEF
											WHERE NSAC = '{this.CONFITCE_NSAC}'
											AND DATA_GERACAO > '{this.V1SIST_DTCURRENT_18}'
											WITH UR";

            return query;
        }
        public string CONFITCE_NSAC { get; set; }
        public string V1SIST_DTCURRENT_18 { get; set; }

        public static R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1 Execute(R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1 r1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1)
        {
            var ths = r1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONFITCE_NSAC = result[i++].Value?.ToString();
            return dta;
        }

    }
}