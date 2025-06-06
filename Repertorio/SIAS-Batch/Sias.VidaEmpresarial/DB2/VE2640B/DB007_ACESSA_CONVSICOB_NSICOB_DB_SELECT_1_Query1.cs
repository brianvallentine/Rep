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
    public class DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 : QueryBasis<DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :H-NUM-SICOB
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :H-NUM-PROPOSTA-SIVPF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.H_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string H_NUM_SICOB { get; set; }
        public string H_NUM_PROPOSTA_SIVPF { get; set; }

        public static DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 Execute(DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 dB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1)
        {
            var ths = dB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.H_NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}