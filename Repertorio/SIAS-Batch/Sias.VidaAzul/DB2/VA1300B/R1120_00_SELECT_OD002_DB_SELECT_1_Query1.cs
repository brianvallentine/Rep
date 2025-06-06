using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R1120_00_SELECT_OD002_DB_SELECT_1_Query1 : QueryBasis<R1120_00_SELECT_OD002_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PESSOA ,
            NUM_CPF ,
            NUM_DV_CPF ,
            NOM_PESSOA
            INTO :OD002-NUM-PESSOA ,
            :OD002-NUM-CPF ,
            :OD002-NUM-DV-CPF ,
            :OD002-NOM-PESSOA
            FROM ODS.OD_PESSOA_FISICA
            WHERE NUM_PESSOA = :GE368-NUM-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PESSOA 
							,
											NUM_CPF 
							,
											NUM_DV_CPF 
							,
											NOM_PESSOA
											FROM ODS.OD_PESSOA_FISICA
											WHERE NUM_PESSOA = '{this.GE368_NUM_PESSOA}'";

            return query;
        }
        public string OD002_NUM_PESSOA { get; set; }
        public string OD002_NUM_CPF { get; set; }
        public string OD002_NUM_DV_CPF { get; set; }
        public string OD002_NOM_PESSOA { get; set; }
        public string GE368_NUM_PESSOA { get; set; }

        public static R1120_00_SELECT_OD002_DB_SELECT_1_Query1 Execute(R1120_00_SELECT_OD002_DB_SELECT_1_Query1 r1120_00_SELECT_OD002_DB_SELECT_1_Query1)
        {
            var ths = r1120_00_SELECT_OD002_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1120_00_SELECT_OD002_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1120_00_SELECT_OD002_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD002_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD002_NUM_CPF = result[i++].Value?.ToString();
            dta.OD002_NUM_DV_CPF = result[i++].Value?.ToString();
            dta.OD002_NOM_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}