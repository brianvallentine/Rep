using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_RCAP
            ,B.NUM_RCAP_COMPLEMEN
            INTO :RCAPCOMP-NUM-RCAP
            ,:RCAPCOMP-NUM-RCAP-COMPLEMEN
            FROM SEGUROS.RCAPS A
            ,SEGUROS.RCAP_COMPLEMENTAR B
            WHERE A.NUM_TITULO = :BILHETE-NUM-BILHETE
            AND B.NUM_RCAP = A.NUM_RCAP
            AND B.COD_FONTE = A.COD_FONTE
            AND B.NUM_RCAP_COMPLEMEN <> 0
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NUM_RCAP
											,B.NUM_RCAP_COMPLEMEN
											FROM SEGUROS.RCAPS A
											,SEGUROS.RCAP_COMPLEMENTAR B
											WHERE A.NUM_TITULO = '{this.BILHETE_NUM_BILHETE}'
											AND B.NUM_RCAP = A.NUM_RCAP
											AND B.COD_FONTE = A.COD_FONTE
											AND B.NUM_RCAP_COMPLEMEN <> 0
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPCOMP_NUM_RCAP { get; set; }
        public string RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 Execute(R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 r0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP_COMPLEMEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}