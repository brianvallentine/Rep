using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6256B
{
    public class R0200_00_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<R0200_00_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_PROPOSTA
            INTO :PROPOFID-DATA-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :MOVDEBCE-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.MOVDEBCE_NUM_ENDOSSO}'";

            return query;
        }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }

        public static R0200_00_PROCESSA_DB_SELECT_1_Query1 Execute(R0200_00_PROCESSA_DB_SELECT_1_Query1 r0200_00_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}