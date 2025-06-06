using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT '1'
            INTO :WSHOST-EXISTE-CONTA
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT '1'
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string WSHOST_EXISTE_CONTA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1 Execute(R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1 r1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WSHOST_EXISTE_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}