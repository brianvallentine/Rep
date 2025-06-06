using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6017B
{
    public class R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 : QueryBasis<R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NUM_COPIAS)
            INTO :RELATORI-NUM-COPIAS:VIND-NRCOPIAS
            FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO = 'CARTAECT'
            AND MES_REFERENCIA = :SISTEMAS-MESREFER
            AND ANO_REFERENCIA = :SISTEMAS-ANOREFER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NUM_COPIAS)
											FROM SEGUROS.RELATORIOS
											WHERE COD_RELATORIO = 'CARTAECT'
											AND MES_REFERENCIA = '{this.SISTEMAS_MESREFER}'
											AND ANO_REFERENCIA = '{this.SISTEMAS_ANOREFER}'";

            return query;
        }
        public string RELATORI_NUM_COPIAS { get; set; }
        public string VIND_NRCOPIAS { get; set; }
        public string SISTEMAS_MESREFER { get; set; }
        public string SISTEMAS_ANOREFER { get; set; }

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
            dta.RELATORI_NUM_COPIAS = result[i++].Value?.ToString();
            dta.VIND_NRCOPIAS = string.IsNullOrWhiteSpace(dta.RELATORI_NUM_COPIAS) ? "-1" : "0";
            return dta;
        }

    }
}