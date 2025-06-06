using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 : QueryBasis<DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            INTO :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_SICOB = :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_SICOB = '{this.NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 Execute(DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 dB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1)
        {
            var ths = dB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}