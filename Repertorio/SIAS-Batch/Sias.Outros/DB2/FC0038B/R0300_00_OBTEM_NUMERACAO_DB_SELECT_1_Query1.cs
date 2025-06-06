using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0038B
{
    public class R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 : QueryBasis<R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NRCOPIAS)
            INTO :V0RELA-NRCOPIAS:VIND-NRCOPIAS
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'CARTAECT'
            AND MES_REFERENCIA = :V0SIST-MESREFER
            AND ANO_REFERENCIA = :V0SIST-ANOREFER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NRCOPIAS)
											FROM SEGUROS.V0RELATORIOS
											WHERE CODRELAT = 'CARTAECT'
											AND MES_REFERENCIA = '{this.V0SIST_MESREFER}'
											AND ANO_REFERENCIA = '{this.V0SIST_ANOREFER}'";

            return query;
        }
        public string V0RELA_NRCOPIAS { get; set; }
        public string VIND_NRCOPIAS { get; set; }
        public string V0SIST_MESREFER { get; set; }
        public string V0SIST_ANOREFER { get; set; }

        public static R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 Execute(R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RELA_NRCOPIAS = result[i++].Value?.ToString();
            dta.VIND_NRCOPIAS = string.IsNullOrWhiteSpace(dta.V0RELA_NRCOPIAS) ? "-1" : "0";
            return dta;
        }

    }
}