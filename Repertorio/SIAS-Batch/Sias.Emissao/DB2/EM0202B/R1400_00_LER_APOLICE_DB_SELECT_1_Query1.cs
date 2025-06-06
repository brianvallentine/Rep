using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1400_00_LER_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R1400_00_LER_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME
            ,CODCLIEN
            INTO :V1APOL-NOME
            ,:V1APOL-CODCLIEN
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :V1EDIA-NUM-APOL
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME
											,CODCLIEN
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.V1EDIA_NUM_APOL}'";

            return query;
        }
        public string V1APOL_NOME { get; set; }
        public string V1APOL_CODCLIEN { get; set; }
        public string V1EDIA_NUM_APOL { get; set; }

        public static R1400_00_LER_APOLICE_DB_SELECT_1_Query1 Execute(R1400_00_LER_APOLICE_DB_SELECT_1_Query1 r1400_00_LER_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_LER_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_LER_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_LER_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APOL_NOME = result[i++].Value?.ToString();
            dta.V1APOL_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}