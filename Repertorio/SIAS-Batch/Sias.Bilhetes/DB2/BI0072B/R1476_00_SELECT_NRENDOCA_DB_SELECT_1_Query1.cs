using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1 : QueryBasis<R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDOS_CANCELA
            INTO :NUMERAES-ENDOS-CANCELA
            FROM SEGUROS.NUMERO_AES
            WHERE RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR
            AND ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDOS_CANCELA
											FROM SEGUROS.NUMERO_AES
											WHERE RAMO_EMISSOR = '{this.NUMERAES_RAMO_EMISSOR}'
											AND ORGAO_EMISSOR = '{this.NUMERAES_ORGAO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_ENDOS_CANCELA { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }

        public static R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1 Execute(R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1 r1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1)
        {
            var ths = r1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERAES_ENDOS_CANCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}