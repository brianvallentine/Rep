using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1 : QueryBasis<R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_APOLICE
            INTO :NUMERAES-SEQ-APOLICE
            FROM SEGUROS.NUMERO_AES
            WHERE ORGAO_EMISSOR =
            :NUMERAES-ORGAO-EMISSOR
            AND RAMO_EMISSOR =
            :NUMERAES-RAMO-EMISSOR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_APOLICE
											FROM SEGUROS.NUMERO_AES
											WHERE ORGAO_EMISSOR =
											'{this.NUMERAES_ORGAO_EMISSOR}'
											AND RAMO_EMISSOR =
											'{this.NUMERAES_RAMO_EMISSOR}'
											WITH UR";

            return query;
        }
        public string NUMERAES_SEQ_APOLICE { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }

        public static R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1 Execute(R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1 r3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1)
        {
            var ths = r3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERAES_SEQ_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}