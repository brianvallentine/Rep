using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDOS_COBRANCA
            ,ENDOS_RESTITUICAO
            INTO :NUMERAES-ENDOS-COBRANCA
            ,:NUMERAES-ENDOS-RESTITUICAO
            FROM SEGUROS.NUMERO_AES
            WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR
            AND RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDOS_COBRANCA
											,ENDOS_RESTITUICAO
											FROM SEGUROS.NUMERO_AES
											WHERE ORGAO_EMISSOR = '{this.NUMERAES_ORGAO_EMISSOR}'
											AND RAMO_EMISSOR = '{this.NUMERAES_RAMO_EMISSOR}'
											WITH UR";

            return query;
        }
        public string NUMERAES_ENDOS_COBRANCA { get; set; }
        public string NUMERAES_ENDOS_RESTITUICAO { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }

        public static R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1 r0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERAES_ENDOS_COBRANCA = result[i++].Value?.ToString();
            dta.NUMERAES_ENDOS_RESTITUICAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}