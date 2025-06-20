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
    public class R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 : QueryBasis<R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORGAO_EMISSOR
            ,RAMO_EMISSOR
            ,ENDOS_CANCELA
            INTO :NUMERAES-ORGAO-EMISSOR
            ,:NUMERAES-RAMO-EMISSOR
            ,:NUMERAES-ENDOS-CANCELA
            FROM SEGUROS.NUMERO_AES
            WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR
            AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORGAO_EMISSOR
											,RAMO_EMISSOR
											,ENDOS_CANCELA
											FROM SEGUROS.NUMERO_AES
											WHERE ORGAO_EMISSOR = '{this.APOLICES_ORGAO_EMISSOR}'
											AND RAMO_EMISSOR = '{this.APOLICES_RAMO_EMISSOR}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }
        public string NUMERAES_ENDOS_CANCELA { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }

        public static R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 Execute(R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 r1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1)
        {
            var ths = r1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERAES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.NUMERAES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.NUMERAES_ENDOS_CANCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}